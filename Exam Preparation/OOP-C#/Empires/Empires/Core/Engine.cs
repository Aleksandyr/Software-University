namespace Empires.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using Empires.Enums;
    using Empires.Interfaces;

    public class Engine : IRunnable
    {
        private IBuildingFactory buildingFactory;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;
        private IData data;
        private IInputReader reader;
        private IOuptupWriter writer;

        public Engine(IBuildingFactory buildingFactory, IResourceFactory resourceFactory, IUnitFactory unitFactory, IData data, IInputReader reader, IOuptupWriter writer)
        {
            this.buildingFactory = buildingFactory;
            this.resourceFactory = resourceFactory;
            this.unitFactory = unitFactory;
            this.data = data;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string[] input = this.reader.ReadLine().Split();

                this.ExecuteCommand(input);
                this.UpdateBuildings();
            }   
        }

        private void UpdateBuildings()
        {
            foreach (var building in this.data.Buildings)
            {
                building.Update();
                if (building.CanProduceResource)
                {
                    var resource = building.ProduceResource();
                    this.data.Resources[resource.ResourceType] += resource.Quantity;
                }

                if (building.CanProduceUnit)
                {
                    var unit = building.ProduceUnit();
                    this.data.AddUnit(unit);
                }
            }
        }

        private void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "empire-status":
                    this.ExecuteStatusCommand();
                    break;
                case "skip":
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                case "build":
                    this.ExecuteBuildCommand(inputParams[1]);
                    break;
                default:
                    throw new InvalidOperationException("Incorrect command.");
            }
        }

        private void ExecuteBuildCommand(string buildingType)
        {
            IBuilding building = this.buildingFactory.CreateBuilding(buildingType, this.unitFactory, this.resourceFactory);

            this.data.AddBuilding(building);
        }

        private void ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();

            this.AppendTreasuryInfo(output);
            this.AppendBuildingInfo(output);
            this.AppendUnitsInfo(output);

            this.writer.Print(output.ToString().Trim());
        }

        private void AppendUnitsInfo(StringBuilder output)
        {
            output.AppendLine("Units:");
            if (this.data.Units.Any())
            {
                foreach (var unit in this.data.Units)
                {
                    output.AppendLine(string.Format("--{0}: {1}", unit.Key, unit.Value));
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendBuildingInfo(StringBuilder output)
        {
            output.AppendLine("Buildings:");
            if (this.data.Buildings.Any())
            {
                foreach (var buidling in this.data.Buildings)
                {
                    output.AppendLine(buidling.ToString());
                }
            }
            else
            {
                output.AppendLine("N/A");
            }
        }

        private void AppendTreasuryInfo(StringBuilder output)
        {
            output.AppendLine("Treasury:");
            foreach (var resource in this.data.Resources)
            {
                output.AppendLine(string.Format("--{0}: {1}", resource.Key, resource.Value));
            }
        }
    }
}

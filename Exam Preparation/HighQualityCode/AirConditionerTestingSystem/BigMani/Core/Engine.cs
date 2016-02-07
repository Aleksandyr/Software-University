namespace BigMani.Wokr
{
    using System;

    using BigMani.Infrastructure;
    using BigMani.Interfaces;

    public class Engine
    {
        public Engine(IUserInterface userInterface, ICommandExecutor commandExecutor)
        {
            this.UserInterface = userInterface;
            this.CommandExecutor = commandExecutor;
        }

        public IUserInterface UserInterface { get; set; }

        public ICommand Command { get; set; }

        public ICommandExecutor CommandExecutor { get; set; }

        public virtual void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Command = new Command(line);

                    try
                    {
                        switch (this.Command.Name)
                        {
                            case "RegisterStationaryAirConditioner":
                                this.ValidateParametersCount(this.Command, ValidationConstants.ManufacturerMinLength);
                                this.UserInterface.WriteLine(this.CommandExecutor.RegisterStationaryAirConditioner(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2],
                                    this.Command.Parameters[3],
                                    int.Parse(this.Command.Parameters[4])));

                                break;
                            case "RegisterCarAirConditioner":
                                this.ValidateParametersCount(this.Command, ValidationConstants.MinCarVolume);
                                this.UserInterface.WriteLine(this.CommandExecutor.RegisterCarAirConditioner(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2],
                                    int.Parse(this.Command.Parameters[3])));
                                break;
                            case "RegisterPlaneAirConditioner":
                                this.ValidateParametersCount(this.Command, ValidationConstants.ManufacturerMinLength);
                                this.UserInterface.WriteLine(this.CommandExecutor.RegisterPlaneAirConditioner(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2],
                                    int.Parse(this.Command.Parameters[3]),
                                    int.Parse(this.Command.Parameters[4])));
                                break;
                            case "TestAirConditioner":
                                this.ValidateParametersCount(this.Command, ValidationConstants.ModelTestMinLength);
                                this.UserInterface.WriteLine(this.CommandExecutor.TestAirConditioner(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2]));
                                break;
                            case "FindAirConditioner":
                                this.ValidateParametersCount(this.Command, ValidationConstants.ModelTestMinLength);
                                this.UserInterface.WriteLine(this.CommandExecutor.FindAirConditioner(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2]));
                                break;
                            case "FindReport":
                                this.ValidateParametersCount(this.Command, 2);
                                this.UserInterface.WriteLine(this.CommandExecutor.FindReport(
                                    this.Command.Parameters[1],
                                    this.Command.Parameters[2]));
                                break;
                            case "FindAllReportsByManufacturer":
                                this.ValidateParametersCount(this.Command, ValidationConstants.ModelMinLength);
                                this.UserInterface.WriteLine(this.CommandExecutor.FindAllReportsByManufacturer(
                                    this.Command.Parameters[1]));
                                break;
                            case "Status":
                                this.ValidateParametersCount(this.Command, 0);
                                this.UserInterface.WriteLine(this.CommandExecutor.Status());
                                break;
                            default:
                                throw new IndexOutOfRangeException(ValidationConstants.INVALIDCOMMAND);
                        }
                    }
                    catch (FormatException ex)
                    {
                        this.UserInterface.WriteLine(ex.Message);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        this.UserInterface.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }
            }
        }

        private void ValidateParametersCount(ICommand command, int count)
        {
            if (command.Parameters.Length - 1 != count)
            {
                throw new InvalidOperationException(ValidationConstants.INVALIDCOMMAND);
            }
        }
    }
}

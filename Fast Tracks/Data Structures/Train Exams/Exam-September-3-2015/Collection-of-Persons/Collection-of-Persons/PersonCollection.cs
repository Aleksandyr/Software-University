using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    // TODO: define the underlying data structures here ...
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<string, SortedSet<Person>> personByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        var person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        this.personsByEmail.Add(email, person);

        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByDomain.AppendValueToKey(emailDomain, person);

        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personByNameAndTown.AppendValueToKey(nameAndTown, person);
        
        this.personsByAge.AppendValueToKey(age, person);

        this.personByTownAndAge.EnsureKeyExists(town);
        this.personByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get { return this.personsByEmail.Count; }
    }

    public Person FindPerson(string email)
    {
        Person person;
        var personExists = this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }

        var personDeleted = this.personsByEmail.Remove(email);

        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByDomain[emailDomain].Remove(person);

        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personByNameAndTown[nameAndTown].Remove(person);

        this.personsByAge[person.Age].Remove(person);

        personByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);
        return this.personByNameAndTown.GetValuesForKey(nameAndTown);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange =
            this.personsByAge.Range(startAge, true, endAge, true);
        foreach (var personByAge in personsInRange)
        {
            foreach (var person in personByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personInRange = this.personByTownAndAge[town]
            .Range(startAge, true, endAge, true);

        foreach (var personByTownAndAge in personInRange)
        {
            foreach (var person in personByTownAndAge.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];
        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";
        return name + separator + town;
    }
}

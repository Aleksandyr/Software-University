namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Database methods that we canuse.
    /// </summary>
    /// <typeparam name="Generic parametar"></typeparam>
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Add(T item);
    }
}
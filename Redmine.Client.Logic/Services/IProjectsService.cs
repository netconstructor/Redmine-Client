namespace Redmine.Client.Logic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Redmine.Client.Logic.Domain;

    /// <summary>
    /// Provides manipulations with projects entities.
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// Gets the collection of projects.
        /// </summary>
        /// <returns>The list of projects.</returns>
        Task<IEnumerable<Project>> Get();
    }
}
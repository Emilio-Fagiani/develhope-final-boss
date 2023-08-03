using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Shared;

namespace Develhope.DataAccess
{
    public class ProjectRepository : IRepository<Project>
    {
        private static readonly string _PROJECT_DATA_PATH = Constants.DATA_PATH + "projects.json";

        private JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
        };

        public async Task CreateAsync(Project item)
        {
            var allProject = await GetAllAsync();
            allProject.Add(item);
            
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var file = await File.ReadAllTextAsync(_PROJECT_DATA_PATH);
            return JsonSerializer.Deserialize<List<Project>>(file, options)?? new List<Project>();

        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var file = await File.ReadAllTextAsync(_PROJECT_DATA_PATH + id);
            return JsonSerializer.Deserialize<Project>(file,options)?? new Project();
        }
        public async Task<List<Project>> GetByDeliveryDateAsync(DateTime DeliveryDate)
        {
            var file = await File.ReadAllTextAsync(_PROJECT_DATA_PATH + DeliveryDate);
            return JsonSerializer.Deserialize<List<Project>>(file, options);
        }

        public Task UpdateAsync(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
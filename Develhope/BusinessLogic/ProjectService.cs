using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.BusinessLogic.Interfaces;
using Develhope.DataAccess;
using Develhope.DataAccess.Interfaces;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projectRepository;
        private readonly ProjectRepository projectRepo;
       

        public ProjectService(IRepository<Project> repository)
        {
            _projectRepository = repository;
           
        }

        public async Task CreateAsync(Project project)
        {
            await _projectRepository.CreateAsync(project);
        }

        public async Task<List<ProjectListDto>> GetAllAsync()
        {
            return (await _projectRepository.GetAllAsync())
                .ConvertAll(x => new ProjectListDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    DeliveryDate = x.DeliveryDate
                });
        }
        public async Task<Project> GetId(int id)
        {
            return await projectRepo.GetByIdAsync(id);
        }

        public async Task <List<Project>> GetDeliveryDate(DateTime DeliveryDate)
        {
            DateTime currentDate = DateTime.Now;
            return (List<Project>)(await projectRepo.GetByDeliveryDateAsync(DeliveryDate))
                     .Where(p => p.DeliveryDate > currentDate);

        }
    }
}
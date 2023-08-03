using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Develhope.Models;
using Develhope.Models.DTOs;

namespace Develhope.BusinessLogic.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectListDto>> GetAllAsync();
        Task CreateAsync(Project project);
        Task<List<ProjectListDto>> GetDeliveryDate(DateTime DeliveryDate);
    }
}
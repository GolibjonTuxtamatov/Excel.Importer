//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Orchestrations.Groups;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Excel.Importer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : RESTFulController
    {
        private readonly IGroupOrchestrationService groupOrchestrationService;

        public GroupsController(IGroupOrchestrationService groupOrchestrationService)
        {
            this.groupOrchestrationService = groupOrchestrationService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Group>> PostGroupAsync(Group group)
        {
            return await this.groupOrchestrationService.AddGroupAsync(group);
        }

        [HttpGet]
        public IQueryable<Group> GetAllGroups()
        {
            return this.groupOrchestrationService.RetrieveAllGroups();
        }
    }
}

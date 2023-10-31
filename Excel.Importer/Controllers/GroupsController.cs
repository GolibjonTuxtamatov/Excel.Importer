//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using System.Linq;
using System.Threading.Tasks;
using Excel.Importer.Models.Foundations.Groups;
using Excel.Importer.Services.Foundations.Groups.Exceptions;
using Excel.Importer.Services.Orchestrations.Groups;
using Excel.Importer.Services.Orchestrations.Groups.Exceptions;
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
            try
            {
                Group postedGroup = await this.groupOrchestrationService.AddGroupAsync(group);

                return Created(postedGroup);
            }
            catch (GroupOrchestrationValidationException groupOrchestrationValidationException)
            {
                return BadRequest(groupOrchestrationValidationException.InnerException);
            }
            catch (GroupOrchestratioDependencyValidationException groupOrchestrationDependencyvalidationExecption)
                when (groupOrchestrationDependencyvalidationExecption.InnerException is AlreadyExistGroupException)
            {
                return Conflict(groupOrchestrationDependencyvalidationExecption.InnerException);
            }
            catch (GroupOrchestratioDependencyValidationException groupOrchestrationDependencyvalidationExecption)
            {
                return Conflict(groupOrchestrationDependencyvalidationExecption.InnerException);
            }
            catch (GroupOrchestrationDependencyException groupOrchestrationDependencyException)
            {
                return InternalServerError(groupOrchestrationDependencyException.InnerException);
            }
            catch (GroupOrchestrationServiceException groupOrchestrationServiceException)
            {
                return InternalServerError(groupOrchestrationServiceException.InnerException);
            }
        }

        [HttpGet]
        public IQueryable<Group> GetAllGroups()
        {
            return this.groupOrchestrationService.RetrieveAllGroups();
        }
    }
}

using ODD.Api.Application.Contract.Dtos;
using ODD.Api.Application.Contract.Dtos.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Interfaces.WebServices
{
    public interface IStartWorkflowRequest
    {
        Task<ResponseDto> CallStartWorkflowAsync(int WFID, long StarterUserId = 0);
        Task<ResponseDto> CallStartWorkflowWithParamsAsync(WorkflowParamsRequestDto paramters);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.WebService
{


    public class WorkflowParamsRequestDto
    {
        public long WorkFlowID { get; set; }
        public List<TBSParameter> ParamList { get; set; }


    }
    public class TBSParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public string Type { get; set; }
    }
    }

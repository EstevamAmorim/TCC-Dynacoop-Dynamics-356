using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using Models.Models;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Actions.Actions
{
    public class CloneOpportunity : ActionImplement
    {
        [Output("Success")]
        public OutArgument<bool> Success { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            Guid opportunityId = this.WorkflowContext.PrimaryEntityId;
            Opportunity opportunity = new Opportunity(this.Service);

            opportunity.Clone(opportunityId);

            Success.Set(context, true);
        }
    }
}

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Plugins
{
    public class ContactManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider ServiceProvider)
        {
            Entity contact = (Entity)Context.InputParameters["Target"];

            if (contact.Contains("tcc_cpf") && contact["tcc_cpf"].ToString() != "")
            {
                string cpf = contact["tcc_cpf"].ToString();

                QueryExpression retrieveContactWithCpf = new QueryExpression("contact");
                retrieveContactWithCpf.Criteria.AddCondition("tcc_cpf", ConditionOperator.Equal, cpf);
                EntityCollection contacts = Service.RetrieveMultiple(retrieveContactWithCpf);

                if (contacts.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("An account with this CPF already exists!");
                }
            }
        }
    }
}

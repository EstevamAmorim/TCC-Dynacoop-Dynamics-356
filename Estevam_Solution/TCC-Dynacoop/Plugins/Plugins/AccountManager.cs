using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.Plugins
{
    public class AccountManager : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider ServiceProvider)
        {
            Entity account = (Entity)Context.InputParameters["Target"];

            if (account.Contains("tcc_cnpj") && account["tcc_cnpj"].ToString() != "")
            {
                string cnpj = account["tcc_cnpj"].ToString();

                QueryExpression retrieveAccountWithCpf = new QueryExpression("account");
                retrieveAccountWithCpf.Criteria.AddCondition("tcc_cnpj", ConditionOperator.Equal, cnpj);
                EntityCollection accounts = Service.RetrieveMultiple(retrieveAccountWithCpf);

                if (accounts.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("An account with this CNPJ already exists!");
                }

            }

        }
    }
}

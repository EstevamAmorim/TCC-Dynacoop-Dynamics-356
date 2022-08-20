using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace TCCGrupo5.Plugins
{
    public class VerificaDuplicidadeDeOportunidade : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity oportunidade = (Entity)this.Context.InputParameters["Target"];

            QueryExpression recuperarIdentificadorUnico = new QueryExpression("opportunity");
            recuperarIdentificadorUnico.Criteria.AddCondition("tcc_uniqueidentifier", ConditionOperator.Equal, oportunidade["tcc_uniqueidentifier"]);

            EntityCollection identificadoresRecuperados = this.Service.RetrieveMultiple(recuperarIdentificadorUnico);

            if (identificadoresRecuperados.Entities.Count > 0)
            {
                throw new InvalidPluginExecutionException("Esse identificador já foi cadastrado digite outro e tente novamente.");
            }
        }
    }
}

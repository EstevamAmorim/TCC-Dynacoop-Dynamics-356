using Microsoft.Xrm.Sdk;
using System;
using TCCGrupo5.Connections;

namespace TCCGrupo5.Plugins
{
    class RecuperarRegistroDeProdutos : PluginImplement
    {
        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            Entity produto = (Entity)this.Context.InputParameters["Target"];

            IOrganizationService ambiente2Service = ConnectionFactory.GetService();

            IntegrandoTabelaDeProdutos integracao = new IntegrandoTabelaDeProdutos(ambiente2Service);

            string nome = (string)produto["name"];
            string idproduto = (string)produto["productnumber"];
            Guid defaultuomid = integracao.BuscarIdDoRegistro("uomschedule", "tcc_iddoambiente1", ((EntityReference)produto["defaultuomscheduleid"]).Id.ToString(), new string[] { "uomscheduleid" });
            Guid defaultuomscheduleid = integracao.BuscarIdDoRegistro("uom", "tcc_iddoambiente1", ((EntityReference)produto["defaultuomid"]).Id.ToString(), new string[] { "uomid" });
            int quantitydecimal = (int)produto["quantitydecimal"];

            integracao.CadastrarProduto(nome, idproduto, defaultuomid, defaultuomscheduleid, quantitydecimal);
        }
    }
}

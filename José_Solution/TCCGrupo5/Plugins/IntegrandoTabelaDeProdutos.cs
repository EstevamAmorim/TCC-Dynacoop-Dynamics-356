using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace TCCGrupo5.Plugins
{
    public class IntegrandoTabelaDeProdutos
    {
        IOrganizationService Service { get; set; }

        public IntegrandoTabelaDeProdutos(IOrganizationService service)
        {
            this.Service = service;
        }

        public void CadastrarProduto(string nome, string idProduto, Guid uomSchedule, Guid uom, int quantidade)
        {
            Entity Produto = new Entity("product");
            Produto["name"] = nome;
            Produto["productnumber"] = idProduto;
            Produto["defaultuomscheduleid"] = new EntityReference("uomschedule", uomSchedule);
            Produto["defaultuomid"] = new EntityReference("uom", uom);
            Produto["quantitydecimal"] = quantidade;

            this.Service.Create(Produto);
        }
        public Guid BuscarIdDoRegistro(string nomeDaTabela, string nomeDoCampoBuscado, string CampoBuscado, string[] colunas)
        {
            QueryExpression recuperaDados = new QueryExpression(nomeDaTabela);
            recuperaDados.Criteria.AddCondition(nomeDoCampoBuscado, ConditionOperator.Equal, CampoBuscado);
            recuperaDados.ColumnSet.AddColumns(colunas);
            EntityCollection registros = this.Service.RetrieveMultiple(recuperaDados);
            Guid idDoRegistro = (Guid)registros[0].Attributes[colunas[0]];

            return idDoRegistro;
        }

    }
}

using Microsoft.Xrm.Sdk.Workflow;
using Newtonsoft.Json;
using RestSharp;
using System.Activities;

namespace TCCGrupo5.Actions
{
    public class RecuperandoCepDoFormulario : ActionImplement
    {
        [Input("CEP")]
        public InArgument<string> CEP { get; set; }
        [Output("Sucesso")]
        public OutArgument<bool> Sucesso { get; set; }
        [Output("Logradouro")]
        public OutArgument<string> Logradouro { get; set; }
        [Output("Complemento")]
        public OutArgument<string> Complemento { get; set; }
        [Output("Bairro")]
        public OutArgument<string> Bairro { get; set; }
        [Output("Localidade")]
        public OutArgument<string> Localidade { get; set; }
        [Output("UF")]
        public OutArgument<string> UF { get; set; }
        [Output("CodigoIBGE")]
        public OutArgument<string> CodigoIBGE { get; set; }
        [Output("DDD")]
        public OutArgument<string> DDD { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            string cep = CEP.Get(context);

            InformacoesDoCep informacoesDoCep = InvocandoGet(cep);

            string logradouro = informacoesDoCep.Logradouro;
            Logradouro.Set(context, logradouro);

            string complemento = informacoesDoCep.Complemento;
            Complemento.Set(context, complemento);

            string bairro = informacoesDoCep.Bairro;
            Bairro.Set(context, bairro);

            string localidade = informacoesDoCep.Localidade;
            Localidade.Set(context, localidade);

            string uf = informacoesDoCep.UF;
            UF.Set(context, uf);

            string codigoIBGE = informacoesDoCep.IBGE;
            CodigoIBGE.Set(context, codigoIBGE);

            string ddd = informacoesDoCep.DDD;
            DDD.Set(context, ddd);

            Sucesso.Set(context, true);
        }

        private static InformacoesDoCep InvocandoGet(string cep)
        {
            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                InformacoesDoCep informacoesDoCep = JsonConvert.DeserializeObject<InformacoesDoCep>(response.Content);
                return informacoesDoCep;
            }
            else
            {
                return null;
            }
        }
    }
}

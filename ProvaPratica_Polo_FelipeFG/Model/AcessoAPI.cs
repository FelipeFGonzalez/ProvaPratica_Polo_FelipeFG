using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;

namespace ProvaPratica_Polo_FelipeFG.Model
{
    public class AcessoAPI
    {
        private static HttpClient client = new HttpClient();
        

        public AcessoAPI()
        {
            client.BaseAddress = new Uri("https://olinda.bcb.gov.br/olinda/servico/Expectativas/versao/v1/odata/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<RootIndicador> getIndicadores(string tipoIndicador, DateTime dataIni, DateTime dataFim)
        {
            string URL;

            if (dataIni.Year == dataFim.Year)
            {
                if (dataIni.Month == dataFim.Month)
                {
                    URL = client.BaseAddress + $"ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'{tipoIndicador}'%20and%20DataReferencia%20eq%20'{dataIni.Month:00}%2F{dataIni.Year}'";
                }
                else
                {
                    URL = client.BaseAddress + $"ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'{tipoIndicador}'%20and%20substring(DataReferencia%2C4)%20eq%20'{dataIni.Year}'%20and%20substring(DataReferencia%2C1%2C2)%20le%20'{dataFim.Month:00}'%20and%20substring(DataReferencia%2C1%2C2)%20ge%20'{dataIni.Month:00}'";
                }
            }
            else
            {
                URL = $"ExpectativaMercadoMensais?%24format=json&%24orderby=Data%20desc&%24filter=Indicador%20eq%20'{tipoIndicador}'%20and%20((substring(DataReferencia%2C4)%20eq%20'{dataIni.Year}'%20and%20substring(DataReferencia%2C1%2C2)%20ge%20'{dataIni.Month:00}')%20or%20(substring(DataReferencia%2C4)%20gt%20'{dataIni.Year}'%20and%20substring(DataReferencia%2C4)%20lt%20'{dataFim.Year}')%20or%20(substring(DataReferencia%2C4)%20eq%20'{dataFim.Year}'%20and%20substring(DataReferencia%2C1%2C2)%20le%20'{dataFim.Month:00}'))";
            }


            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.Content != null)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                RootIndicador resposta = JsonConvert.DeserializeObject<RootIndicador>(responseBody);
                return resposta;
            }

            return null;
        }
        public async Task<RootIndicador> getSelic(DateTime dataIni, DateTime dataFim)
        {
            string URL;
            string[] rI = { "R1", "R2", "R2", "R3", "R4", "R4", "R5", "R6", "R6", "R7", "R8", "R8" };
            string[] rF = { "R1", "R1", "R2", "R3", "R3", "R4", "R5", "R5", "R6", "R7", "R7", "R8" };
            int anoIni = dataIni.Year;
            int anoFim = dataFim.Year;
            int mesIni = dataIni.Month;
            int mesFim = dataFim.Month;
            string rIni = rI[mesIni];
            string rFim = rF[mesFim];

            if (anoIni == anoFim)
            {
                if (dataIni.Month == dataFim.Month)
                {
                    URL = client.BaseAddress + $"ExpectativasMercadoSelic?%24format=json&%24orderby=Data%20desc&%24filter=Reuniao%20eq%20'{rIni}%2F{anoIni}'";
                }
                else
                {
                    URL = client.BaseAddress + $"ExpectativasMercadoSelic?%24format=json&%24orderby=Data%20desc&%24filter=substring(Reuniao%2C4)%20eq%20'{anoIni}'%20and%20substring(Reuniao%2C1%2C2)%20le%20'{rFim}'%20and%20substring(Reuniao%2C1%2C2)%20ge%20'{rIni}'";
                }
            }
            else
            {
                URL = $"ExpectativasMercadoSelic?%24format=json&%24orderby=Data%20desc&%24filter=((substring(Reuniao%2C4)%20eq%20'{anoIni}'%20and%20substring(Reuniao%2C1%2C2)%20ge%20'{rIni}')%20or%20(substring(Reuniao%2C4)%20gt%20'{anoIni}'%20and%20substring(Reuniao%2C4)%20lt%20'{anoFim}')%20or%20(substring(Reuniao%2C4)%20eq%20'{anoFim}'%20and%20substring(Reuniao%2C1%2C2)%20le%20'{rFim}'))";
            }


            HttpResponseMessage response = await client.GetAsync(URL);
            if (response.Content != null)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                RootIndicador resposta = JsonConvert.DeserializeObject<RootIndicador>(responseBody);
                return resposta;
            }

            return null;
        }
    }
}


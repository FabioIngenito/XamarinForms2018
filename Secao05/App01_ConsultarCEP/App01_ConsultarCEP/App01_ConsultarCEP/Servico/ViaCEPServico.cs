using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            string Conteudo = "";
            Endereco End = new Endereco();
            WebClient wc = new WebClient();

            Conteudo = wc.DownloadString(NovoEnderecoURL);
            End = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (End.cep == null) return null;

            return End;
        }
    }
}

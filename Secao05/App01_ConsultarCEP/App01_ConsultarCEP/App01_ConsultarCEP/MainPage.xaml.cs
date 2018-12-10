using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        /// <summary>
        /// Lógica do Programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BuscarCEP(object sender, EventArgs args)
        {
            Endereco end = new Endereco();
            string cep = CEP.Text.Trim();

            try
            {
                if (isValidCEP(cep))
                {
                    end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                    
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Erro crítico: ", e.Message, "OK");
            }
        }

        /// <summary>
        /// Validações
        /// Pesquisar "Data Anottation" para fazer validação
        /// </summary>
        /// <param name="">CEP - Passe um CEP</param>
        /// <returns>Retorna se o CEP é válido ou não</returns>
        private bool isValidCEP(string cep)
        {
            Boolean valido = true;
            int NovoCEP = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");

                valido = false;
            }
            else if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve deve ser composto apenas por números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void BuscarCEP(object sender, EventArgs args){
            // todo - logica do programa.

            // todo - validações.

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try { 
           
                    Endereco end = ViaCEPServico.BuscarEndrecoViaCEP(cep);
                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {3} de {2} {0}, {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP NÃO ENCONTRADO: " + cep, "OK");
                    }

                   
                }
                catch (Exception e)
                {
                    DisplayAlert("erro critico", e.Message, "OK");
                }
             }
           
          }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
           if(cep.Length != 8)
            {
                //erro
                DisplayAlert("ERRO", "CEP Inválido - O CEP deve conter 8 carcteres. ", "OK");
                valido = false;
            } 

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                valido = false;
                DisplayAlert("ERRO", "CEP Inválido - O CEP deve ser composto apenas por numeros",  "OK");
                //erro
            }
            return valido;
        }
    }
}

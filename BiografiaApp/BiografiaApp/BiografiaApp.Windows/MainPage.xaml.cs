using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BiografiaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public class Pessoa
        {
            public int Id { get; set; }
            public String Nome { get; set; }
            public DateTime DataNascimento { get; set; }
            public String Biografia { get; set; }
        }

        public MainPage()
        {
            this.InitializeComponent();
            using (var client = new System.Net.Http.HttpClient())
            {
                var result = client.GetAsync("http://localhost:51706/api/pessoa").Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;

                List<Pessoa> model = null;
                model = JsonConvert.DeserializeObject<List<Pessoa>>(resultContent);

                foreach (Pessoa aPessoas in model)
                {
                    lvPessoas.Items.Add("Nome: " + aPessoas.Nome + "\n" +
                                        "Data de Nascimento: " + aPessoas.DataNascimento.ToString("dd/MM/yyyy") + "\n" +
                                        "Biografia: " + aPessoas.Biografia);
                }
            }
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                var result = client.GetAsync("http://localhost:51706/api/pessoa").Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;

                List<Pessoa> model = null;
                model = JsonConvert.DeserializeObject<List<Pessoa>>(resultContent);

                lvPessoas.Items.Clear();

                foreach (Pessoa aPessoas in model)
                {
                    lvPessoas.Items.Add("Nome: " + aPessoas.Nome + "\n" +
                                        "Data de Nascimento: " + aPessoas.DataNascimento.ToString("dd/MM/yyyy") + "\n" +
                                        "Biografia: " + aPessoas.Biografia);    
                }                    

            }

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Cadastrar));
            
        }


    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BiografiaApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                var result = client.GetAsync("http://localhost:51706/api/pessoa").Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                tbxBiografia.Text = resultContent;

            }
            
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51706");
                var content = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Nome", tbxNome.Text),
                new KeyValuePair<string, string>("DataNascimento", Convert.ToString(dtpDataNasc.Date)),
                new KeyValuePair<string, string>("Biografia", tbxBiografia.Text)
                    
            });
                var result = client.PostAsync("/api/pessoa", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                tbxBiografia.Text = resultContent;
            }
        }

    }
}

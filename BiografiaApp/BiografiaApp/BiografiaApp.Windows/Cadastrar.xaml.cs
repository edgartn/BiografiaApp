using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Cadastrar : Page
    {

        public Cadastrar()
        {
            this.InitializeComponent();

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (tbxNome.Text.Length < 5 || tbxNome.Text.Length > 50) 
            {
                MessageDialog msgbox = new MessageDialog("O Nome deve conter entre 5 e 50 caracteres!");
                msgbox.Commands.Add(new UICommand("Close"));
                msgbox.ShowAsync();

            } else {
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
                }

                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}

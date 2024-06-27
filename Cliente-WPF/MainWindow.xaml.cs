using Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cliente_WPF
{
    using Newtonsoft.Json;
    using Server.JSON;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cliente cliente = null;

        public MainWindow()
        {
            InitializeComponent();

            Iniciar();
        }

        private async void Iniciar()
        {
            cliente = new Cliente();
            await cliente.ConnectAsync("Usuário R");
        }

        private async void EnviarMensagem()
        {
            string mensagem = criarMensagem();

            await cliente.SendMessageAsync(mensagem);
        }

        private string criarMensagem()
        {
            root json = new root();

            json.conteudo.codigoApp = 1;
            json.conteudo.codigoAção = 1;

            Link link = new Link();

            link.id = 1;
            link.nome = "VIVO";
            link.sigla = "VV";
            link.velocidade = "200 Mb";
            link.linkSegueMonitorado = true;
            link.linkUp = false;

            json.links.Add(link);

            string conteúdo = JsonConvert.SerializeObject(json);

            return conteúdo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnviarMensagem();
        }
    }
}
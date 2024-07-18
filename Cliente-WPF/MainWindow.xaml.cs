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
    using System.IO;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Cliente cliente = null;

        private List<string> nomes = new List<string> {"Miguel", "Théo", "Gael", "Heitor", "Ravi", "Arthur", "Noah"};

        private int contador = 0;

        public MainWindow()
        {
            InitializeComponent();

            Iniciar();
        }

        private async void Iniciar()
        {
            Random random = new Random();

            cliente = new Cliente();
            await cliente.ConnectAsync(nomes[random.Next(0, nomes.Count - 1)]);
        }

        private async void EnviarMensagem()
        {
            string mensagem = criarMensagem();

            await cliente.SendMessageAsync(mensagem);
        }

        private string criarMensagem()
        {
            contador++;

            root root = new root();

            root.cabecalho = new Cabecalho { codigoApp = 02, codigoAção = 02 };

            if (contador % 2 == 0)
            {
                root.links.Add(new Link
                {
                    hora = Convert.ToDateTime("29/06/2024 12:00:00"),
                    destino = "Manaus",
                    compania = "GOL",
                    voo = 3356,
                    codigoPassagem = "AAL7759",
                    terminal = 2,
                    portao = 215,
                    observacao = "Voo atrasado"
                });
            }
            else
            {
                root.links.Add(new Link
                {
                    hora = Convert.ToDateTime("29/06/2024 12:00:00"),
                    destino = "Manaus",
                    compania = "GOL",
                    voo = 3356,
                    codigoPassagem = "AAL7759",
                    terminal = 2,
                    portao = 215,
                    observacao = "Voo atrasado"
                });
            }

            string conteúdo = JsonConvert.SerializeObject(root);

            return conteúdo;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnviarMensagem();
        }
    }
}
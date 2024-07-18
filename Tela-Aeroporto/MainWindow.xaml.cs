using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Tela_Aeroporto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Link> Links { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Links = new ObservableCollection<Link>
            {
                new Link { Hora = new DateTime(2024, 7, 16, 14, 30, 0), Destino = "New York", Compania = "Delta", Voo = 1234, CodigoPassagem = "NY1234", Terminal = 1, Portao = 10, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 15, 45, 0), Destino = "Los Angeles", Compania = "American Airlines", Voo = 5678, CodigoPassagem = "LA5678", Terminal = 2, Portao = 15, Observacao = "Delayed" },
                new Link { Hora = new DateTime(2024, 7, 16, 16, 0, 0), Destino = "Chicago", Compania = "United", Voo = 9101, CodigoPassagem = "CH9101", Terminal = 3, Portao = 20, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 17, 30, 0), Destino = "Miami", Compania = "American Airlines", Voo = 2345, CodigoPassagem = "MI2345", Terminal = 1, Portao = 5, Observacao = "Boarding" },
                new Link { Hora = new DateTime(2024, 7, 16, 18, 45, 0), Destino = "San Francisco", Compania = "Delta", Voo = 6789, CodigoPassagem = "SF6789", Terminal = 2, Portao = 8, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 19, 0, 0), Destino = "Seattle", Compania = "Alaska Airlines", Voo = 1123, CodigoPassagem = "SE1123", Terminal = 3, Portao = 12, Observacao = "Delayed" },
                new Link { Hora = new DateTime(2024, 7, 16, 20, 30, 0), Destino = "Boston", Compania = "JetBlue", Voo = 4456, CodigoPassagem = "BO4456", Terminal = 1, Portao = 14, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 21, 45, 0), Destino = "Houston", Compania = "Southwest", Voo = 7890, CodigoPassagem = "HO7890", Terminal = 2, Portao = 17, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 22, 0, 0), Destino = "Dallas", Compania = "American Airlines", Voo = 3456, CodigoPassagem = "DA3456", Terminal = 3, Portao = 22, Observacao = "Delayed" },
                new Link { Hora = new DateTime(2024, 7, 16, 23, 30, 0), Destino = "Atlanta", Compania = "Delta", Voo = 9012, CodigoPassagem = "AT9012", Terminal = 1, Portao = 7, Observacao = "Boarding" },
                new Link { Hora = new DateTime(2024, 7, 16, 14, 30, 0), Destino = "New York", Compania = "Delta", Voo = 1234, CodigoPassagem = "NY1234", Terminal = 1, Portao = 10, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 15, 45, 0), Destino = "Los Angeles", Compania = "American Airlines", Voo = 5678, CodigoPassagem = "LA5678", Terminal = 2, Portao = 15, Observacao = "Delayed" },
                new Link { Hora = new DateTime(2024, 7, 16, 16, 0, 0), Destino = "Chicago", Compania = "United", Voo = 9101, CodigoPassagem = "CH9101", Terminal = 3, Portao = 20, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 17, 30, 0), Destino = "Miami", Compania = "American Airlines", Voo = 2345, CodigoPassagem = "MI2345", Terminal = 1, Portao = 5, Observacao = "Boarding" },
                new Link { Hora = new DateTime(2024, 7, 16, 18, 45, 0), Destino = "San Francisco", Compania = "Delta", Voo = 6789, CodigoPassagem = "SF6789", Terminal = 2, Portao = 8, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 19, 0, 0), Destino = "Seattle", Compania = "Alaska Airlines", Voo = 1123, CodigoPassagem = "SE1123", Terminal = 3, Portao = 12, Observacao = "Delayed" },
                new Link { Hora = new DateTime(2024, 7, 16, 20, 30, 0), Destino = "Boston", Compania = "JetBlue", Voo = 4456, CodigoPassagem = "BO4456", Terminal = 1, Portao = 14, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 21, 45, 0), Destino = "Houston", Compania = "Southwest", Voo = 7890, CodigoPassagem = "HO7890", Terminal = 2, Portao = 17, Observacao = "On time" },
                new Link { Hora = new DateTime(2024, 7, 16, 22, 0, 0), Destino = "Dallas", Compania = "American Airlines", Voo = 3456, CodigoPassagem = "DA3456", Terminal = 3, Portao = 22, Observacao = "Delayed" },
            };

            DataContext = this;
        }

        private void dataGrid_Voos_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = sender as DataGrid;

            if (dataGrid != null)
            {
                if (dataGrid.Columns.Count > 0)
                {
                    dataGrid.Columns[0].Width = 300;
                    dataGrid.Columns[1].Width = 150;
                    dataGrid.Columns[2].Width = 200;
                    dataGrid.Columns[3].Width = 70;
                    dataGrid.Columns[4].Width = 100;
                    dataGrid.Columns[5].Width = 50;
                    dataGrid.Columns[6].Width = 50;
                    dataGrid.Columns[7].Width = 244;
                }
            }
        }
    }

    public class Link
    {
        public DateTime Hora { get; set; }
        public string Destino { get; set; }
        public string Compania { get; set; }
        public int Voo { get; set; }
        public string CodigoPassagem { get; set; }
        public int Terminal { get; set; }
        public int Portao { get; set; }
        public string Observacao { get; set; }
    }
}
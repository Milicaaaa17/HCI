using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Classes;


namespace Z1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BindingList<Francuska> Francuskas { get; set; }
        private DataIO serijalizacija = new DataIO();

        public MainWindow()
        {
            Francuskas = serijalizacija.DeSerializeObject<BindingList<Francuska>>("francuska.xml");
            if(Francuskas is null)
            {
                Francuskas = new BindingList<Francuska>();
            }
            InitializeComponent();
            DataContext = this;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Procitaj_Click(object sender, RoutedEventArgs e)
        {
            Window Opis = new Opis(dataGrid.SelectedIndex);

            Opis.ShowDialog();
        }

        private void Izmijeni_Click(object sender, RoutedEventArgs e)
        {
            if (Francuskas.Count > 0)
            {
                Window Izmijeni = new AddWindow(dataGrid.SelectedIndex);
                Izmijeni.ShowDialog();

            }
            dataGrid.Items.Refresh();

        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if(Francuskas.Count > 0)
            {
                Francuskas.RemoveAt(dataGrid.SelectedIndex);
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Button_Izlaz(object sender, RoutedEventArgs e)
        {

            serijalizacija.SerializeObject<BindingList<Francuska>>(Francuskas, "francuska.xml");
            this.Close();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Z1
{
    /// <summary>
    /// Interaction logic for Opis.xaml
    /// </summary>
    public partial class Opis : Window
    {
        public Opis(int ind)
        {
            string path = "rtb" + ind + ".rtf";
            TextRange range;
            FileStream fStream;

            InitializeComponent();

            range = new TextRange(RichTextBoxOpis.Document.ContentStart, RichTextBoxOpis.Document.ContentEnd);
            fStream = new FileStream(path, FileMode.OpenOrCreate);
            range.Load(fStream, DataFormats.Rtf);
            fStream.Close();
            Znamenitost.Content = MainWindow.Francuskas[ind].Znamenitosti;
            Slika.Source = new BitmapImage(new Uri(MainWindow.Francuskas[ind].PutanjaSlika));

            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

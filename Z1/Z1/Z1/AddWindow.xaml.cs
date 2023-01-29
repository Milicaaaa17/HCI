using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Classes;
using System.IO;

namespace Z1
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {

        bool slikaUspjesno = false;
        string putanjaDoSlike = "";
        int indeks;
        bool edit = false;

        public AddWindow()
        {
            InitializeComponent();
            ComboBoxFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxFontSize.ItemsSource = new List<double> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
           //ComboBoxColor.ItemsSource = new List<string> { new SolidColorBrush(Colors.Black).ToString(), new SolidColorBrush(Colors.Red).ToString() };
            //boja


        }

        public AddWindow(int indeks)
        {
            InitializeComponent();
            this.indeks = indeks;
            Dodaj.Content = "Izmijeni";

            ComboBoxFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            ComboBoxFontSize.ItemsSource = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
           // ComboBoxColor.ItemsSource = new List<string> { new SolidColorBrush(Colors.Black).ToString(), new SolidColorBrush(Colors.Red).ToString()};
            textBoxZnamenitost.Text = MainWindow.Francuskas[indeks].Znamenitosti;
            textBoxUlaznica.Text = MainWindow.Francuskas[indeks].Ulaznica.ToString();
            Datum.SelectedDate = MainWindow.Francuskas[indeks].DatumObilaska;
            Slika.Source = new BitmapImage(new Uri(MainWindow.Francuskas[indeks].PutanjaSlika));

            string putanjaDoRtB = "./rtb" + indeks + ".rtf";

            TextRange range;
            FileStream filestream;

            range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
            filestream = new FileStream(putanjaDoRtB, FileMode.Open);
            range.Load(filestream, DataFormats.Rtf);
            filestream.Close();
            edit = true;
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                
                string putanjaDoRTB = "./rtb" + indeks + ".rtf";
                if (edit == false)
                {
                    MainWindow.Francuskas.Add(new Francuska(textBoxZnamenitost.Text, Convert.ToDouble(textBoxUlaznica.Text), (DateTime)Datum.SelectedDate, putanjaDoSlike, putanjaDoRTB));
               
                }
                else
                {
                    MainWindow.Francuskas[indeks].Znamenitosti = textBoxZnamenitost.Text;
                    MainWindow.Francuskas[indeks].Ulaznica =Convert.ToDouble(textBoxUlaznica.Text);
                    MainWindow.Francuskas[indeks].DatumObilaska =(DateTime)Datum.SelectedDate;
                    if (slikaUspjesno == true)
                    {
                        MainWindow.Francuskas[indeks].PutanjaSlika = putanjaDoSlike;
                    }
                }

                FileStream file = new FileStream(putanjaDoRTB, FileMode.Create);
                TextRange textRange = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);

                textRange.Save(file, DataFormats.Rtf);
                file.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Neispravno ste popunili", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void Button_Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validate()
        {
            bool isValid = true;

            if(textBoxZnamenitost.Text.Trim() == "")
            {
                isValid = false;
                textBoxZnamenitost.BorderBrush = Brushes.Red;
                labelGreskaZnamenitost.Content = "Popunite polje!";
            }
            else
            {
                textBoxZnamenitost.BorderBrush = Brushes.Black;
                labelGreskaZnamenitost.Content = "";
            }

            if (textBoxUlaznica.Text.Trim() == "")
            {
                isValid = false;
                textBoxUlaznica.BorderBrush = Brushes.Red;
                labelGreskaUlaznica.Content = "Popunite polje!";

            }
            else
            {
                textBoxUlaznica.BorderBrush = Brushes.Black;
                labelGreskaUlaznica.Content = "";
            }

            if (textBoxUlaznica.Text.Trim() == "")
            {
                isValid = false;
                textBoxUlaznica.BorderBrush = Brushes.Red;
                labelGreskaUlaznica.Content = "Popunite polje!";
            }
            else
            {
                textBoxUlaznica.BorderBrush = Brushes.Black;

                try
                {
                    Int32.Parse(textBoxUlaznica.Text.Trim());
                }
                catch (Exception exc)
                {
                    textBoxUlaznica.BorderBrush = Brushes.Red;
                    labelGreskaUlaznica.Content = "Neispravno!";
                    Console.WriteLine(exc.Message);
                    isValid = false;
                }
            }


            if(Datum.SelectedDate == null)
            {
                isValid = false;
              labelGreskaDatum.Content = "Popunite polje!";
            }
            else
            {
                labelGreskaDatum.Content = "";
            }

            TextPointer startPointer = RichTextBox.Document.ContentStart.GetNextInsertionPosition(LogicalDirection.Forward);
            TextPointer endPointer = RichTextBox.Document.ContentEnd.GetNextInsertionPosition(LogicalDirection.Backward);
            if (startPointer.CompareTo(endPointer) == 0)
            {
                isValid = false;
                labelGreskaOpis.Content = "Popunite polje!";
                RichTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                labelGreskaOpis.Content = "";
            }

            if (Slika.Source == null)
            {
                isValid = false;
                labelGreskaSlika.Content = "Niste dodali sliku!";
            }
            else
            {
                labelGreskaSlika.Content = "";
            }
            return isValid ;
        }

            private void Button_Browse(object sender, RoutedEventArgs e)
            {

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "Izaberi sliku";
                fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                 "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                 "Portable Network Graphic (*.png)*|.png";

               if (fileDialog.ShowDialog() == true)
               {
                Slika.Source = new BitmapImage(new Uri(fileDialog.FileName));
                putanjaDoSlike = fileDialog.FileName;
                slikaUspjesno = true;
               }
            }

        private void RichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = RichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            ButtonBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ButtonItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            ButtonUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            ComboBoxFontFamily.SelectedItem = temp;

            temp = RichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            ComboBoxFontSize.SelectedItem = temp;

        }

        private void ComboBoxFontSize_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontFamily.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxFontSize.SelectedItem);
            }
        }

      
        private void ComboBoxFontFamily_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontFamily.SelectedItem != null && !RichTextBox.Selection.IsEmpty)
            {
                RichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);
            }
        }

        private void Boja_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!RichTextBox.Selection.IsEmpty)
                {
                    RichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B)));
                }
            }
        }
    }
}

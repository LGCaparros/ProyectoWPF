using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Pelicula> listaPeliculas;
        public MainWindow()
        {
            InitializeComponent();
            listaPeliculas = new ObservableCollection<Pelicula>();
            listaPeliculasListBox.ItemsSource = listaPeliculas;
        }

        private void cargarJSONButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file (*.json)|*.json";
            string json;
            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader r = new StreamReader(openFileDialog.FileName))
                {
                    json = r.ReadToEnd();
                }
                listaPeliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(json);
                listaPeliculasListBox.ItemsSource = listaPeliculas;
            }
            
        }

        private void gurdarJSONButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON file (*.json)|*.json";

            string json = JsonConvert.SerializeObject(listaPeliculas);
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
            }
            
        }

        private void listaPeliculasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gestionarTabItem.DataContext = listaPeliculasListBox.SelectedItem;
            eliminarPeliculaJSON.IsEnabled = true;
        }

        private void añadirPeliculaJSON_Click(object sender, RoutedEventArgs e)
        {
            Pelicula peli = new Pelicula("SInSon","Son amarillos ", @"D:\Emu\PPSSPP\memstick\PSP\SAVEDATA\ULES01372DLCTEX\ICON0.PNG", Pelicula.TipoDificultad.Normal, Pelicula.GenerosCine.CienciaFiccion);
            listaPeliculas.Add(peli);
        }

        private void eliminarPeliculaJSON_Click(object sender, RoutedEventArgs e)
        {
            listaPeliculas.Remove((Pelicula)listaPeliculasListBox.SelectedItem);
        }

        private void pistaPeliculatextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void examinarImagenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imagenPeliculaTextBox.Text = openFileDialog.FileName;
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

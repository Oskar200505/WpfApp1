using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    
    public partial class MainWindow : Window
    {
        //Namnet till mappen på driven samt kalkarket som datan kommer sparas i, detta är i en CSV fil
        public string FileName = "G:/Min enhet/data programmering/Data.csv";
        public MainWindow()
        {
            InitializeComponent();
        }

     
        public void SaveDataToCsv()
        {
            try
            {
                //gör så att datan sparas till csv filen
                using(StreamWriter writer = new StreamWriter(FileName))
                {
                    //på den vänstara sidan så kommer detta finnas
                    writer.WriteLine("Name, Wifes");
                    //på den högra sidan kommer detta visas 
                    writer.WriteLine("Trump, 76");
                }
                //Denna ger en bekräftese att datan är sparad genom att visa de på en liten ruta
                MessageBox.Show("Data Saved");

            }
            catch (Exception ex)
            {
                //Om du får en fel medeldelande så kommer detta text att visas
                MessageBox.Show($"Error Saving Your Data. {ex.Message}");
            }
               
        }
        private void LoadDataFromCSV()
        {
            try
            {
                //Kontrollerar ifall data filen finns 
                if (!File.Exists(FileName))
                {
                    //Detta kommer att visas om det inte finns en fil
                    MessageBox.Show("Error");
                    return;
                }
                //Läser upp datan som finns i filen och delar på det med hjälp av ett kommateckan 
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string headerLine = reader.ReadLine();
                    string dataLine = reader.ReadLine();
                    string[] dataValues = dataLine.Split(',');

                    string name = dataValues[0];
                    int age = int.Parse(dataValues[1]);

                    MessageBox.Show($"Name: {name}\nWifes: {age}");
                }
            }

            catch (Exception ex)
            {
                // om något går fel så kommer detta felmedelande visas
                MessageBox.Show($"Error Loading The Data: {ex.Message}");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Detta gör så när man tycker s så sparas datan 
            if (e.Key == Key.S)
            {
                SaveDataToCsv();
            }
            // och detta gör så att när du trycker L så Laddas datan upp
            else if (e.Key == Key.L)
            {
                LoadDataFromCSV();
            }
        }
    }
}

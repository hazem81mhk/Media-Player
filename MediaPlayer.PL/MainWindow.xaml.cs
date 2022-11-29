using MediaPlayer.BLL;
using MediaPlayer.EL;
using Microsoft.VisualBasic;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayer.PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListManager listManager;
        private List<FileInfo> fileInfos;

        private int SelectedIndexlistBoxShowList;

        private int showListCounter;



        public MainWindow()
        {
            InitializeComponent();
            listManager = new ListManager();
            fileInfos = new List<FileInfo>();

            SelectedIndexlistBoxShowList = -1;

            showListCounter = 0;


        }

        private void OPEN_Click(object sender, RoutedEventArgs e)
        {
            string str = MediaFileTypes.mediaTypeStr;
            if (str.Contains("jpg") || str.Contains("png") || str.Contains("mp4") || str.Contains("Wav"))
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;

                myFilter(str, openFileDialog);

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == true)
                {
                    ListBox.Items.Clear();
                    fileInfos.Clear();
                    foreach (string item in openFileDialog.FileNames)
                    {
                        FileInfo fileInfo = new FileInfo(item);
                        ListBox.Items.Add(fileInfo);
                        fileInfos.Add(fileInfo);
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select the media type! \n\n" + "Click: Settings\n" +
                  "Click: Set media type ", "warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageClose = MessageBox.Show("Do you want to close the program?"
                    , "Closing the program", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageClose == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else if (messageClose == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }


        private void NewShowListClick(object sender, RoutedEventArgs e)
        {
            string message, title, defaultValue, myValue;
            message = "Please write a show list name!";
            title = "New show list";
            defaultValue = DateTime.Now.ToString();
            myValue = Interaction.InputBox(message, title, defaultValue);

            if (myValue != "")
            {
                if (myValue.ToString() == defaultValue)
                {
                    myValue = defaultValue;
                }
                else
                {
                    myValue = myValue.ToString() + " " + defaultValue;
                }

                ShowList show = new ShowList();
                show.Name = myValue;
                listManager.ShowLists.Add(show);
                dataGrid.ItemsSource = null;
                listManager.ShowLists[showListCounter].MediaFiles.Clear();

                listBoxShowList.Items.Add(listManager.ShowLists[showListCounter]);
                SelectedIndexlistBoxShowList = showListCounter;
                showListCounter++;
            }
        }

        private void DeleteShowListClick(object sender, RoutedEventArgs e)
        {
            SelectedIndexlistBoxShowList = listBoxShowList.SelectedIndex;
            if (SelectedIndexlistBoxShowList >= 0)
            {
                dataGrid.ItemsSource = null;

                listManager.ShowLists.RemoveAt(SelectedIndexlistBoxShowList);
                showListCounter--;
                listBoxShowList.Items.Clear();

                for (int i = 0; i < listManager.ShowLists.Count; i++)
                {
                    listBoxShowList.Items.Add(listManager.ShowLists[i]);
                }
            }
            else
            {
                MessageBox.Show("You must select \"a show lest\" to delete!", "Worning!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            SelectedIndexlistBoxShowList = -1;
        }

        private void listBoxShowListSelectedItem(object sender, SelectionChangedEventArgs e)
        {
            SelectedIndexlistBoxShowList = listBoxShowList.SelectedIndex;
            if (SelectedIndexlistBoxShowList >= 0)
            {
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = listManager.ShowLists[SelectedIndexlistBoxShowList].MediaFiles;
            }
        }

        #region MenuItem Set Media type, Information
        private void Choose_Media_Type_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        private void myFilter(string str, OpenFileDialog openFileDialog)
        {
            //One file type
            if (str.Contains("jpg"))
            {
                openFileDialog.Filter = "Photo files(*.jpg)|*.jpg";
            }
            if (str.Contains("png"))
            {
                openFileDialog.Filter = "Photo files(*.png)|*.png";
            }
            if (str.Contains("mp4"))
            {
                openFileDialog.Filter = "Video files (*.mp4)|*.mp4";
            }
            if (str.Contains("Wav"))
            {
                openFileDialog.Filter = "Video files (*.Wav)|*.Wav";
            }

            //Two file types
            if (str.Contains("jpg") && str.Contains("png"))
            {
                openFileDialog.Filter = "Photo files(*.jpg;*.png)|*.jpg;*.png";
            }
            if (str.Contains("jpg") && str.Contains("mp4"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.mp4)|*.jpg;*.mp4";
            }
            if (str.Contains("jpg") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.Wav)|*.jpg;*.Wav";
            }
            if (str.Contains("png") && str.Contains("mp4"))
            {
                openFileDialog.Filter = "Files(*.png;*.mp4)|*.png;*.mp4";
            }
            if (str.Contains("png") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.png;*.Wav)|*.png;*.Wav";
            }
            if (str.Contains("mp4") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Video files (*.mp4; *.Wav)|*.mp4;*.Wav";
            }

            //Three file types
            if (str.Contains("jpg") && str.Contains("png") && str.Contains("mp4"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.png;mp4)|*.jpg;*.png;*.mp4";
            }
            if (str.Contains("jpg") && str.Contains("png") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.png;*.Wav)|*.jpg;*.png;*.Wav";
            }
            if (str.Contains("jpg") && str.Contains("mp4") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.mp4;*.Wav)|*.jpg;*.mp4;*.Wav";
            }
            if (str.Contains("png") && str.Contains("mp4") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.png;*.mp4;*.Wav)|*.png;*.mp4;*.Wav";
            }

            //Four file type
            if (str.Contains("jpg") && str.Contains("png") && str.Contains("mp4") && str.Contains("Wav"))
            {
                openFileDialog.Filter = "Files(*.jpg;*.png;*.mp4;*.Wav)|*.jpg;*.png;*.mp4;*.Wav";
            }
        }

    }
}

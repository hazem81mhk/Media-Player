using MediaPlayer.BLL;
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


        public MainWindow()
        {
            InitializeComponent();
            listManager = new ListManager();

        }


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

        }

    }
}

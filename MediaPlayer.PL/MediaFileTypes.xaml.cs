﻿// Created by: Hazem Kudaimi.
// Date: 23/11/2022

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

namespace MediaPlayer.PL
{
    /// <summary>
    /// Interaction logic for MediaFileTypes.xaml
    /// </summary>
    public partial class MediaFileTypes : Window
    {
        public static string mediaTypeStr = "jpg png mp4 Wav";

        public MediaFileTypes()
        {
            InitializeComponent();
            if (mediaTypeStr.Contains("jpg"))
            {
                jpg.IsChecked = true;
            }
            if (mediaTypeStr.Contains("png"))
            {
                png.IsChecked = true;
            }
            if (mediaTypeStr.Contains("mp4"))
            {
                mp4.IsChecked = true;
            }
            if (mediaTypeStr.Contains("Wav"))
            {
                Wav.IsChecked = true;
            }
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (mediaTypeStr == "")
            {
                MessageBox.Show("You must select the media type", "Warning", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                this.Close();
            }
        }

    }
}

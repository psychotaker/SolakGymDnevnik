﻿using System;
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

namespace SolakGymDnevnik
{
    /// <summary>
    /// Interaction logic for Lista.xaml
    /// </summary>
    public partial class Lista : Window
    {
        public Lista()
        {
            InitializeComponent();
        }

        private void BtnBack_OnClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

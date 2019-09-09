﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _09_09_2019_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataGrid1.ItemsSource = Process.GetProcesses().Select(t =>
                new ProcessModel()
                {
                    Name = t.ProcessName,
                    CountOfStreams = t.HandleCount,
                    Id = t.Id
                });
        }

        private void ButDelProcess_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null) 
                Process.GetProcesses()
        }
    }
}

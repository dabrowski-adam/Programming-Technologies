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
using System.Windows.Shapes;
using PresentationLayer.ViewModel;

namespace PresentationLayer.View
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
        }
        /*protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ViewModel.UpdateWindow _vm = (ViewModel.UpdateWindow)DataContext;
            //_vm.GetPath = () => "Result of the FileOpenDialog";
        }*/
    }
}

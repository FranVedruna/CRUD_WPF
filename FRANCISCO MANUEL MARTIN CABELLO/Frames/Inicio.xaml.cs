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

namespace FRANCISCO_MANUEL_MARTIN_CABELLO.Frames
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Page
    {
        public Inicio()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            List<DBase.Producto> productos = DBase.ObtenerProductos();
            ProductosDataGrid.ItemsSource = productos;
        }
    }
}

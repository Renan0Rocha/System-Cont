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
using System_Cont.Models;
using System_Cont.Views;

namespace System_Cont.Views
{
    /// <summary>
    /// Interação lógica para ListarCliFormPage.xam
    /// </summary>
    public partial class ListarCliFormPage : Page
    {
        public ListarCliFormPage()
        {
            InitializeComponent();
            Loaded += ListarCliFormPage_Loaded;
        }

        private void ListarCliFormPage_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();

                dataGridCliente.ItemsSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExcluirCliente_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridCliente.SelectedItem as Cliente;

            var result = MessageBox.Show($"Deseja realmente excluir o Cliente '{clienteSelected.NomeCliente}'?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();
                    dao.Delete(clienteSelected);
                    CarregarListagem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

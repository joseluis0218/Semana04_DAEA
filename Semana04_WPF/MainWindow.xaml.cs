using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Semana04_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;

            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text));

            }
            catch (Exception ex)
            {

                MessageBox.Show("Comunicarse con el Administrador"+ex);
            }
            finally
            {
                bPedido = null;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int IdPedido = 0;

            BDetallePedido bDetallePedido = null;

            Pedido pedido = null;

            decimal total = 0;
            try
            {
                bDetallePedido = new BDetallePedido();

                pedido = dgvPedido.SelectedItem as Pedido;
                    
                IdPedido = Convert.ToInt32(pedido.IdPedido);

                dgvDetallePedido.ItemsSource = bDetallePedido.GetDetallePedidosPorId(IdPedido);

                txtTotal.Text = Convert.ToString(bDetallePedido.GetDetalleTotalPorId(IdPedido));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Comunicarse con el Administrador " + ex);
            }
            finally
            {
                bDetallePedido = null;

                pedido = null;
            }

        }

    }
}

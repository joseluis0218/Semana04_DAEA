using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BDetallePedido
    {
        private DDetallePedido DDetallePedido = null;

        public List<DetallePedido> GetDetallePedidosPorId(int IdPedido)
        {
            List<DetallePedido> detallePedidos = null;

            try
            {
                DDetallePedido = new DDetallePedido();
                detallePedidos = DDetallePedido.GetDetallePedidos(new Pedido { IdPedido = IdPedido });

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return detallePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<DetallePedido> detallePedidos = null;
            decimal total = 0;
            try
            {
                DDetallePedido = new DDetallePedido();
                detallePedidos = DDetallePedido.GetDetallePedidos(new Pedido { IdPedido = IdPedido });

                foreach (var item in detallePedidos)
                {
                    total = total + item.Cantidad * item.PrecioUnidad - item.Descuento;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DDetallePedido = null;
            }

            return total;
        }
    }
}

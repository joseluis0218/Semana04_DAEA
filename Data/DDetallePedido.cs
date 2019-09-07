using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos(Pedido pedido)
        {
            SqlParameter parameter = null;
            string commandText = string.Empty;

            List<DetallePedido> detallePedidos = null;
            try
            {
                commandText = "USP_Detalle";
                parameter = new SqlParameter("@IdPedido",SqlDbType.Int);
                parameter.Value = pedido.IdPedido;

                detallePedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameter))
                {

                    while (reader.Read())
                    {
                        detallePedidos.Add(new DetallePedido
                        {
                            Pedido = new Pedido { IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0, },
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Cantidad = reader["Cantidad"] != null ? Convert.ToInt32(reader["Cantidad"]) : 0,
                            PrecioUnidad = reader["PrecioUnidad"] != null ? Convert.ToDecimal(reader["PrecioUnidad"]) : 0,
                            Descuento = reader["Descuento"] != null ? Convert.ToDecimal(reader["Descuento"]) : 0,
                        }); ; ;
                    }

                };

            }
            catch (Exception ex )
            {

                throw ex;
            }

            return detallePedidos;
        }
    }
}

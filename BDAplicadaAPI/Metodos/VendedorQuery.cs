using BDAplicadaAPI.DTO;
using Dapper;

namespace BDAplicadaAPI.Metodos
{
    public class VendedorQuery : AccesoDapper
    {
        public VendedorQuery()
        {
            
        }
        public async Task<IQueryable<DTO.Vendedor>> GetVendedores(DateTime fechadesde, DateTime fechahasta, int idvendedor)
        {
            string Query = @"select Nombre,Apellido, Modelo, Comision, Venta 
                                                    From TraerTodasVentasVendedor
                                                    (@FechaDesde,@FechaHasta,@IdVendedor) 
                                                    Order by Venta Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@FechaDesde", fechadesde);
            parameters.Add("@FechaHasta", fechahasta);
            parameters.Add("@IdVendedor", idvendedor);

            var result = await ExecAsyncDapper<DTO.Vendedor>(Query, parameters, System.Data.CommandType.Text);
            return result.AsQueryable();
        }
    }
}

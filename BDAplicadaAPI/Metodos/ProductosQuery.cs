using Dapper;

namespace BDAplicadaAPI.Metodos
{
    public class ProductosQuery : AccesoDapper
    {
        public ProductosQuery()
        {
            
        }
        public async Task<IQueryable<DTO.Producto>> GetProductos()
        {
            string Query = @"select Id,Modelo,Precio from AppStore.dbo.TraerProductos()";
            var parameters = new DynamicParameters();

            var result = await ExecAsyncDapper<DTO.Producto>(Query, parameters, System.Data.CommandType.Text);
            return result.AsQueryable();
        }
    }
}

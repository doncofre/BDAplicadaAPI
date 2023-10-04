using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BDAplicadaAPI.Metodos
{
    public abstract class AccesoDapper
    {
        private readonly string _connString;
        public AccesoDapper()
        {
            _connString = @"Data Source=DONCOFRE\\SQLEXPRESS;Initial Catalog=AppStore;Integrated Security=True;";

        }
        public async Task<IQueryable<T>> ExecAsyncDapper<T>(string query, DynamicParameters parameters, CommandType type)
        {
            var entitys = new List<T>();
            using (SqlConnection cnn = new SqlConnection(_connString))
            {
                try
                {
                    cnn.Open();
                    var entitys2 = await cnn.QueryAsync<T>(query, parameters, null, null, type);
                    entitys = entitys2.ToList();
                    cnn.Close();
                }
                catch (Exception e )
                {
                    var exception = e.Message;
                }
                
            }
            return entitys.AsQueryable();
        }
    }
}

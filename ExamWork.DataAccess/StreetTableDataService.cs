using ExamWork.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamWork.DataAccess
{
    public class StreetTableDataService
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public StreetTableDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ConnectionString;
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ProviderName);
        }

        public List<Street> GetAll()
        {
            var data = new List<Street>();

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Streets";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Guid id = (Guid)dataReader["Id"];
                        string name = dataReader["Name"].ToString();
                        Guid cityId = (Guid)dataReader["CityId"];
                        DateTime creationDate = Convert.ToDateTime(dataReader["CreationDate"]);

                        data.Add(new Street
                        {
                            Id = id,
                            Name = name,
                            CityId = cityId,
                            CreationDate = creationDate,
                        });
                    }
                    dataReader.Close();
                    connection.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    throw;
                }
            }
            return data;
        }

        public void Add(Street street)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "insert into Streets (Id,Name,CityId,CreationDate) values (@Id,@Name,@CityId,@CreationDate)";

                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = street.Id;

                    DbParameter nameParameter = command.CreateParameter();
                    nameParameter.ParameterName = "@Name";
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = street.Name;

                    DbParameter cityIdParameter = command.CreateParameter();
                    cityIdParameter.ParameterName = "@CityId";
                    cityIdParameter.DbType = System.Data.DbType.Guid;
                    cityIdParameter.Value = street.CityId;

                    DbParameter creationDateParameter = command.CreateParameter();
                    creationDateParameter.ParameterName = "@CreationDate";
                    creationDateParameter.DbType = System.Data.DbType.DateTime;
                    creationDateParameter.Value = street.CreationDate;

                    command.Parameters.AddRange(new DbParameter[] { idParameter, nameParameter, cityIdParameter, creationDateParameter/*, deletedDateParameter*/ });

                    var affectrdRows = command.ExecuteNonQuery();

                    if (affectrdRows < 1) throw new Exception("Вставка не удалась");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    throw;
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "update Streets set DeletedDate = GETDATE() WHERE Id = @ID";
                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = id;
                    
                    command.Parameters.AddRange(new DbParameter[] { idParameter });

                    var affectrdRows = command.ExecuteNonQuery();

                    if (affectrdRows < 1) throw new Exception("Удаление не удалось");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    throw;
                }
            }
        }

        public void Update(Coutry coutry)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "update Streets set Name = @Name WHERE Id = @Id";

                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = coutry.Id;

                    DbParameter nameParameter = command.CreateParameter();
                    nameParameter.ParameterName = "@Name";
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = coutry.Name;
                    
                    command.Parameters.AddRange(new DbParameter[] { idParameter, nameParameter });

                    var affectrdRows = command.ExecuteNonQuery();

                    if (affectrdRows < 1) throw new Exception("Обновление не удалось");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                    throw;
                }
            }
        }
    }
}

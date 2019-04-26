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
    public class CityTableDataService
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public CityTableDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ConnectionString;
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ProviderName);
        }

        public List<City> GetAll()
        {
            var data = new List<City>();

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Cities";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Guid id = (Guid)dataReader["Id"];
                        string name = dataReader["Name"].ToString();
                        Guid countryId = (Guid)dataReader["CountryId"];
                        DateTime creationDate = Convert.ToDateTime(dataReader["CreationDate"]);

                        data.Add(new City
                        {
                            Id = id,
                            Name = name,
                            CountryId = countryId,
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

        public void Add(City city)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "insert into Cities (Id,Name,CountryId,CreationDate) values (@Id,@Name,@CountryId,@CreationDate)";

                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = city.Id;

                    DbParameter nameParameter = command.CreateParameter();
                    nameParameter.ParameterName = "@Name";
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = city.Name;

                    DbParameter countryIdParameter = command.CreateParameter();
                    countryIdParameter.ParameterName = "@CountryId";
                    countryIdParameter.DbType = System.Data.DbType.Guid;
                    countryIdParameter.Value = city.CountryId;

                    DbParameter creationDateParameter = command.CreateParameter();
                    creationDateParameter.ParameterName = "@CreationDate";
                    creationDateParameter.DbType = System.Data.DbType.DateTime;
                    creationDateParameter.Value = city.CreationDate;

                    command.Parameters.AddRange(new DbParameter[] { idParameter, nameParameter, countryIdParameter, creationDateParameter/*, deletedDateParameter*/ });

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

                    command.CommandText = "update Cities set DeletedDate = GETDATE() WHERE Id = @ID";
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

        public void Update(City city)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "update Cities set Name = @Name WHERE Id = @Id";

                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = city.Id;

                    DbParameter nameParameter = command.CreateParameter();
                    nameParameter.ParameterName = "@Name";
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = city.Name;
                    
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

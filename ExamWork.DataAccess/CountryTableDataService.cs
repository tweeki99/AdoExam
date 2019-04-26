using ExamWork.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamWork.DataAccess
{
    public class CountryTableDataService
    {
        private readonly string _connectionString;
        private readonly DbProviderFactory _providerFactory;

        public CountryTableDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ConnectionString;
            _providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["mainAppConnectionString"].ProviderName);
        }

        public List<Coutry> GetAll()
        {
            var data = new List<Coutry>();
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Countries";

                    var dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Guid id = (Guid)dataReader["Id"];
                        string name = dataReader["Name"].ToString();
                        DateTime creationDate = Convert.ToDateTime(dataReader["CreationDate"]);

                        data.Add(new Coutry
                        {
                            Id = id,
                            Name = name,
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

        public void Add(Coutry coutry)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();

                    command.CommandText = "insert into Countries (Id,Name,CreationDate) values (@Id,@Name,@CreationDate)";

                    DbParameter idParameter = command.CreateParameter();
                    idParameter.ParameterName = "@Id";
                    idParameter.DbType = System.Data.DbType.Guid;
                    idParameter.Value = coutry.Id;

                    DbParameter nameParameter = command.CreateParameter();
                    nameParameter.ParameterName = "@Name";
                    nameParameter.DbType = System.Data.DbType.String;
                    nameParameter.Value = coutry.Name;

                    DbParameter creationDateParameter = command.CreateParameter();
                    creationDateParameter.ParameterName = "@CreationDate";
                    creationDateParameter.DbType = System.Data.DbType.DateTime;
                    creationDateParameter.Value = coutry.CreationDate;

                    DbParameter deletedDateParameter = command.CreateParameter();
                    deletedDateParameter.ParameterName = "@DeletedDate";
                    deletedDateParameter.DbType = System.Data.DbType.DateTime;
                    deletedDateParameter.Value = coutry.DeletedDate;

                    command.Parameters.AddRange(new DbParameter[] { idParameter, nameParameter, creationDateParameter/*, deletedDateParameter*/ });

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

                    command.CommandText = "update Countries set DeletedDate = GETDATE() WHERE Id = @ID";
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

                    command.CommandText = "update Reciver set Name = @Name WHERE Id = @Id";

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

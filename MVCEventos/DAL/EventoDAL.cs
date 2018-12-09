using MVCEventos.App_Start;
using MVCEventos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCEventos.DAL
{
    public class EventoDAL
    {
        public static void SalvarEvento(Evento evento)
        {
            DbContext DB = new DbContext();
            DB.ConnectionCommand.CommandText =
                        "insert into Evento(Nome,Local,Data) " +
                        "values(@Nome,@Local,@Data)";

            DB.ConnectionCommand.Parameters.Add("@Nome", SqlDbType.VarChar).Value = evento.Nome;
            DB.ConnectionCommand.Parameters.Add("@Local", SqlDbType.VarChar).Value = evento.Local;
            DB.ConnectionCommand.Parameters.Add("@Data", SqlDbType.DateTime).Value = evento.Data;

            DB.Connection.BeginTransaction().Commit();
            Console.WriteLine(DB.ConnectionCommand.ExecuteNonQuery());
            DB.Connection.Close();
        }

        public static void UpdateEvento(Evento evento)
        {
            DbContext DB = new DbContext();
            DB.ConnectionCommand.CommandText =
                        "UPDATE Evento " +
                        "SET Nome = @Nome, Local = @Local, Data = @Data " +
                        "WHERE id = @Id ";

            DB.ConnectionCommand.Parameters.Add("@Nome", SqlDbType.VarChar).Value = evento.Nome;
            DB.ConnectionCommand.Parameters.Add("@Local", SqlDbType.VarChar).Value = evento.Local;
            DB.ConnectionCommand.Parameters.Add("@Data", SqlDbType.DateTime).Value = evento.Data;
            DB.ConnectionCommand.Parameters.Add("@Id", SqlDbType.Int).Value = evento.id;

            DB.Connection.BeginTransaction().Commit();
            Console.WriteLine(DB.ConnectionCommand.ExecuteNonQuery());
            DB.Connection.Close();
        }


        public static void DeleteEvento(Evento evento)
        {
            DbContext DB = new DbContext();
            DB.ConnectionCommand.CommandText =
                        "UPDATE FROM Evento " +
                        "WHERE id = @Id";

            DB.ConnectionCommand.Parameters.Add("@Id", SqlDbType.Int).Value = evento.id;

            DB.Connection.BeginTransaction().Commit();
            Console.WriteLine(DB.ConnectionCommand.ExecuteNonQuery());
            DB.Connection.Close();
        }
    }
}
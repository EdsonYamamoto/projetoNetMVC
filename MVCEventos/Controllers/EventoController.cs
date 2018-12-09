using MVCEventos.App_Start;
using MVCEventos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventos.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }


        // GET: Cadastro
        public ActionResult ViewEvento()
        {
            DbContext DB = new DbContext();
            LocalDatabase.eventos = new List<Evento>();
            DB.ConnectionCommand.CommandText = "select * from Evento";

            SqlDataReader registro = DB.ConnectionCommand.ExecuteReader();
            if(registro.HasRows)

                while (registro.Read())
                {
                    ;
                    Evento evento = new Evento();
                //                if (registro["Nome"] != null)
                evento.Nome = Convert.ToString(registro["Nome"]);
                //                if (registro["Local"] != null)
                evento.Local = Convert.ToString(registro["Local"]);
                //                if(registro["Data"].ToString() != "")
                evento.Data = Convert.ToDateTime(registro["Data"]);

                ;

                LocalDatabase.eventos.Add(evento);
                } ;
            DB.ConnectionCommand.Connection.Close();

            ViewBag.Eventos = LocalDatabase.eventos;

            return View();
        }

        [HttpPost, ActionName("CadastrarEventoPOST")]
        public ActionResult SalvarEvento(Evento evento)
        {
            try
            {
                DbContext DB = new DbContext();
                DB.ConnectionCommand.CommandText = 
                    "insert into Evento(Nome,Local,Data) " +
                    "values(@Nome,@Local,@Data)";

                DB.ConnectionCommand.Parameters.Add("@Nome", SqlDbType.VarChar).Value = evento.Nome;
                DB.ConnectionCommand.Parameters.Add("@Local", SqlDbType.VarChar).Value = evento.Local;
                DB.ConnectionCommand.Parameters.Add("@Data", SqlDbType.DateTime).Value = evento.Data;

                DB.Connection.BeginTransaction().Commit();
                Console.WriteLine (DB.ConnectionCommand.ExecuteNonQuery());
                DB.Connection.Close();
            }
            catch (Exception)
            {
                System.Console.WriteLine("falhou");
                return View(nameof(Cadastro));
                throw;
            }
            return View(nameof(Cadastro));
        }
    }
}
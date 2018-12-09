using MVCEventos.App_Start;
using MVCEventos.DAL;
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

                evento.Nome = Convert.ToString(registro["Nome"]);
                evento.Local = Convert.ToString(registro["Local"]);
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
                EventoDAL.SalvarEvento(evento);
            }
            catch (Exception)
            {
                System.Console.WriteLine("falhou");
                return View(nameof(Cadastro));
                throw;
            }
            return View(nameof(Cadastro));
        }
        [HttpPost, ActionName("EditarEventoPOST")]
        public ActionResult EditarEvento(Evento evento)
        {
            try
            {
                EventoDAL.UpdateEvento(evento);
            }
            catch (Exception)
            {
                System.Console.WriteLine("falhou");
                return View(nameof(Cadastro));
                throw;
            }
            return View(nameof(Cadastro));
        }
        [HttpPost, ActionName("DeletarEventoPOST")]
        public ActionResult DeletarEvento(Evento evento)
        {
            try
            {
                EventoDAL.DeleteEvento(evento);
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
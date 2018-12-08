using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime Horario { get; set; }
    }
}
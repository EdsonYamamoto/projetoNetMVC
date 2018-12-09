namespace MVCEventos.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Evento
    {
        // Your context has been configured to use a 'Evento' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCEventos.Models.Evento' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Evento' 
        // connection string in the application configuration file.
        public Evento()
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public int id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
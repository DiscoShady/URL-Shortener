namespace Url_Shortener.Models {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UrlDbContext : DbContext {
        // Your context has been configured to use a 'UrlDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Url_Shortener.Models.UrlDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UrlDbContext' 
        // connection string in the application configuration file.
        public UrlDbContext()
            : base("name=UrlDbContext") {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Url> Urls { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
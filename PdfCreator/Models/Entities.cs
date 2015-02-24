using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace PdfCreator.Models
{
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new DocumentMapping());
            modelBuilder.Configurations.Add(new ElementMapping());
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Element> Elements { get; set; }
    }
}
namespace Proiect
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    /**
     * class automatically generated by entity framework
     */
    public partial class TheatreDB : DbContext
    {
        public TheatreDB()
            : base("name=TheatreDB1")
        {
        }

        public virtual DbSet<play> Plays { get; set; }
        public virtual DbSet<Re> Res { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

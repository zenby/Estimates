namespace DAL_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Estimate : DbContext
    {
        public DB_Estimate()
            : base("name=DB_Estimate")
        {
        }

        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ListOfTheWorks> ListOfTheWorks { get; set; }
        public virtual DbSet<WorkTypes> WorkTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>()
                .Property(e => e.NameOfTheObject)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.InvNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .Property(e => e.ContractNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Building>()
                .HasMany(e => e.ListOfTheWorks)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Organization)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.BankAccount)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Contract)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                .Property(e => e.ContractNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Contract>()
                .HasMany(e => e.Building)
                .WithRequired(e => e.Contract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkTypes>()
                .Property(e => e.WorkType)
                .IsUnicode(false);

            modelBuilder.Entity<WorkTypes>()
                .HasMany(e => e.ListOfTheWorks)
                .WithRequired(e => e.WorkTypes)
                .WillCascadeOnDelete(false);
        }
    }
}

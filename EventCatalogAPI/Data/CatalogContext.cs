using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<SubCatagory> SubCatagories { get; set; }
        public DbSet<Event> Events { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Catagory>(ConfigureCatagory);
            builder.Entity<SubCatagory>(ConfigureSubCatagory);
            builder.Entity<Event>(ConfigureEvent);
            


        }

        private void ConfigureEvent(
              EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.Property(c => c.EventID)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("Event_hilo");
            builder.Property(c => c.EventName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.EventStartDate)
                .IsRequired();
            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Fee)
                .IsRequired();
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.EventStartTime)
                .IsRequired();
            builder.Property(c => c.EventEndDate)
                .IsRequired();
            builder.Property(c => c.EventEndTime)
                .IsRequired();


            // Foreign key

            builder.HasOne(c => c.Catagory)
                 .WithMany()
                 .HasForeignKey(c => c.EventCategoryId);

            builder.HasOne(c => c.SubCatagory)
                .WithMany()
                .HasForeignKey(c => c.EventSubCatagoryId);


        }
        private void ConfigureCatagory(
            EntityTypeBuilder<Catagory> builder)
        {
            builder.ToTable("Catagory");
            builder.Property(c => c.CatagoryID)
               .ForSqlServerUseSequenceHiLo("Catagory_hilo")
                .IsRequired();
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureSubCatagory(
            EntityTypeBuilder<SubCatagory> builder)
        {
            builder.ToTable("SubCatagory");
            builder.Property(c => c.SubCatagoryID)
                .ForSqlServerUseSequenceHiLo("SubCatagory_hilo")
                .IsRequired();
            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
       
    }
}


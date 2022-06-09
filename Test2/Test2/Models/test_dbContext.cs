using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test2.Models
{
    public partial class test_dbContext : DbContext
    {
        public test_dbContext()
        {
        }

        public test_dbContext(DbContextOptions<test_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityDict> CityDicts { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Plane> Planes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s22168;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDict>(entity =>
            {
                entity.HasKey(e => e.IdCityDict)
                    .HasName("CityDict_pk");

                entity.ToTable("CityDict");

                entity.Property(e => e.IdCityDict).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.IdFlight)
                    .HasName("Flight_pk");

                entity.ToTable("Flight");

                entity.Property(e => e.IdFlight).ValueGeneratedNever();

                entity.Property(e => e.Comments).HasMaxLength(200);

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdCityDictNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.IdCityDict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flight_CityDict");

                entity.HasOne(d => d.IdPlaneNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.IdPlane)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Flight_Plane");

                entity.HasMany(d => d.IdPassengers)
                    .WithMany(p => p.IdFlights)
                    .UsingEntity<Dictionary<string, object>>(
                        "FlightPassenger",
                        l => l.HasOne<Passenger>().WithMany().HasForeignKey("IdPassenger").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Table_4_Passenger"),
                        r => r.HasOne<Flight>().WithMany().HasForeignKey("IdFlight").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Table_4_Flight"),
                        j =>
                        {
                            j.HasKey("IdFlight", "IdPassenger").HasName("Flight_Passenger_pk");

                            j.ToTable("Flight_Passenger");
                        });
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.IdPassenger)
                    .HasName("Passenger_pk");

                entity.ToTable("Passenger");

                entity.Property(e => e.IdPassenger).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(60);

                entity.Property(e => e.PassportNum).HasMaxLength(20);
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.IdPlane)
                    .HasName("Plane_pk");

                entity.ToTable("Plane");

                entity.Property(e => e.IdPlane).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

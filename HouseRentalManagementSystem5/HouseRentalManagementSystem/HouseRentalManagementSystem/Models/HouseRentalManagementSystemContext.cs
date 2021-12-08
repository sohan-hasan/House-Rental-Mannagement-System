using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Models
{
    public class HouseRentalManagementSystemContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HouseRentalManagementSystemContext(DbContextOptions<HouseRentalManagementSystemContext> options)
              : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<ApartmentBooking> ApartmentBookings { get; set; }
        public virtual DbSet<ApartmentBuilding> ApartmentBuildings { get; set; }
        public virtual DbSet<ApartmentWiseFacility> ApartmentWiseFacilities { get; set; }
        public virtual DbSet<RefApartmentFacility> RefApartmentFacilities { get; set; }
        public virtual DbSet<RefApartmentType> RefApartmentTypes { get; set; }
        public virtual DbSet<RefBookingStatus> RefBookingStatuses { get; set; }
        public virtual DbSet<ViewUnitStatus> ViewUnitStatuses { get; set; }
        public virtual DbSet<ApartmentImage> ApartmentImages { get; set; }
        public virtual DbSet<BookingPayment> BookingPayments { get; set; }
        public virtual DbSet<SecurityDeposit> SecurityDeposites { get; set; }
        public virtual DbSet<Tenant> Tenantes { get; set; }
        public virtual DbSet<RefPaymentType> RefPaymentTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().HasMany(e => e.ApartmentBookings).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Apartment>().HasMany(e => e.ViewUnitStatuses).WithOne(e => e.Apartment).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder); 
            //modelBuilder.Seed();
        }

    }
}

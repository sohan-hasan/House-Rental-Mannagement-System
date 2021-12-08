using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.Models
{
    public class Apartment
    {
        [Key]
        public int AptId { get; set; }

        [Required, MaxLength(50)]
        public string ApartmentName { get; set; }
        [Required]
        public int BuildingId { get; set; }

        [Required]
        public int AptTypeCode { get; set; }

        [Required]
        public int BathroomCount { get; set; }

        [Required]
        public int BedroomCount { get; set; }

        [Required]
        public int RoomCount { get; set; }

        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal MonthlyRent { get; set; }
        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal SecurityDepositAmount { get; set; }
        [MaxLength(255)]
        public string OtherApartmentDetails { get; set; }

        [ForeignKey("AptTypeCode")]
        public virtual RefApartmentType RefApartmentType { get; set; }
        [ForeignKey("BuildingId")]
        public virtual ApartmentBuilding Building { get; set; }
        public virtual ICollection<ApartmentBooking> ApartmentBookings { get; set; }
        public virtual ICollection<ApartmentWiseFacility> ApartmentWiseFacilities { get; set; }
        public virtual ICollection<ApartmentImage> ApartmentImages { get; set; }
        public virtual ICollection<ViewUnitStatus> ViewUnitStatuses { get; set; }
    }
    public class ApartmentBooking
    {
        [Key]
        public int AptBookingId { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        public int AptId { get; set; }

        [Required]
        public int TenantId { get; set; }

        [Required]
        public int BookingStatusCode { get; set; }

        [Required]
        public DateTime BookingStartDate { get; set; }

        [Required]
        public DateTime BookingEndDate { get; set; }

        [MaxLength(255)]
        public string OtherBookingDetails { get; set; }


        [ForeignKey("AptId")]
        public virtual Apartment Apartment { get; set; }
        [ForeignKey("BuildingId")]
        public virtual ApartmentBuilding ApartmentBuilding { get; set; }

        [ForeignKey("BookingStatusCode")]
        public virtual RefBookingStatus RefBookingStatus { get; set; }
        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }
        public virtual ICollection<SecurityDeposit> SecurityDeposites { get; set; }
        public virtual ICollection<BookingPayment> BookingPayments { get; set; }
        public virtual ICollection<ViewUnitStatus> ViewUnitStatuses { get; set; }
    }
    public class ApartmentBuilding
    {
        [Key]
        public int BuildingId { get; set; }

        [Required, MaxLength(15)]
        public string BuildingShortName { get; set; }

        [Required, MaxLength(80)]
        public string BuildingFullName { get; set; }

        [Required, MaxLength(255)]
        public string BuildingDescription { get; set; }

        [Required, MaxLength(255)]
        public string BuildingAddress { get; set; }

        [Required, MaxLength(50)]
        public string BuildingManager { get; set; }

        [Required, MaxLength(20)]
        public string BuildingPhone { get; set; }

        [MaxLength(255)]
        public string OtherBuildingDetails { get; set; }

        public string ImageName { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
        public virtual ICollection<ApartmentBooking> ApartmentBookings { get; set; }
    }
    public class ApartmentImage
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public int AptId { get; set; }

        [ForeignKey("AptId")]
        public virtual Apartment Apartment { get; set; }
    }
    public class ApartmentWiseFacility
    {

        [Key]
        public int ApartmentWiseFacilityId { get; set; }

        [Required]
        public int AptId { get; set; }

        [Required]
        public int FacilityCode { get; set; }
        [Required]
        public bool IsChecked { get; set; }

        [ForeignKey("AptId")]
        public virtual Apartment Apartment { get; set; }

        [ForeignKey("FacilityCode")]
        public virtual RefApartmentFacility RefApartmentFacility { get; set; }
    }
    public class Tenant
    {
        [Key]
        public int TenantId { get; set; }

        [Required, MaxLength(80)]
        public string TenantFirstName { get; set; }

        [Required, MaxLength(80)]
        public string TenantLastName { get; set; }

        [Required,MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(10)]
        public string GenderCode { get; set; }

        [MaxLength(255)]
        public string OtherTenantDetails { get; set; }
        public string ImageName { get; set; }
        public string ImageFullPath { get; set; }

        public virtual ICollection<ApartmentBooking> ApartmentBookings { get; set; }
    }
    public class RefApartmentFacility
    {
        [Key]
        public int FacilityCode { get; set; }

        [Required, MaxLength(255)]
        public string FacilityDescription { get; set; }

        public virtual ICollection<ApartmentWiseFacility> ApartmentWiseFacilities { get; set; }
    }
    public class RefApartmentType
    {
        [Key]
        public int AptTypeCode { get; set; }

        [Required, MaxLength(255)]
        public string AptTypeDescription { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
    public class RefBookingStatus
    {

        [Key]
        public int BookingStatusCode { get; set; }

        [Required, MaxLength(255)]
        public string BookingStatusDescription { get; set; }

        public virtual ICollection<ApartmentBooking> ApartmentBookings { get; set; }
    }
    public class ViewUnitStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        public int AptId { get; set; }

        [Required]
        public int AptBookingId { get; set; }

        [Required]
        public DateTime StatusDate { get; set; }

        [Required, MaxLength(10)]
        public string AvailableYn { get; set; }

        [ForeignKey("AptId")]
        public virtual Apartment Apartment { get; set; }

        [ForeignKey("AptBookingId")]
        public virtual ApartmentBooking ApartmentBooking { get; set; }
        
    }
    
    public class BookingPayment
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal PaymemtAmount { get; set; }

        [Required]
        public int AptBookingId { get; set; }
        [ForeignKey("AptBookingId")]
        public virtual ApartmentBooking ApartmentBooking { get; set; }
        [ForeignKey("PaymentTypeId")]
        public virtual RefPaymentType RefPaymentType { get; set; }
    }
    public class RefPaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required, MaxLength(50)]
        public string PaymentTypeDetails { get; set; }
        public virtual ICollection<BookingPayment> BookingPayments { get; set; }
    }
    public class SecurityDeposit
    {
        [Key]
        public int DepositPaymentId { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DepositAmount{ get; set; }

        [Required]
        public int AptBookingId { get; set; }
        [ForeignKey("AptBookingId")]
        public virtual ApartmentBooking ApartmentBooking { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, string jsonData) : base(roleName)
        {
            base.Name = roleName;

            this.JsonData = jsonData;
        }

        [Display(Name = "JsonData")]
        public string JsonData { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public ApplicationUser(string userName) : base(userName) { }
        public ApplicationUser(string userName, string firstName, string lastName, string imageName) : base(userName)
        {
            base.UserName = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ImageName = imageName;
        }
        [Required, MaxLength(80)]
        public string FirstName { get; set; }

        //[Required, MaxLength(80)]
        public string LastName { get; set; }

        public string ImageName { get; set; }

    }
}

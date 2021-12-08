using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HouseRentalManagementSystem.UserViewModels
{
    public class ApartmentBuildingViewModel
    {
        [Key]
        public int BuildingId { get; set; }

        [Display(Name = "Building Short Name"), DataType(DataType.Text), Required(ErrorMessage = "Building Shor Name is required"), MaxLength(15, ErrorMessage = "Building short name must be within 15 letter")]
        public string BuildingShortName { get; set; }

        [Display(Name = "Building Full Name"), DataType(DataType.Text), Required(ErrorMessage = "Building Name is required"), MaxLength(80, ErrorMessage = "Building name must be within 80 letter")]
        public string BuildingFullName { get; set; }

        [Display(Name = "Building Description"), DataType(DataType.Text), Required(ErrorMessage = "Description is required"), MaxLength(255, ErrorMessage = "Description must be within 255 letter")]
        public string BuildingDescription { get; set; }

        [Display(Name = "Building Address"), DataType(DataType.Text), Required(ErrorMessage = "Address is required"), MaxLength(255, ErrorMessage = "Address must be within 255 letter")]
        public string BuildingAddress { get; set; }

        [Display(Name = "Building Manager"), DataType(DataType.Text), Required(ErrorMessage = "Manager name is required"), MaxLength(50, ErrorMessage = "Manager Name must be within 50 letter")]
        public string BuildingManager { get; set; }

        [Display(Name = "Building Phone"), DataType(DataType.Text), Required(ErrorMessage = "Phone number is required"), MaxLength(20, ErrorMessage = "Phone number must be within 20 letter")]
        public string BuildingPhone { get; set; }

        [Display(Name = "Other Building Details"), DataType(DataType.Text), MaxLength(255, ErrorMessage = "Other Details must be within 255 letter")]
        public string OtherBuildingDetails { get; set; }

        [Display(Name = "Building Image")]
        public string ImageName { get; set; }

        [Display(Name = "Building Image")]
        public IFormFile Photo { get; set; }
        public int SirialNumber { get; set; }
        public virtual ApartmentBuildingViewModelMultipleInsert ApartmentBuildingViewModelMultipleInsert { get; set; }
    }
    public class ApartmentBuildingViewModelMultipleInsert
    {
        public virtual IList<ApartmentBuildingViewModel> ApartmentBuildingViewModels { get; set; }

    }
    public class ApartmentViewModel
    {
        [Key]
        public int AptId { get; set; }

        [Display(Name = "Building Id"), DataType(DataType.Text), Required(ErrorMessage = "Building Id is required")]
        public int BuildingId { get; set; }

        [Display(Name = "Apartment Type Code"), DataType(DataType.Text), Required(ErrorMessage = "Apartment Type Code is required")]
        public int AptTypeCode { get; set; }

        [Display(Name = "Apartment Name"), DataType(DataType.Text), Required(ErrorMessage = "Apartment Name is required"), MaxLength(50, ErrorMessage = "Apartment Name must be within 50 Letter")]
        public string ApartmentName { get; set; }

        [Display(Name = "Number of Bathroom"), DataType(DataType.Text), Required(ErrorMessage = "Number of Bathroom is required")]
        public int BathroomCount { get; set; }

        [Display(Name = "Number of Bedroom"), DataType(DataType.Text), Required(ErrorMessage = "Number of Bedroom is required")]
        public int BedroomCount { get; set; }

        [Display(Name = "Number of Room"), DataType(DataType.Text), Required(ErrorMessage = "Number of Room is required")]
        public int RoomCount { get; set; }

        [Display(Name = "Monthly Rent"), DataType(DataType.Text)]
        public decimal MonthlyRent { get; set; }

        [Display(Name = "Security Deposit Amount"), DataType(DataType.Text) ]
        public decimal SecurityDepositAmount { get; set; }
        [Display(Name = "Other Apartment Details"), DataType(DataType.Text), MaxLength(255, ErrorMessage = "Other Apartment Details must be within 255 Letter")]
        public string OtherApartmentDetails { get; set; }
        public string BuildingShortName { get; set; }
        public string AptTypeDescription { get; set; }
        public int SirialNumber { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<IFormFile> Edit_Photos { get; set; }
        [Display(Name = "Apartment Images")]
        public string ImageName { get; set; }
        public int [] FacilityCode { get; set; }
        public string FacilityDescription { get; set; }

    }
    public class ApartmentImageViewModel
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public int AptId { get; set; }
    }
    public class ApartmentTypeViewModel
    {
        [Key]
        public int AptTypeCode { get; set; }

        [Required, MaxLength(255)]
        public string AptTypeDescription { get; set; }
        public int SirialNumber { get; set; }
    }
    public class TenantViewModel
    {
        [Key]
        public int TenantId { get; set; }

        [Display(Name = "First Name"), DataType(DataType.Text), Required(ErrorMessage = "First Name is required"), MaxLength(80, ErrorMessage = "First Name must be within 50 Letter")]
        public string TenantFirstName { get; set; }

        [Display(Name = "Last Name"), DataType(DataType.Text), Required(ErrorMessage = "Last Name is required"), MaxLength(80, ErrorMessage = "Last Name must be within 50 Letter")]
        
        public string TenantLastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Plase, enter your Phone Number !")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Plase, enter your Email Address !")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Display(Name = "Date Of Birth"), DataType(DataType.Date), Required(ErrorMessage = "Date Of Birth is required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender Code"), DataType(DataType.Text), MaxLength(10, ErrorMessage = "Gender Code must be within 10 Letter")]
        public string GenderCode { get; set; }

        [Display(Name = "Tenant Details"), MaxLength(255, ErrorMessage = "Tenant Details must be within 255 Letter")]
        public string OtherTenantDetails { get; set; }
        [Display(Name = "Tenant Image")]
        public string ImageName { get; set; }

        public string ImageFullPath { get; set; }
        [Display(Name = "Tenant Image")]
        public IFormFile Photo { get; set; }
        [Display(Name = "Sirial Number")]
        public int SirialNumber { get; set; }
        [Display(Name = "Tenant Name")]
        public string TenantFullName { get; set; }
        [Display(Name = "Gender")]
        public string GenderProperty { get; set; }
        [Display(Name = "Gender")]
        public string GenderCreate { get; set; }

    }
    public class ApartmentBookingViewModel
    {
        [Key]
        public int AptBookingId { get; set; }

        [Display(Name = "Building Id"), DataType(DataType.Text), Required(ErrorMessage = "Building Id is required")]
        public int BuildingId { get; set; }

        [Display(Name = "Building Name"), DataType(DataType.Text)]
        public string BuildingShortName { get; set; }
        [Display(Name = "Apartment Id"), DataType(DataType.Text), Required(ErrorMessage = "Apartment Id is required")]
        public int AptId { get; set; }
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Display(Name = "Tenant Id"), DataType(DataType.Text), Required(ErrorMessage = "Tenant Id is required")]
        public int TenantId { get; set; }

        [Display(Name = "Tenant Name")]
        public string TenantFullName { get; set; }

        [Display(Name = "Booking Status Code"), DataType(DataType.Text)]
        public int BookingStatusCode { get; set; }
        [Display(Name = "Booking Status")]
        public string BookingStatusDescription { get; set; }

        [Display(Name = "Booking Start Date"), DataType(DataType.Date), Required(ErrorMessage = "Booking Start Date is required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BookingStartDate { get; set; }

        [Display(Name = "Booking End Date"), DataType(DataType.Date), Required(ErrorMessage = "Booking End Date is required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BookingEndDate { get; set; }

        [MaxLength(255, ErrorMessage = "Booking Details must be within 255 letter")]
        public string OtherBookingDetails { get; set; }
        public int SirialNumber { get; set; }

        [Display(Name = "Monthly Rent")]
        public decimal MonthlyRent { get; set; }

        [Display(Name = "Security Deposit Amount")]
        public decimal SecurityDepositAmount { get; set; }
        [Display(Name = "Deposit Return Date"), DataType(DataType.Date), Required(ErrorMessage = "Return Date is required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}"),Compare("BookingEndDate", ErrorMessage ="Booking End Date and Return Diposite Amount Will be Same")]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Payment Type Id"), Required(ErrorMessage ="Payment Type id is Required")]
        public int PaymentTypeId { get; set; }

        [Display(Name = "Payment Type Details")]
        public string PaymentTypeDetails { get; set; }

        [Display(Name = "Payment Date"), DataType(DataType.Date), Required(ErrorMessage = "Payment Date is required"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Paymemt Amount"), Required(ErrorMessage ="Payment Amount is required")]
        public decimal PaymemtAmount { get; set; }

        public DateTime StatusDate { get; set; }

        [MaxLength(10)]
        public string AvailableYn { get; set; }
        public int PaymentId { get; set; }
    }
    public class BookingStatusViewModel
    {

        [Key]
        public int BookingStatusCode { get; set; }

        [Required, MaxLength(255)]
        public string BookingStatusDescription { get; set; }

        public int SirialNumber { get; set; }

    }
    public class ApartmentFacilityViewModel
    {
        [Key]
        public int FacilityCode { get; set; }

        [Required(ErrorMessage ="Apartment Facilities Discription Required"), MaxLength(255,ErrorMessage ="Apartment Facilities must be with in 255 charecter")]
        public string FacilityDescription { get; set; }

        public int SirialNumber { get; set; }
    }
    public class ApartmentWiseFacilityViewModel
    {

        [Key]
        public int ApartmentWiseFacilityId { get; set; }

        [Required(ErrorMessage ="Apartment Id is required")]
        public int AptId { get; set; }

        [Required(ErrorMessage = "Facility Code is required")]
        public int FacilityCode { get; set; }

        [Required]
        public bool IsChecked { get; set; }
        public string FacilityDescription { get; set; }

    }
    public class PaymentTypeViewModel
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required(ErrorMessage ="Payment Type Details is required"), MaxLength(50,ErrorMessage ="Payment Type Discription must be within 50 letter")]
        public string PaymentTypeDetails { get; set; }
        public int SirialNumber { get; set; }
    }
    public class ViewUnitStatusViewModel
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
        public int SirialNumber { get; set; }
    }
    public class BookingPaymentViewModel
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
        public int SirialNumber { get; set; }
    }
    public class SecurityDepositViewModel
    {
        [Key]
        public int DepositPaymentId { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required, Column(TypeName = "decimal(16, 2)")]
        public decimal DepositAmount { get; set; }

        [Required]
        public int AptBookingId { get; set; }
        public int SirialNumber { get; set; }
    }
}

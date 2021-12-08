using HouseRentalManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HouseRentalManagementSystem.SecurityViewModel
{
    public class UserModelView
    {
        [Display(Name = "User Id")]
        [Key]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please, enter your first name !")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please, enter your Last name !")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please, enter a user name !")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Plase, enter your Phone Number !")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Plase, enter your Email Address !")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Plase, enter your a password !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm")]
        [Required(ErrorMessage = "Plase, repeat your password !")]
        [Compare("Password", ErrorMessage = "Error comparing password and password confirm values")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }

        [Display(Name = "User Image")]
        public string ImageName { get; set; }

        [Display(Name = "User Image")]
        public string ImageUrl { get; set; }
        [Display(Name ="Remamber Me")]
        public bool IsChecked { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class LoginViewModel
    {
        [Required]

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsChecked { get; set; }
    }
    public class UserRolesViewModel
    {
        [Display(Name = "Role Id")]
        [Key]
        public string RoleId { get; set; }

        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Please, enter Role Name !")]
        [DataType(DataType.Text)]
        public string RoleName { get; set; }
        [Display(Name = "Json Data")]
        [Required(ErrorMessage = "Please, enter Json Data !")]
        [DataType(DataType.Text)]
        public string JsonData { get; set; }
        public bool Selected { get; set; }
        public List<string> Users { get; set; }
    }
    public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
    public class UserWiseRoleViewModel
    {
        [Display(Name = "User  Id")]
        [Key]
        public int uwrId { get; set; }

        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "User Image")]
        public string ImageName { get; set; }

        [Display(Name = "User Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}

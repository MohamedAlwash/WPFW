using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace SecurityApplication.Models
{
    public class Teacher : IdentityUser
    {
        public int ID { get; set; }
    }

}
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace SecurityApplication.Models
{
    public class Student : IdentityUser
    {
        public int ID { get; set; }
    }
}
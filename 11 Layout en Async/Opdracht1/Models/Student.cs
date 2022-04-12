using FluentValidation;

namespace Opdracht1.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public int Score { get; set; }
        public ICollection<Student>? Friends { get; set; }

    }

    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().MaximumLength(30).WithMessage("Please specify a first name (maximum length 30)");
            RuleFor(s => s.LastName).NotEmpty().MaximumLength(30).WithMessage("Please specify a last name (maximum length 30)");
            RuleFor(s => s.Email).NotEmpty().EmailAddress().WithMessage("Please specify a email address");
            RuleFor(s => s.Age).NotEmpty().GreaterThan(0).LessThan(100).WithMessage("Please specify your age");
            RuleFor(s => s.Score).NotEmpty().LessThan(10).WithMessage("Please specify your score (Less than 10)");
        }
    }
}
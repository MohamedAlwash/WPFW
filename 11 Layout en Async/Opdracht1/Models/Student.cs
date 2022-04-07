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
        public List<Student>? Friends { get; set; }

    }

    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().MaximumLength(30).WithMessage("Please specify a first name (maximum length 30)");
            RuleFor(s => s.LastName).NotEmpty().MaximumLength(30).WithMessage("Please specify a last name (maximum length 30)");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Please specify a email address");
            RuleFor(s => s.Age).NotEmpty().WithMessage("Please specify your age");
            RuleFor(s => s.Score).NotEmpty().WithMessage("Please specify your score");
            RuleFor(s => s.Friends).NotEmpty().WithMessage("Please specify a friend");
        }
    }
}
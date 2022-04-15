using FluentValidation;

namespace SecurityApplication.Models
{
    public class TestResult
    {
        public int ID { get; set; }
        public string? StudentName { get; set; }
        public int? Number { get; set; }
    }

    public class TestResultValidator : AbstractValidator<TestResult>
    {
        public TestResultValidator()
        {
            RuleFor(s => s.StudentName).NotNull().WithMessage("Please specify a student name");
            RuleFor(s => s.Number).NotNull().WithMessage("Please specify a number");
        }
    }
}
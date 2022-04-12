using Opdracht1.Data;
using Opdracht1.Models;

namespace Opdracht1.ViewModel
{
    public class Rank
    {
        private readonly MyDbContext _context;

        public Rank(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> Top3Students()
        {
            return _context.Students.OrderBy(s => s.Score).Take(3);
        }
    }
}
using Quiz.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Data.Comman
{
    public class QuizRepository : Repository, IQuizzRepository
    {
        public QuizRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}

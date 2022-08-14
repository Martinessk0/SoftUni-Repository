using Quiz.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Contracts
{
    public interface IQuizServices
    {
        Task<IEnumerable<QuizViewModel>> GetQuizzesAsync();
        Task CreateQuizAsync(QuizViewModel model);
        Task<QuizViewModel> GetQuizzAsync(int id);
        Task EditQuizzAsync(QuizViewModel model);
    }
}

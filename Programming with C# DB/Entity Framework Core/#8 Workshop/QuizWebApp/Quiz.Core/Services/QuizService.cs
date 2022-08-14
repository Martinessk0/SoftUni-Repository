using Microsoft.EntityFrameworkCore;
using Quiz.Core.Contracts;
using Quiz.Core.Models;
using Quiz.Infrastructure.Data.Comman;
using Quiz.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Core.Services
{
    public class QuizService : IQuizServices
    {
        private readonly IQuizzRepository repo;
        public QuizService(IQuizzRepository _repo)
        {
            repo = _repo;
        }

        public async Task CreateQuizAsync(QuizViewModel model)
        {
            Quizz quiz = new Quizz()
            {
                Name = model.Name,
            };

            await repo.AddAsync(quiz);
            await repo.SaveChangesAsync();
        }

        public async Task EditQuizzAsync(QuizViewModel model)
        {
            var quizz = await repo.GetByIdAsync<Quizz>(model.Id);
            if (quizz == null)
            {
                throw new ArgumentException("Invalid Quizz ID");
            }

            quizz.Name = model.Name;

            await repo.SaveChangesAsync();
        }

        public async Task<QuizViewModel> GetQuizzAsync(int id)
        {
            var quizz = await repo.GetByIdAsync<Quizz>(id);
            return new QuizViewModel()
            {
                Id = quizz.Id,
                Name = quizz.Name
            };
        }

        public async Task<IEnumerable<QuizViewModel>> GetQuizzesAsync()
        {
            return await repo.AllReadonly<Quizz>()
                .Select(x => new QuizViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToListAsync();
        }
    }
}

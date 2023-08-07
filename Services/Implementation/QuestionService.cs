using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Models;
using EConfirm.Repositories.Interface;
using EConfirm.Services.Interfaces;
using EConfirm.ViewModels;

namespace EConfirm.Services.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _repository;

        public QuestionService(IRepository<Question> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(QuestionDTO model)
        {
            var question = new Question { Label = model.Label };
            await _repository.Create(question);
            return await _repository.SaveChangesAsync();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<QuestionDTO> GetAll()
        {
            return _repository.GetAll().Select(q => new QuestionDTO { Label = q.Label, Id = q.Id }).ToList();
        }

        public Task Update(QuestionDTO model)
        {
            throw new NotImplementedException();
        }
    }
}

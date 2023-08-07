using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Models;
using EConfirm.ViewModels;

namespace EConfirm.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<bool> Create(QuestionDTO model);
        Task<Question> Get(Guid id);
        List<QuestionDTO> GetAll();
        Task Update(QuestionDTO model);
        Task Delete(Guid id);
    }
}

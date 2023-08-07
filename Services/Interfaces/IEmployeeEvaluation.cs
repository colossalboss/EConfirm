using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Models;
using EConfirm.ViewModels;

namespace EConfirm.Services.Interfaces
{
    public interface IEmployeeEvaluation
    {
        Task<EmployeeEvaluation> CreateEvaluation(EmployeeEvaluationDTO model);
        Task<EmployeeEvaluation> Get(Guid id);
        List<EmployeeEvaluation> GetAll();
        Task<bool> UpdateEvaluationAnswers(QuestionAnswersDTO model);
        Task Delete(Guid id);
        Task<bool> UpdateEvaluationStatus(AcceptOrRejectEvaluationDTO model);
    }
}

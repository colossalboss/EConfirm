using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Models;
using EConfirm.Repositories.Interface;
using EConfirm.Services.Interfaces;
using EConfirm.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EConfirm.Services.Implementation
{
    public class EmployeeEvaluationService : IEmployeeEvaluation
    {
        private readonly IRepository<EmployeeEvaluation> _evaluationRepository;
        private readonly IRepository<Question> _questionRepository;
        private readonly IRepository<QuestionAnswer> _questionAnswerRepository;

        public EmployeeEvaluationService(IRepository<EmployeeEvaluation> evaluationRepository, IRepository<Question> questionRepository, IRepository<QuestionAnswer> questionAnswerRepository)
        {
            _evaluationRepository = evaluationRepository;
            _questionRepository = questionRepository;
            _questionAnswerRepository = questionAnswerRepository;
        }

        public async Task<bool> UpdateEvaluationStatus(AcceptOrRejectEvaluationDTO model)
        {
            try
            {
                var evaluation = await _evaluationRepository.Get(model.EvaluationId);

                if (evaluation == null)
                    return false;

                evaluation.Status = model.IsAccepted ? EvaluationStatus.Accepted : EvaluationStatus.Rejected;
                await _evaluationRepository.Update(evaluation);

                if (evaluation.Status == EvaluationStatus.Accepted)
                {
                    // TODO: Notify CEO via email
                }
                else
                {
                    // TODO: Notify Line Manager
                }

                return await _evaluationRepository.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<EmployeeEvaluation> CreateEvaluation(EmployeeEvaluationDTO model)
        {
            try
            {
                var evaluation = new EmployeeEvaluation()
                {
                    EmployeeEmail = model.EmployeeEmail,
                    EmployeeName = model.EmployeeName,
                    Date = model.Date,
                    EmployeeId = model.EmployeeId,
                    EmploymentDate = model.EmploymentDate,
                    JobTitle = model.JobTitle,
                    ManagerEmail = model.ManagerEmail,
                    ManagerId = model.ManagerId,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                var result = await _evaluationRepository.Create(evaluation);

                var newQuestions = new List<Question>();
                var answers = new List<QuestionAnswer>();
                foreach (var question in model.Questions)
                {
                    if (question.Id == Guid.Empty || question.Id == null)
                    {
                        var id = Guid.NewGuid();
                        newQuestions.Add(new Question { Id = id, Label = question.Label });
                        question.Id = id;
                    }
                    answers.Add(new QuestionAnswer()
                    {
                        EmployeeEvaluationId = result.Id,
                        QuestionId = question.Id,
                    });
                }

                await _questionRepository.AddRange(newQuestions);
                await _questionAnswerRepository.AddRange(answers);

                await _evaluationRepository.SaveChangesAsync();

                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeEvaluation> Get(Guid id)
        {
            var evaluation = await _evaluationRepository.GetAll()
                .Where(e => e.Id == id)
                .Include(e => e.QuestionAnswers)
                .ThenInclude(e => e.Question).AsNoTracking().FirstOrDefaultAsync();

            return evaluation;
        }

        public List<EmployeeEvaluation> GetAll()
        {
            var evaluations = _evaluationRepository.GetAll()
               .Include(e => e.QuestionAnswers)
               .ThenInclude(e => e.Question)
               .ToList();

            return evaluations;
        }

        public async Task<bool> UpdateEvaluationAnswers(QuestionAnswersDTO model)
        {
            try
            {
                var answers = new List<QuestionAnswer>();

                foreach (var item in model.Answers)
                {
                    answers.Add(new QuestionAnswer()
                    {
                        EmployeeEvaluationId = model.EvaluationId,
                        Id = item.Id,
                        QuestionId = item.QuestionId,
                        Text = item.Text
                    });
                }

                _questionAnswerRepository.UpdateRange(answers);
                await _questionAnswerRepository.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

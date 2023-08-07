using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EConfirm.ViewModels
{
    public class EmployeeEvaluationDTO
    {
        public Guid EmployeeId { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        public Guid ManagerId { get; set; }
        [Required]
        public string ManagerEmail { get; set; }
        public string JobTitle { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public List<QuestionDTO> Questions { get; set; }
    }

    public class QuestionDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Label { get; set; }
    }

    public class QuestionAnswersDTO
    {
        public Guid EvaluationId { get; set; }
        [Required]
        public List<AnswersDTO> Answers { get; set; }
    }

    public class AnswersDTO
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        [Required]
        public string Text { get; set; }
    }

    public class AcceptOrRejectEvaluationDTO
    {
        public Guid EvaluationId { get; set; }
        [Required]
        public bool IsAccepted { get; set; } = false;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EConfirm.Models
{
    public class EmployeeEvaluation
    {
        public EmployeeEvaluation()
        {
            QuestionAnswers = new HashSet<QuestionAnswer>();
        }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        public Guid ManagerId { get; set; }
        [Required]
        public string ManagerEmail { get; set; }
        public string JobTitle { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public EvaluationStatus Status { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public class Question
    {
        public Guid Id { get; set; }
        [Required]
        public string Label { get; set; }
    }

    public class QuestionAnswer
    {
        public Guid Id { get; set; }
        [Required]
        public Guid EmployeeEvaluationId { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public Question? Question { get; set; }
        public EmployeeEvaluation? EmployeeEvaluation { get; set; }
    }

    public enum EvaluationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EConfirm.Models;
using Microsoft.EntityFrameworkCore;

namespace EConfirm.Data
{
    public class EConfirmDbContext : DbContext
    {
        public EConfirmDbContext(DbContextOptions<EConfirmDbContext> options) : base(options)
        {

        }

        public virtual DbSet<EmployeeEvaluation> EmployeeEvaluations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
    }
}

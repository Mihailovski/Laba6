using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba6.Models
{
    public class Discipline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public string ReportType { get; set; }
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public List<DisciplineList> DisciplineLists { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Discipline()
        {

        }
    }
}

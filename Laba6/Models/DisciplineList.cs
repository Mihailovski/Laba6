using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba6.Models
{
    public class DisciplineList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid TeacherId { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public DisciplineList()
        {

        }
    }
}

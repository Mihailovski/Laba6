using System;

namespace Laba6.ViewModels
{
    public class DisciplineView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public string ReportType { get; set; }
        public string Specialization { get; set; }
        public Guid SpecializationId { get; set; }
    }
}

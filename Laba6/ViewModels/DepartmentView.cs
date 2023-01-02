using System;

namespace UniversityApp.ViewModels
{
    public class DepartmentView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IsReleasing { get; set; }
        public string Faculty { get; set; }
    }
}

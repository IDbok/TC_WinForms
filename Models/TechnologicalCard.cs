using System;
using TC_WinForms.Models.TcContent;

namespace TC_WinForms.Models
{
    public class TechnologicalCard
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; } = "1.0";

        public Dictionary<string, string> Data { get; set; }  = new Dictionary<string, string>();

        public List<Staff> Staffs { get; set; } = new List<Staff>();
        public List<Component> Components { get; set; } = new List<Component>();
        public List<Tool> Tools { get; set; } = new List<Tool>();
        public List<Machine> Machines { get; set; } = new List<Machine>();
        public List<Protection> Protections { get; set; } = new List<Protection>();
        public List<WorkStep> WorkSteps { get; set; } = new List<WorkStep>();

    }
}

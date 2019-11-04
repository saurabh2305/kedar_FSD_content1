using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguraionDemo
{
    public class AppConfiguration
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int ParticipantCount { get; set; }
        public ProjectDetails ProjectDetails { get; set; }
    }
}

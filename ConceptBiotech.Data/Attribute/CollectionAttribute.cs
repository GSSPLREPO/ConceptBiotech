using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptBiotech.Data
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionAttribute : System.Attribute
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}

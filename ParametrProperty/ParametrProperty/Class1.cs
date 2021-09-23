using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// более жесткое ограничение может быть или на get или на set
namespace ParametrProperty
{
    class Class1
    {
        private String m_name;
        public String Name
        {
            get { return m_name; }
            protected set { m_name = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.BusinessObjects.Consultas
{
    public partial class Peticion
    {
        public string whereJobHeader { get; set; }
        public string whereGroups { get; set; }

        public Peticion()
        { }

        public Peticion(string _whereJobHeader, string _whereGroups)
        {
            whereJobHeader = _whereJobHeader;
            whereGroups = _whereGroups;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class ResponseModel
    {
        public int Response { get; set; }
        public List<object> Content { get; set; }
        public DateTime RequestTime { get; set; }
    }
}

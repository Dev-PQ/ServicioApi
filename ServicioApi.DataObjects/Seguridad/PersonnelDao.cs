using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.DataObjects.Seguridad
{
    public class PersonnelDao :DataAccessBase
    {
        public virtual DataTable ExisteUsuario(String Usuario)
        {
            if (Usuario == "*")
            {
                Usuario = string.Empty;
            }
            DataTable dtDatos = Db.ExecuteDataSet("SP_PERSONNEL_Q1", Usuario).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                return dtDatos;
            }
            else
            {
                return new DataTable();
            }
        }
    }
}

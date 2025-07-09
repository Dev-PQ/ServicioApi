using ServicioApi.DataObjects.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.DataObjects.Browses
{
    public partial class BrowsesDao : DataAccessBase
    {
        public virtual byte[] CheckSecurityOverride(String userLogin)
        {
            if (userLogin == "*")
            {
                userLogin = string.Empty;
            }
            UtilsLib util = new UtilsLib();
            DataTable dtDatos = Db.ExecuteDataSet("SP_ROLE_ASSIGNMENT_Q1", userLogin).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                return util.CompressDataTable(dtDatos);
            }
            else
            {
                return util.CompressDataTable(new DataTable());
            }
        }
        public virtual byte[] SqlGroupFilter(String userLogin)
        {
            if (userLogin == "*")
            {
                userLogin = string.Empty;
            }
            UtilsLib util = new UtilsLib();
            DataTable dtDatos = Db.ExecuteDataSet("SP_GROUPLINK_Q1", userLogin).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                return util.CompressDataTable(dtDatos);
            }
            else
            {
                return util.CompressDataTable(new DataTable());
            }
        }
    }
}

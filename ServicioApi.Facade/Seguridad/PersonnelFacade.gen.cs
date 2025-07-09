using LibreriaBSNet.InfoApp;
using ServicioApi.DataObjects.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioApi.Facade.Seguridad
{
    [DataObject(true)]
    public partial class PersonnelFacade
    {
        private PersonnelDao personnel;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public PersonnelFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    personnel = new PersonnelDao();
                    break;
            }
        }
        #endregion

        #region Metodos de Control de Errores
        public virtual string getError()
        {
            return Error;
        }

        public virtual bool HayError()
        {
            return hayError;
        }
        #endregion

        #region Metodos Secundarios
        public virtual DataTable ExisteUsuario(String Usuario)
        {
            return personnel.ExisteUsuario(Usuario);
        }
        #endregion
    }
}

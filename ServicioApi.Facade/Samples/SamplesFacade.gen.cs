using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaBSNet.InfoApp;
using ServicioApi.BusinessObjects.Consulta;
using ServicioApi.DataObjects.Samples;

namespace ServicioApi.Facade.Samples
{
    [DataObject(true)]
    public partial class SamplesFacade
    {
        private SamplesDao samples;

        // --- Variables de control de errores 
        private string Error;

        private bool hayError;

        #region Constructores
        public SamplesFacade()
        {
            switch (AplicacionBS.Gestor_BD)
            {
                default:
                    samples = new SamplesDao();
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
        public virtual byte[] Client_Factura(String whereJobHeader)
        {
            return samples.Client_Factura(whereJobHeader);
        }
        public virtual IList<Flotas> GetFlotas_Seguro(String whereGroups, String whereJobHeader)
        {
            return samples.GetFlotas_Seguro(whereGroups, whereJobHeader);
        }

        public virtual IList<Equipos> Equipo(String whereGroups)
        {
            return samples.Equipo(whereGroups);
        }

        public IList<Componentes> ComponentesPorEquipo(String Group, String Equipos)
        {
            return samples.ComponentesPorEquipo(Group, Equipos);
        }
        public virtual IList<Nivelservicio> NivelServicio(String whereCustomer)
        {
            return samples.NivelServicio(whereCustomer);
        }

        public virtual IList<Aceitelubricante> AceiteLubricante()
        {
            return samples.AceiteLubricante();
        }
        #endregion
    }
}

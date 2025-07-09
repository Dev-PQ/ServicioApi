using ServicioApi.DataObjects.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ServicioApi.BusinessObjects.Consulta;
using System.ComponentModel;

namespace ServicioApi.DataObjects.Samples
{
    public partial class SamplesDao : DataAccessBase
    {
        public virtual IList<Flotas> GetFlotas_Seguro(String whereGroups, String whereJobHeader)
        {
            
            IList<Flotas> flotas = new List<Flotas>();
            if (whereGroups == "*")
            {
                whereGroups = null;
                DataTable dtDatos = Db.ExecuteDataSet("SP_FLOTA_AREA_Q1", whereGroups, whereJobHeader).Tables[0];
                if (dtDatos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDatos.AsEnumerable())
                    {
                        flotas.Add(new Flotas(

                            row["identity"].ToString(),
                            row["nombre_flota"].ToString(),
                            row["id_customer"].ToString())
                        );
                    }
                }
            }
            else
            {
                String[] listaGroups= whereGroups.Split(',');
                for (int i = 0; i < listaGroups.Length; i++)
                {;
                    DataTable dtDatos = Db.ExecuteDataSet("SP_FLOTA_AREA_Q1", listaGroups[i], whereJobHeader).Tables[0];
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.AsEnumerable())
                        {
                            flotas.Add(new Flotas(

                                row["identity"].ToString(),
                                row["nombre_flota"].ToString(),
                                row["id_customer"].ToString())
                            );
                        }
                    }
                }               
            }          
            return flotas;
        }

        public virtual byte[] Client_Factura(String whereJobHeader)
        {
            UtilsLib util = new UtilsLib();
            DataTable dtDatos = Db.ExecuteDataSet("SP_JOB_HEADER_Q1", whereJobHeader).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                return util.CompressDataTable(dtDatos);
            }
            else
            {
                return util.CompressDataTable(new DataTable());
            }
        }

        public virtual IList<Equipos> Equipo(String whereGroups)
        {
            IList<Equipos> equipos = new List<Equipos>();
            String[] whereGroups_ = whereGroups.Split(',');
            for (int i = 0; i < whereGroups_.Length; i++)
            {
                UtilsLib util = new UtilsLib();
                DataTable dtDatos = Db.ExecuteDataSet("SP_Equipo_Q1", whereGroups_[i]).Tables[0];
                if (dtDatos.Rows.Count > 0)
                {
                    foreach (DataRow row in dtDatos.AsEnumerable())
                    {
                        equipos.Add(new Equipos(

                            row["identity"].ToString(),
                            row["codigo_interno"].ToString(),
                            row["nome_equipo"].ToString(),
                            row["flota"].ToString()
                        ));
                    }
                }
            }
            return equipos;
        }

        public virtual IList<Componentes> ComponentesPorEquipo(String Group, String Equipos)
        {
            String[] listEquipos = Equipos.Split(',');
            String[] listGroup = Group.Split(',');
            List<Componentes> componentes = new List<Componentes>();
            if (listGroup.Length==0)
            {
                Group = null;
                for (int j = 0; j < listEquipos.Length; j++)
                {
                    DataTable dtDatos = Db.ExecuteDataSet("SP_COMPONENTE_Q1", Group, listEquipos[j]).Tables[0];
                    if (dtDatos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDatos.AsEnumerable())
                        {
                            componentes.Add(new Componentes(
                                row["identity"].ToString(),
                                row["equipo"].ToString(),
                                row["descripcion"].ToString(),
                                row["nivel_servicio"].ToString(),
                                row["aceite"].ToString()
                            ));
                        }
                    }
                }
            }
            else
            {   for (int i = 0; i < listGroup.Length; i++)
                {
                    for (int j = 0; j < listEquipos.Length; j++)
                    {
                        DataTable dtDatos = Db.ExecuteDataSet("SP_COMPONENTE_Q1", listGroup[i], listEquipos[j]).Tables[0];
                        if (dtDatos.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtDatos.AsEnumerable())
                            {
                                componentes.Add(new Componentes(
                                    row["identity"].ToString(),
                                    row["equipo"].ToString(),
                                    row["descripcion"].ToString(),
                                    row["nivel_servicio"].ToString(),
                                    row["aceite"].ToString()
                                ));
                            }
                        }
                    }
                }
            }
            return componentes;
        }
        public virtual IList<Nivelservicio> NivelServicio(String whereCustomer)
        {
            IList<Nivelservicio> nivelservicio = new List<Nivelservicio>();
            DataTable dtDatos = Db.ExecuteDataSet("SP_NivelServicio_Q1", whereCustomer).Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDatos.AsEnumerable())
                {
                    nivelservicio.Add(new Nivelservicio(
                        row["identity"].ToString(),
                        row["customer"].ToString(),
                        row["nivel_servicio"].ToString(),
                        row["nome_nivel_servicio"].ToString()
                    ));
                }
            }
            return nivelservicio;
        }
        public virtual IList<Aceitelubricante> AceiteLubricante()
        {

            IList<Aceitelubricante> aceitelubricante = new List<Aceitelubricante>();
            DataTable dtDatos = Db.ExecuteDataSet("SP_ACEITE_LUBRICANTE_Q1").Tables[0];
            if (dtDatos.Rows.Count > 0)
            {
                foreach (DataRow row in dtDatos.AsEnumerable())
                {
                    aceitelubricante.Add(new Aceitelubricante
                    (
                        row["identity"].ToString(),
                        row["name"].ToString()
                    ));
                }
            }
            return aceitelubricante;
        }
    }
}

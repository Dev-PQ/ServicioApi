namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Muestras
    {
       public string SolicitudID { get; set; }  
       public  string IdBotella { get; set; }
        public string FlotaID { get; set; }
        public string EquipoID { get; set; }
        public string ComponenteID { get; set; }
        public string NivelServicio { get; set; }
        public string AceiteLubricante { get; set; }
        public string FechaMuestreo { get; set; }
        public int HorasKmEquipo {get ; set; }
        public string UnidadMedidaEquipo  {get ; set; }
        public int HorasKmAceite {get ;set; }
        public string  UnidadMedidaAceite {get ;set; }
        public double VolumenRelleno {get ;set; }
        public string UnidadMedidaRelleno { get; set; }
        public string AceiteCambiado {get ; set; }
        public string FiltroCambiado {get ; set; }
        public string Comentarios { get; set; }
        public string Observaciones { get; set; }

        public Muestras ()
        { }
        public Muestras(
            string iD_Solicitud, 
            string iD_Botella, 
            string flota, 
            string equipo, 
            string componente, 
            string nivel_servicio, 
            string aceite_Lubricante, 
            string fecha_Muestreo, 
            int horasKmEquipo, 
            string unidadMedidaEquipo,
            int horasKmAceite,
            string unidadMedidaAceite,
            double volumenRelleno,
            string unidadMedidaRelleno,
            string aceiteCambiado,
            string filtroCambiado,
            string comentarios,
            string observaciones
            )
        {
            SolicitudID=iD_Solicitud;
            IdBotella=iD_Botella;
            FlotaID=flota;
            EquipoID=equipo;
            ComponenteID=componente;
            NivelServicio=nivel_servicio;
            AceiteLubricante=aceite_Lubricante;
            FechaMuestreo=fecha_Muestreo;
            HorasKmEquipo=horasKmEquipo;
            UnidadMedidaEquipo=unidadMedidaEquipo;
            VolumenRelleno=volumenRelleno;
            UnidadMedidaRelleno=unidadMedidaRelleno;
            AceiteCambiado=aceiteCambiado;
            FiltroCambiado=filtroCambiado;
            Comentarios= comentarios;
            Observaciones=observaciones;
        }
    }
}

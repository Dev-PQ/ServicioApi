namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Componentes
    {
        public string ID_COMPONENTE { get; set; }
        public string EQUIPO { get; set; }
        public string DESCRIPCION { get; set; }
        public string NIVEL_SERVICIO { get; set; }
        public string ACEITE { get; set; }
        public Componentes() { }
        public Componentes(string iD_COMPONENTE, string eQUIPO, string dESCRIPCION, string nIVEL_SERVICIO, string aCEITE)
        {
            ID_COMPONENTE=iD_COMPONENTE;
            EQUIPO=eQUIPO;
            DESCRIPCION=dESCRIPCION;
            NIVEL_SERVICIO=nIVEL_SERVICIO;
            ACEITE=aCEITE;
        }
    }
}

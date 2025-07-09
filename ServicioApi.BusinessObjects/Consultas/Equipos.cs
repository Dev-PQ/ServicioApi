namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Equipos
    {
        public string ID_EQUIPO { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public string NOME_EQUIPO { get; set; }
        public string FLOTA { get; set; }
        public Equipos() { }
        public Equipos(string ID_EQUIPO_,string CODIGO_INTERNO_, string NOME_EQUIPO_, string FLOTA_) 
        {
            ID_EQUIPO = ID_EQUIPO_;
            CODIGO_INTERNO = CODIGO_INTERNO_;
            NOME_EQUIPO = NOME_EQUIPO_;
            FLOTA = FLOTA_;
        }
    }
}

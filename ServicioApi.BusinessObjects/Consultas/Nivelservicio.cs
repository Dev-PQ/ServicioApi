namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Nivelservicio
    {
        public string ID_CLIENTE_SERVICIO { get; set; }
        public string ID_CUSTOMER { get; set; }
        public string NIVEL_SERVICIO { get; set; }
        public string NOME_NIVEL_SERVICIO { get; set; }

        public Nivelservicio() { }

        public Nivelservicio(string iD_CLIENTE_SERVICIO, string iD_CUSTOMER, string nIVEL_SERVICIO, string nOME_NIVEL_SERVICIO)
        {
            ID_CLIENTE_SERVICIO=iD_CLIENTE_SERVICIO;
            ID_CUSTOMER=iD_CUSTOMER;
            NIVEL_SERVICIO=nIVEL_SERVICIO;
            NOME_NIVEL_SERVICIO=nOME_NIVEL_SERVICIO;
        }
    }
}

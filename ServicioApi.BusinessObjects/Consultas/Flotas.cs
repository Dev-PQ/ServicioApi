namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Flotas
    {
       public string ID_FLOTA { get; set; }
        public string NOMBRE_FLOTA { get; set; }
        public string ID_CUSTOMER { get; set; }

        public Flotas() { }
        public Flotas(string ID_FLOTA_, string NOMBRE_FLOTA_, string ID_CUSTOMER_) 
        {
            ID_FLOTA = ID_FLOTA_;
            NOMBRE_FLOTA = NOMBRE_FLOTA_;
            ID_CUSTOMER = ID_CUSTOMER_;
        }
    }
}

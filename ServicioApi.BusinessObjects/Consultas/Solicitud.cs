namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Solicitud
    {
        public string JOB_STATUS { get; set; }
        public string CLIENT_FACTURA { get; set; }
        public string JOB_NAME { get; set; }

        public Solicitud() { }

        public Solicitud(string JOB_STATUS_, string CLIENT_FACTURA_, string JOB_NAME_) 
        {
            JOB_NAME = JOB_NAME_;
            CLIENT_FACTURA = CLIENT_FACTURA_;
            JOB_STATUS = JOB_STATUS_;
        }
    }
}

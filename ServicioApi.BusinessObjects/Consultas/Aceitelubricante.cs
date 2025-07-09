namespace ServicioApi.BusinessObjects.Consulta
{
    public partial class Aceitelubricante
    {
        public string ID_ACEITE_LUBRICANTE { get; set; }
        public string NAME {  get; set; }

        public Aceitelubricante() { }
        public Aceitelubricante(string iD_ACEITE_LUBRICANTE, string nAME)
        {
            ID_ACEITE_LUBRICANTE=iD_ACEITE_LUBRICANTE;
            NAME=nAME;
        }
    }
}

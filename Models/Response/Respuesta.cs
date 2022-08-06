namespace WSVentas.Models.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public String Mensaje { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Exito = 0;
        }
    }
}

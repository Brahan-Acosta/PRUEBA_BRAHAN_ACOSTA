namespace PRUEBA_BRAHAN_ACOSTA.Models
{
    public class Paciente
    {
        public int ID { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public int NUMERO_DOCUMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string CORREO_ELECTRONICO { get; set; }
        public int TELEFONO { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public string ESTADO_AFILIACION { get; set; }

    }
}

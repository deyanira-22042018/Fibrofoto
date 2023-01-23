namespace Fibrofoto.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Numero { get; set; }

        public int RetabloId { get; set; }

        public Retablos Retablos { get; set; }
    }
}

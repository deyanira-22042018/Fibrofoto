namespace Fibrofoto.Models
{
    public class Retablos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string tamaño { get; set; }
        public float price { get; set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}

namespace Fibrofoto.DTOS
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string ClienteForename { get; set; }
        public string ClienteSurname { get; set; }
        public DateTime ClienteDate { get; set; }
        public int ClienteTypeId { get; set; }
    }
}

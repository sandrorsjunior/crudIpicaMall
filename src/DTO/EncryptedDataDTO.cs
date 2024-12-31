namespace CrudIpcaMall.src.DTO
{
    public class EncryptedDataDTO
    {
        public string email {  get; set; }
        public byte[] salt {  get; set; }
        public string password { get; set; }
    }
}

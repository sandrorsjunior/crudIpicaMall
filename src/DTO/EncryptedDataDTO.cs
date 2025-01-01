namespace CrudIpcaMall.src.DTO
{
    public class EncryptedDataDTO
    {
        public int userId { get; set; }
        public string email {  get; set; }
        public byte[] salt {  get; set; }
        public string password { get; set; }
    }
}

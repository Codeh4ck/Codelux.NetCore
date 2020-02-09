namespace Codelux.NetCore.Utilities
{
    public interface IPasswordEncryptor
    {
        string Encrypt(string password);
        string Decrypt(string password);
    }
}

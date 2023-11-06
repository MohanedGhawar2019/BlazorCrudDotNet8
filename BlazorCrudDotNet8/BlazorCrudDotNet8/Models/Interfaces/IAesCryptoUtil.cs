namespace BlazorCrudDotNet8.Models.Interfaces
{
    public interface IAesCryptoUtil
    {
        string Encrypt(string text);
        string Decrypt(string base64String);
    }
}

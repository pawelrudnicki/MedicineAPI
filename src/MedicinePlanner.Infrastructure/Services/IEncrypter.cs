namespace MedicinePlanner.Infrastructure.Services
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt); 

        /**
        ---- JEDNOSTRONNE SZYFROWANIE ----
        1. pobieramy sól
        2. na podstawie soli i hasła (value) -> generujemy hash
        **/
    }
}
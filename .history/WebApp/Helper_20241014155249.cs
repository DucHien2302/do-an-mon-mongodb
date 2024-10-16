using System.Security.Cryptography;
using System.Text;

namespace WebApp;

public static class Helper
{
    public static string HashPassword(string plaintext)
    {
        using HashAlgorithm algorithm = SHA512.Create();
        byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.AppendFormat("{0:x2}", b);
        }
        return sb.ToString();
    }
    public static string RandomString(int lenght)
    {
        string pattern = "1234567890qwertyuiopasdfghjklzxcvbnm";
        char[] arr = new char[lenght];
    }
}
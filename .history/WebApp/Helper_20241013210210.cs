using System.Security.Cryptography;
using System.Text;

namespace WebApp;

public static class Helper
{
    public static string HashPassword(string plaintext)
    {
        using HashAlgorithm algorithm = SHA512.Create();
        byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

        // Convert byte array to a hexadecimal string
        StringBuilder hexString = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            hexString.AppendFormat("{0:x2}", b);

        return hexString.ToString();
    }
}
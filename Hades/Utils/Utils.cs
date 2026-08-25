using System;
using System.Security.Cryptography;

public static class Utils
{
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static string GenerateRandomString(int length = 15)
    {
        var result = new char[length];
        var bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);

        for (int i = 0; i < length; i++)
        {
            result[i] = Chars[bytes[i] % Chars.Length];
        }

        return new string(result);
    }
}

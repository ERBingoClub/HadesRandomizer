using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Hades.Utils;

public static class RandoUtils
{
    private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

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

    public static string GetVersion()
    {
        return Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion
            ?? "unknown";
    }

    public static int GetRandomNumber(string seed, int len)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(seed));
        var seedInt = BitConverter.ToInt32(hash, 0);
        Random rng = new Random(seedInt);
        return rng.Next(len);
    }
}

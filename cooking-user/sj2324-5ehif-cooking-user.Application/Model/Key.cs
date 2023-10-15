using System.Text;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Checksum;

namespace sj2324_5ehif_cooking_user.Application.Model;


public abstract class Key
{
    private readonly String prefix;
    private readonly int length;

    protected string GetRandomPart(int length)
    {
        
        Random rnd = new Random();
        StringBuilder sb = new StringBuilder(length);
        string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        int counter = 0; 
        for (int i = 0; i < length; i++)
        {
            sb.Append(chars[rnd.Next(chars.Length)]);
        }

        return sb.ToString();
    }

    protected string GetTime()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmmss"); // Year, Month, Day, Hour, Minute, Second
    }
    public string GenerateKey()
    {
        int randomPartLength = length - prefix.Length - 14;  // 14 for counter
        string randomPart = GetRandomPart(randomPartLength);
        string counterPart = GetTime();
        string key = prefix + randomPart + counterPart;
        Adler32 adler32 = new Adler32();
        adler32.Update( System.Text.Encoding.UTF8.GetBytes(key));
        return key + adler32.Value;


    }

}
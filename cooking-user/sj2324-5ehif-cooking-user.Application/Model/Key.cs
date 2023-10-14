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

    protected string GetCounterPart()
    {
        return (++counter).ToString().PadLeft(14, '0');  // Assuming max of 99999999999999 as the counter
    }

    public string GenerateKey()
    {
        int randomPartLength = length - prefix.Length - 14;  // 14 for counter
        string randomPart = GetRandomPart(randomPartLength);
        string counterPart = GetCounterPart();

        return prefix + randomPart + counterPart;
    }

}
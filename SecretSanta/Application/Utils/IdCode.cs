namespace SecretSanta.Application.Utils
{
  public class IdCode
  {
    private IdCode() {}
    
    public static string Generate()
    {
      var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
      var random = new Random();
      var idCode = new char[10];
    
      for (int i = 0; i < idCode.Length; i++)
      {
        idCode[i] = chars[random.Next(chars.Length)];
      }

      return new string(idCode);
    }
  }
}

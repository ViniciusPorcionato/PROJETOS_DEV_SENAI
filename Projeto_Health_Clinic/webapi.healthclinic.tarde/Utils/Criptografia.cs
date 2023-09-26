namespace webapi.healthclinic.tarde.Utils
{
    public class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public static bool CompararHash(string senhaForm, string senhaBD)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBD);
        }
    }
}

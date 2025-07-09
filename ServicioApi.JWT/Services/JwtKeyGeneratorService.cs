using System.Security.Cryptography;

namespace ServicioApi.JWT.Services
{
    public class JwtKeyGeneratorService
    {
        public string GenerateSecureKey(int length = 32)
        {
            var bytes = new byte[length];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes).Substring(0, length);
        }
    }
}

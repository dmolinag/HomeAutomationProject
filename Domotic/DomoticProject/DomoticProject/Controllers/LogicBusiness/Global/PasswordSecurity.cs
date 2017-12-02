using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DomoticProject.Controllers.LogicBusiness.Global
{
    class PasswordSecurity
        {
        /// <summary>
        /// The shared hmac password is created only once and hardcoded
        /// </summary>
        static byte[] SharedHMACPassword = new byte[] {
            0x45, 0xa3, 0xd0, 0x3e, 0x1b, 0xde, 0x08, 0x83, 0xa2, 0xb7,
            0x26, 0xbc, 0x76, 0x1f, 0x6c, 0xbe, 0xc5, 0x5e, 0x60, 0xa9,
            0x01, 0x5e, 0x74, 0x12, 0x0f, 0xc2, 0x8e, 0x02, 0x5b, 0x47,
            0x48, 0x39, 0x86, 0x4c, 0x3d, 0x13, 0xeb, 0xf6, 0x74, 0x93,
            0x80, 0x11, 0x27, 0x3f, 0xe5, 0xb6, 0x30, 0xd8, 0x78, 0x5f,
            0x67, 0x4b, 0x26, 0xe7, 0x84, 0x36, 0x4c, 0x46, 0x94, 0xb7,
            0x72, 0xa0, 0xbf, 0x05 };

        /// <summary>
        /// Number of iterations that  HMAC will be computed
        /// </summary>
        const int iteration = 100000;

        /// <summary>
        /// Generates the random salt of 32 bytes.
        /// </summary>
        /// <param name="rng">The RNG.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static string GenerateRandomSalt(RNGCryptoServiceProvider rng, int size)
        {
            var bytes = new Byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Creates the user hash. The random salt is added to the password, the SHA256 procedure is to apply a logic XOR
        /// to the password and the salt.
        /// The HMAC procedure use hash function in combination with a SharedHMACPassword. The ouput is computed n times to 
        /// make the HMAC function very slow
        /// </summary>
        /// <param name="salt">The random salt.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static UserKeyPair CreateUserHash(string password)
        {
            //Generate salt
            string salt = GenerateRandomSalt(new RNGCryptoServiceProvider(), 32);

            string shaInput = password + salt;

            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] shaFirstRound = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(shaInput));

            HMACSHA256 myHMAC = new HMACSHA256(SharedHMACPassword);

            //Compute HMAC n times starting with shaFirstRound using a password for HMAC
            for (int i = 0; i < iteration; i++)
            {
                shaFirstRound = myHMAC.ComputeHash(shaFirstRound);
            }

            string pass = Convert.ToBase64String(shaFirstRound);
            return new UserKeyPair(salt, pass);
        }


        /// <summary>
        /// Validate the user hash. The data base random salt is added to the password, the SHA256 procedure is to apply a logic XOR
        /// to the password and the data base salt.
        /// The HMAC procedure use hash function in combination with a SharedHMACPassword. The ouput is computed n times to 
        /// make the HMAC function very slow.
        /// This procedure must be the same as the creatHash to generate the same hash to compare it with the data base hash
        /// </summary>
        /// <param name="true">returns true if the input hash is the same as the data base hash.</param>
        /// <param name="false">returns dalse if the input hash is not the same as the data base hash.</param>
        /// <returns></returns>
        public static bool ValidateUserHash(string password, UserKeyPair userKeys)
        {
            string shaInput = password + userKeys.Salt;

            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] shaFirstRound;
            shaFirstRound = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(shaInput));

            HMACSHA256 myHMAC = new HMACSHA256(SharedHMACPassword);

            //Compute HMAC n times starting with shaFirstRound using a password for HMAC
            for (int i = 0; i < iteration; i++)
            {
                shaFirstRound = myHMAC.ComputeHash(shaFirstRound);
            }

            string computedHash = Convert.ToBase64String(shaFirstRound);

            //Compare the input hash with the data base hash
            if (computedHash == userKeys.HashedPassword) return true;
            return false;
        }
    }
}

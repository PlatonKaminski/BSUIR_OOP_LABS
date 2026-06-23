using System;
using System.Text;

namespace FriendEncryptionPlugin
{
    public class XorEncryptionPlugin : IFriendEncryptionPlugin
    {
        public string PluginName => "XOR Encryption";
        public string Algorithm  => "XOR with key";
        
        public byte[] Encrypt(byte[] data, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^
                                   keyBytes[i % keyBytes.Length]);
            }

            return result;
        }
        
        public byte[] Decrypt(byte[] data, string key)
        {
            return Encrypt(data, key);
        }
    }
}
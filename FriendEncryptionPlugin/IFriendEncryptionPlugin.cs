namespace FriendEncryptionPlugin
{

    public interface IFriendEncryptionPlugin
    {
        string PluginName { get; }
        
        string Algorithm { get; }

        byte[] Encrypt(byte[] data, string key);
        
        byte[] Decrypt(byte[] data, string key);
    }
}
using System;
using System.IO;
using OOP_lab2;

namespace PluginSignerTool
{

    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("=== Plugin Signer Tool ===");
            Console.WriteLine();
            
            if (args.Length < 2)
            {
                PrintUsage();
                return 1;
            }

            string command = args[0].ToLower();
            string dllPath = args[1];
            
            if (!File.Exists(dllPath))
            {
                Console.WriteLine($"ERROR: File not found: {dllPath}");
                return 1;
            }

            switch (command)
            {
                case "sign":
                    return HandleSign(dllPath, args);

                case "verify":
                    return HandleVerify(dllPath);

                default:
                    Console.WriteLine($"Unknown command: {command}");
                    PrintUsage();
                    return 1;
            }
        }
        
        static int HandleSign(string dllPath, string[] args)
        {
            string pluginName = args.Length >= 3
                ? args[2]
                : Path.GetFileNameWithoutExtension(dllPath);

            try
            {
                Console.WriteLine($"Signing: {dllPath}");
                Console.WriteLine($"Name:    {pluginName}");
                Console.WriteLine();

                PluginSigner.Sign(dllPath, pluginName);

                Console.WriteLine();
                Console.WriteLine("SUCCESS! Plugin signed.");
                Console.WriteLine($"Copy both .dll and .dll.sig to the plugins folder.");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return 1;
            }
        }
        
        static int HandleVerify(string dllPath)
        {
            Console.WriteLine($"Verifying: {dllPath}");
            Console.WriteLine();

            bool valid = PluginSigner.Verify(dllPath, out string message);

            Console.WriteLine(valid ? "VALID" : "INVALID");
            Console.WriteLine($"Message: {message}");

            return valid ? 0 : 1;
        }

        static void PrintUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  PluginSigner sign   <path.dll> [\"Plugin Name\"]");
            Console.WriteLine("  PluginSigner verify <path.dll>");
        }
    }
}
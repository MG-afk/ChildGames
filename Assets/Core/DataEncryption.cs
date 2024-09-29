using System;
using System.IO;
using System.Security.Cryptography;

namespace Dream.Core
{
	public static class DataEncryption
	{
		// Use a securely generated key here
		private static readonly string key = "ndE7Jeoubr/t2rKt4kMU/7bAPPUxZHVugqYDecLktcA=";

		public static void EncryptFile(string inputFilePath, string outputFilePath)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = Convert.FromBase64String(key);

				// Generate a random IV
				aes.GenerateIV();
				byte[] iv = aes.IV;

				using (var fsOutput = new FileStream(outputFilePath, FileMode.Create))
				{
					// Write the IV to the beginning of the file
					fsOutput.Write(iv, 0, iv.Length);

					using (var cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
					{
						using (var fsInput = new FileStream(inputFilePath, FileMode.Open))
						{
							fsInput.CopyTo(cs);
						}
						// Ensure all data is written to the CryptoStream
						cs.FlushFinalBlock();
					}
				}
			}
		}


		public static string DecryptFile(string inputFilePath)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = Convert.FromBase64String(key);

				using (var fsInput = new FileStream(inputFilePath, FileMode.Open))
				{
					// Read the IV from the beginning of the file
					byte[] iv = new byte[16];
					fsInput.Read(iv, 0, iv.Length);
					aes.IV = iv;

					using (var cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
					{
						using (var reader = new StreamReader(cs))
						{
							// Read the decrypted data
							return reader.ReadToEnd();
						}
					}
				}
			}
		}

	}
}
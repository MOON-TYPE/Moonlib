//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AES.cs (05/10/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension de datos para encriptacion avanzada				\\
// Fecha Mod:		05/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>AES (Advanced Encryption Standard) con clave de 128 bits (predeterminada);</para>
	/// <para>128-bit AES es aprobado por NIST, pero no el 256-bit AES;</para>
	/// <para>AES de 256 bits es mas lento que el AES de 128 bits (aproximadamente 40%);</para>
	/// <para>Utilicelo para la proteccion segura de datos;</para>
	/// <para>NO lo utilice para la proteccion de datos en RAM;</para>
	/// </summary>
	public static class AES
    {
		#region Constantes
		private const string SaltKey = "ShMG8hLyZ7k~Ge5@";
		private const string VIKey = "~6YUi0Sv5@|{aOZO";
		#endregion

		#region Variables Estaticas
		/// <summary>
		/// <para>Longitud de Key, 128 (defecto) o 256.</para>
		/// </summary>
		public static int KeyLength = 128;                              // Longitud de Key, 128 (defecto) o 256
		#endregion

		#region API
		/// <summary>
		/// <para>Cifrar string simple con password.</para>
		/// </summary>
		public static string Encriptar(string value, string password)// Cifrar string simple con password
		{
			return Encriptar(Encoding.UTF8.GetBytes(value), password);
		}

		/// <summary>
		/// <para>Cifrar array de bytes simples utilizando la password.</para>
		/// </summary>
		public static string Encriptar(byte[] value, string password)// Cifrar array de bytes simples utilizando la password
		{
			var keyBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(SaltKey)).GetBytes(KeyLength / 8);
			var keySimetrica = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
			var encriptador = keySimetrica.CreateEncryptor(keyBytes, Encoding.UTF8.GetBytes(VIKey));

			using (var memoriaStream = new MemoryStream())
			{
				using (var cryptoStream = new CryptoStream(memoriaStream, encriptador, CryptoStreamMode.Write))
				{
					cryptoStream.Write(value, 0, value.Length);
					cryptoStream.FlushFinalBlock();
					cryptoStream.Close();
					memoriaStream.Close();

					return Convert.ToBase64String(memoriaStream.ToArray());
				}
			}
		}

		/// <summary>
		/// <para>Descifrar string cifrada AES utilizando password.</para>
		/// </summary>
		public static string Desencriptar(string value, string password)// Descifrar string cifrada AES utilizando password
		{
			var cifrarTextBytes = Convert.FromBase64String(value);
			var keyBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(SaltKey)).GetBytes(KeyLength / 8);
			var keySimetrica = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None };
			var desencriptador = keySimetrica.CreateDecryptor(keyBytes, Encoding.UTF8.GetBytes(VIKey));

			using (var memoriaStream = new MemoryStream(cifrarTextBytes))
			{
				using (var cryptoStream = new CryptoStream(memoriaStream, desencriptador, CryptoStreamMode.Read))
				{
					var textBytes = new byte[cifrarTextBytes.Length];
					var desencriptadoByteCount = cryptoStream.Read(textBytes, 0, textBytes.Length);

					memoriaStream.Close();
					cryptoStream.Close();

					return Encoding.UTF8.GetString(textBytes, 0, desencriptadoByteCount).TrimEnd("\0".ToCharArray());
				}
			}
		}
		#endregion
	}
}
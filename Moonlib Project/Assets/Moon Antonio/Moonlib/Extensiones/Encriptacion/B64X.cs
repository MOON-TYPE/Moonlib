//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// B64X.cs (05/10/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension para codificacion Base64 XOR con una clave		\\
// Fecha Mod:		05/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
using System.Text;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Simple y rapida codificacion Base64 XOR con una clave. Adecuado para la proteccion de datos en RAM.</para>
	/// <para> NO lo use para cifrado seguro de datos.</para>
	/// </summary>
	public class B64X
    {
		#region API
		/// <summary>
		/// <para>Encriptar texto (Base64 XOR).</para>
		/// </summary>
		public static string Encriptar(string value, string key)// Encriptar texto (Base64 XOR)
		{
			return Convert.ToBase64String(Codificar(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(key)));
		}

		/// <summary>
		/// <para>Desencriptar texto (Base64 XOR).</para>
		/// </summary>
		public static string Desencriptar(string value, string key)// Desencriptar texto (Base64 XOR)
		{
			return Encoding.UTF8.GetString(Codificar(Convert.FromBase64String(value), Encoding.UTF8.GetBytes(key)));
		}

		/// <summary>
		/// <para>Codificar string simple a Base64 XOR.</para>
		/// </summary>
		private static byte[] Codificar(byte[] bytes, byte[] key)// Codificar string simple a Base64 XOR
		{
			var j = 0;

			for (var i = 0; i < bytes.Length; i++)
			{
				bytes[i] ^= key[j];

				if (++j == key.Length)
				{
					j = 0;
				}
			}

			return bytes;
		}
		#endregion
	}
}
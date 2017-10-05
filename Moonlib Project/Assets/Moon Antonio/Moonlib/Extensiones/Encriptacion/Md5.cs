//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Md5.cs (05/10/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension Md5 helper										\\
// Fecha Mod:		05/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Security.Cryptography;
using System.Text;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Md5 helper.</para>
	/// </summary>
	public static class Md5
    {
		#region API
		/// <summary>
		/// <para>Calcular Md5-hash de string.</para>
		/// </summary>
		public static string CalcularHash(string input)// Calcular Md5-hash de string.
		{
			var inputBytes = Encoding.UTF8.GetBytes(input);
			var hash = MD5.Create().ComputeHash(inputBytes);
			var stringBuilder = new StringBuilder();

			for (var n = 0; n < hash.Length; n++)
			{
				stringBuilder.Append(hash[n].ToString("X2"));
			}

			return stringBuilder.ToString();
		}
		#endregion
	}
}

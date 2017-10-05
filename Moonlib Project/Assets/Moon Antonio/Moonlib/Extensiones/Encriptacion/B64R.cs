//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// B64R.cs (05/10/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension para codificacion Base64 con byte.				\\
// Fecha Mod:		05/10/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Simple y rapido algoritmo de codificacion Base64 con byte. Adecuado para la proteccion de datos en RAM.</para>
	/// <para>Utilice para almacenar datos fuera de la memoria RAM inseguros. No lo use para cifrado seguro de datos</para>
	/// </summary>
	public class B64R
    {
		#region API
		/// <summary>
		/// <para>Codificar string simple (Base64R).</para>
		/// </summary>
		public static string Codificar(string value)// Codificar string simple (Base64R)
		{
			var base64 = Base64.Codificar(value);
			var chars = base64.ToCharArray();

			Reverso(chars);

			return new string(chars);
		}

		/// <summary>
		/// <para>Decodificar string simple (Base64R).</para>
		/// </summary>
		public static string Decodificar(string value)// Decodificar string simple (Base64R)
		{
			var chars = value.ToCharArray();

			Reverso(chars);

			return Base64.Decodificar(new string(chars));
		}

		/// <summary>
		/// <para>Reverso.</para>
		/// </summary>
		private static void Reverso(IList<char> chars)// Reverso
		{
			for (var n = 1; n < chars.Count; n += 2)
			{
				var c = chars[n];

				chars[n] = chars[n - 1];
				chars[n - 1] = c;
			}
		}
		#endregion
	}
}
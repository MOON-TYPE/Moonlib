//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Base64.cs (05/10/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension de Base											\\
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
    /// <para>Base helper.</para>
    /// </summary>
	public static class Base64
    {
		#region API
		/// <summary>
		/// <para>Codificar string simple a Base64.</para>
		/// </summary>
		public static string Codificar(string texto)// Codificar string simple a Base64
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(texto));
		}

		/// <summary>
		/// <para>Decodificar string simple de Base64</para>
		/// </summary>
		public static string Decodificar(string texto)// Decodificar string simple de Base64
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String(texto));
		}
		#endregion
	}
}
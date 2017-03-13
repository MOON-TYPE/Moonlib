//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// StringEx.cs (13/03/2017)														\\
// Autor: Antonio Mateo (Moon Pincho) 									        \\
// Descripcion:		Extension de String											\\
// Fecha Mod:		13/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonPincho
{
	/// <summary>
	/// <para>Extension de String</para>
	/// </summary>
	public static class StringEx
	{
		#region IsFecha
		/// <summary>
		/// <para>Comprueba si es una fecha.</para>
		/// </summary>
		/// <param name="value">String de la fecha.</param>
		/// <returns>Devuelve true si el valor es una fecha.</returns>
		public static bool IsFecha(this string value)// Comprueba si es una fecha
		{
			try
			{
				DateTime tempFecha;
				return DateTime.TryParse(value, out tempFecha);
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion

		#region IsInt
		/// <summary>
		/// <para>Comprueba si es un int.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>Devuelve true si el valor es un int.</returns>
		public static bool IsInt(this string value)// Comprueba si es un int
		{
			try
			{
				int tempInt;
				return int.TryParse(value, out tempInt);
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
	}
}

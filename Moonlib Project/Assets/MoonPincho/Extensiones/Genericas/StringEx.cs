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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
		/// <returns>Devuelve true si valor es una fecha.</returns>
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

	}
}

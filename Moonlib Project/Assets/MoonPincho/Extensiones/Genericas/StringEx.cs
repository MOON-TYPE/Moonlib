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
using System.Text.RegularExpressions;
#endregion

namespace MoonPincho.Extensiones
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

		#region Obtener
		/// <summary>
		/// <para>Obtiene los primeros X caracteres.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <param name="num">Numero de caracteres a obtener.</param>
		/// <returns>Devuelve los caracteres X del string dado.</returns>
		public static string Obtener(this string value, int num)// Obtiene los primeros X caracteres
		{
			// Obtener el numero de caracteres que realmente podemos tomar
			int maxCaracteres = Math.Min(num, value.Length);

			// Obtener y devolver
			return value.Substring(0, maxCaracteres);
		}
		#endregion

		#region Omitir
		/// <summary>
		/// <para>Omite los primeros caracteres x y devuelve la cadena restante.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <param name="num">Numero de caracteres a obtener.</param>
		/// <returns>Devuelve el string con los caracteres quitados.</returns>
		public static string Omitir(this string value, int num)// Omite los primeros caracteres x y devuelve la cadena restante
		{
			return value.Substring(Math.Min(num, value.Length) - 1);
		}
		#endregion

		#region Invertir
		/// <summary>
		/// <para>Invierte una cadena.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>Devuelve la cadena dada invertida.</returns>
		public static string Invertir(this string value)// Invierte una cadena
		{
			char[] chars = value.ToCharArray();
			Array.Reverse(chars);
			return new String(chars);
		}
		#endregion

		#region IsNullOrEmpty
		/// <summary>
		/// <para>Comprueba si la cadena es null o esta vacia.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>True si el parametro value es null o una cadena vacia (""); en caso contrario, false.</returns>
		public static bool IsNullOrEmpty(this string value)// Comprueba si la cadena es null o esta vacia
		{
			return string.IsNullOrEmpty(value);
		}
		#endregion

		#region QuitarEspacios
		/// <summary>
		/// <para>Eliminar los espacios en blanco, no el del final de la linea.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>Devuelve la cadena sin los espacios.</returns>
		public static string QuitarEspacios(this string value)// Eliminar los espacios en blanco, no el del final de la linea
		{
			return value.Replace(" ", string.Empty);
		}
		#endregion

		#region GetNumPalabras
		/// <summary>
		/// <para>Devuelve el numero de palabras de la cadena dada.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>El numero de palabras.</returns>
		public static int GetNumPalabras(this string value)// Devuelve el numero de palabras de la cadena dada
		{
			return (new Regex(@"\w+")).Matches(value).Count;
		}
		#endregion

		#region AddSeparador
		/// <summary>
		/// <para>Agrega el separador dado a la cadena dada.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <param name="sep">El separador.</param>
		/// <returns>La cadena con el separador.</returns>
		public static string AddSeparador(this string value, string sep)// Agrega el separador dado a la cadena dada
		{
			return value + sep;
		}
		#endregion

		#region AddComa
		/// <summary>
		/// <para>Agrega la coma a la cadena dada.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>La cadena con el separador.</returns>
		public static string AddComa(this string value)// Agrega la coma a la cadena dada
		{
			return value.AddSeparador(",");
		}
		#endregion

		#region AddNewLinea
		/// <summary>
		/// <para>Agrega \r \n a una cadena.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>La cadena con el separador.</returns>
		public static string AddNewLinea(this string value)// Agrega \r \n a una cadena
		{
			return value.AddSeparador("\r\n");
		}
		#endregion

		#region AddEspacio
		/// <summary>
		/// <para>Agrega un espacio a la cadena dada.</para>
		/// </summary>
		/// <param name="value">El string.</param>
		/// <returns>La cadena con el separador.</returns>
		public static string AddEspacio(this string value)// Agrega un espacio a la cadena dada
		{
			return value.AddSeparador(" ");
		}
		#endregion
	}
}

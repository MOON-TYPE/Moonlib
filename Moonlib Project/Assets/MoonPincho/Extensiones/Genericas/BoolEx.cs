//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BoolEx.cs (13/03/2017)														\\
// Autor: Antonio Mateo (Moon Pincho) 									        \\
// Descripcion:		Extension de bools											\\
// Fecha Mod:		13/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

namespace MoonPincho.Extensiones
{
	/// <summary>
	/// <para>Extension de bools</para>
	/// </summary>
	public static class BoolEx
	{
		#region IsTrue
		/// <summary>
		/// <para>Comprueba si el elemento bool dado es verdadero.</para>
		/// </summary>
		/// <param name="item">Item a verificar.</param>
		/// <returns>True si el valor es true, false de lo contrario.</returns>
		public static bool IsTrue(this bool item)// Comprueba si el elemento bool dado es verdadero
		{
			return item;
		}
		#endregion

		#region IsFalse
		/// <summary>
		/// <para>Comprueba si el elemento bool dado es false.</para>
		/// </summary>
		/// <param name="item">Item a verificar.</param>
		/// <returns>True si el valor es false, true de lo contrario.</returns>
		public static bool IsFalse(this bool item)// Comprueba si el elemento bool dado es false
		{
			return !item;
		}
		#endregion

		#region Toggle
		/// <summary>
		/// <para>Alterna el elemento bool dado y devuelve el valor toggled.</para>
		/// </summary>
		/// <param name="item">Item del toggled.</param>
		/// <returns>El valor toggled.</returns>
		public static bool Toggle(this bool item)// Alterna el elemento bool dado y devuelve el valor toggled
		{
			return !item;
		}
		#endregion

		#region ToInt
		/// <summary>
		/// <para>Convierte el valor bool dado en int.</para>
		/// </summary>
		/// <param name="item">La variable bool.</param>
		/// <returns>Devuelve 1 si es true, 0 en caso contrario.</returns>
		public static int ToInt(this bool item)// Convierte el valor bool dado en int
		{
			if (item == true)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
		#endregion

		#region ToSiNo
		/// <summary>
		/// <para>Devuelve "Si" o "No" depende del valor dado.</para>
		/// </summary>
		/// <param name="item">El valor bool.</param>
		/// <returns>Sí, si el valor dado es verdadero y No de lo contrario.</returns>
		public static string ToSiNo(this bool item)// Devuelve "Si" o "No" depende del valor dado
		{
			if (item == true)
			{
				return "Si";
			}
			else
			{
				return "No";
			}
		}
		#endregion
	}
}

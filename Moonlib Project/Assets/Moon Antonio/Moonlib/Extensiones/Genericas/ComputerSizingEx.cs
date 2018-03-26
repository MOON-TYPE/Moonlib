//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ComputerSizingEx.cs (26/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Extension para dimensionar (KB, MB, GB, etc.)				\\
// Fecha Mod:		26/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Extension para dimensionar (KB, MB, GB, etc.).</para>
	/// </summary>
	public static class ComputerSizingEx
	{
		#region Constantes
		/// <summary>
		/// <para>Un kilobyte.</para>
		/// </summary>
		private const int INT_OneKB = 1024;                         // Un kilobyte
		#endregion

		#region API
		/// <summary>
		/// <para>Convierte a un tamaño de kilobyte.</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int KB(this int value)// Convierte a un tamaño de kilobyte
		{
			return value * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño de megabyte (1024^2 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int MB(this int value)// Convierte a tamaño de megabyte (1024^2 bytes)
		{
			return value * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño de gigabyte (1024^3 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int GB(this int value)// Convierte a tamaño de gigabyte (1024^3 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño de terabyte (1024^4 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int TB(this int value)// Convierte a tamaño de terabyte (1024^4 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño de petabyte (1024^5 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int PB(this int value)// Convierte a tamaño de petabyte (1024^5 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño exabyte (1024^6 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int EB(this int value)// Convierte a tamaño exabyte (1024^6 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño zettabyte (1024^7 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int ZB(this int value)// Convierte a tamaño zettabyte (1024^7 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB;
		}

		/// <summary>
		/// <para>Convierte a tamaño de yottabyte (1024^8 bytes).</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int YB(this int value)// Convierte a tamaño de yottabyte (1024^8 bytes)
		{
			return value * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB * INT_OneKB;
		}
		#endregion
	}
}

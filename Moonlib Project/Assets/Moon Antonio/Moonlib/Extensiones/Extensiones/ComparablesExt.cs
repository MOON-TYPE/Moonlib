//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ComparablesExt.cs (04/04/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Extension para comparaciones.								\\
// Fecha Mod:		04/04/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonAntonio.Moonlib.Extensiones
{
	/// <summary>
	/// <para>Extension para comparaciones.</para>
	/// </summary>
	public static class ComparablesExt 
	{
		#region API
		/// <summary>
		/// <para>Devuelve true si el valor real es entre menor y mayor, Inclusivo (es decir, se permiten ambos en la prueba).</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="actual">Valor actual.</param>
		/// <param name="menor">Limite valor menor.</param>
		/// <param name="mayor">Limite valor mayor.</param>
		/// <returns></returns>
		public static bool IsEntreInclusivo<T>(this T actual, T menor, T mayor) where T : IComparable<T>
		{
			return actual.CompareTo(menor) >= 0 && actual.CompareTo(mayor) <= 0;
		}

		/// <summary>
		/// <para>Devuelve true si el valor real esta entre menor y mayor, exclusivo (es decir, mas bajo permitido en la prueba, mayor no esta permitido en la prueba)</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="actual">Valor actual.</param>
		/// <param name="menor">Limite valor menor.</param>
		/// <param name="mayor">Limite valor mayor.</param>
		/// <returns></returns>
		public static bool IsEntreExclusivo<T>(this T actual, T menor, T mayor) where T : IComparable<T>
		{
			return actual.CompareTo(menor) >= 0 && actual.CompareTo(mayor) < 0;
		}
		#endregion
	}
}

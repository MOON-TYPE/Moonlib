//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// NotImplementedByException.cs (21/03/2018)									\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Una version de NotImplementedException.						\\
// Fecha Mod:		21/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Una version de NotImplementedException.</para>
	/// </summary>
	public class NotImplementedByException : NotImplementedException
	{
		/// <summary>
		/// <para>Inicializa una nueva instancia de <see cref="NotImplementedByException"/>.</para>
		/// </summary>
		/// <param name="type">El tipo de la clase que arroja esta excepcion.</param>
		/// <code>
		/// [Abstract]
		/// public class BaseClass
		/// {
		///		[Abstract]
		///		public virtual void Method()
		///		{
		///			throw new NotImplementedBy(GetType());
		///		}
		/// }
		/// 
		/// public class DerivedClass : BaseClass { }
		/// </code>
		/// </example>
		public NotImplementedByException(Type type) : base("No implementado por " + type) // Inicializa una nueva instancia de NotImplementedByException
		{

		}
	}
}

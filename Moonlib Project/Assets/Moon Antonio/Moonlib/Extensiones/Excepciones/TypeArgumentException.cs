//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TypeArgumentException.cs (21/03/2018)										\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Una version de TypeArgumentException. 						\\
// Fecha Mod:		21/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Una version de TypeArgumentException.</para>
	/// </summary>
	public class TypeArgumentException : Exception 
	{
		public readonly string parameterName;

		public TypeArgumentException(string message) : base(message)
		{
			parameterName = "";
		}

		public TypeArgumentException(string parameterName, string message) : base(string.Format("{0}\nNombre Parametro: {1}", message, parameterName))
		{
			this.parameterName = parameterName;
		}
	}
}

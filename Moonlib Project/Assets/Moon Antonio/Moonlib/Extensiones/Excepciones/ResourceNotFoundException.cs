//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ResourceNotFoundException.cs (21/03/2018)									\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Una version de ResourceNotFoundException.					\\
// Fecha Mod:		21/03/2018													\\
// Ultima Mod:		Verrsion Inicial											\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Una version de ResourceNotFoundException.</para>
	/// </summary>
	public class ResourceNotFoundException : Exception 
	{
		public string resourceName;
		public string resourcePath;

		public ResourceNotFoundException() : base("Resource no encontrado")
		{

		}

		public ResourceNotFoundException(string resourceName) : base(string.Format("Resource '{0}' no encontrado", resourceName))
		{
			this.resourceName = resourceName;
		}

		public ResourceNotFoundException(string resourceName, string resourcePath) : base(string.Format("Resource '{0}' no encontrado en '{1}'", resourceName, resourcePath))
		{
			this.resourceName = resourceName;
			this.resourcePath = resourcePath;
		}

		public ResourceNotFoundException(string resourceName, string resourcePath, string message) : base(message)
		{
			this.resourceName = resourceName;
			this.resourcePath = resourcePath;
		}
	}
}

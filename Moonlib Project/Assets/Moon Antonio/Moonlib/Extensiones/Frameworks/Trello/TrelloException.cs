//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TrelloException.cs (20/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Clase base de excepciones para Trello.						\\
// Fecha Mod:		20/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
#endregion

namespace MoonAntonio.Moonlib.Trello
{
	/// <summary>
	/// <para>Clase base de excepciones para Trello.</para>
	/// </summary>
	public class TrelloException : Exception
	{
		#region Metodos
		public TrelloException() : base()
		{

		}

		public TrelloException(string message) : base(message)
		{

		}

		public TrelloException(string format, params object[] args) : base(string.Format(format, args))
		{

		}

		public TrelloException(string message, Exception innerException) : base(message, innerException)
		{

		}

		public TrelloException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
		{

		}
		#endregion
	}
}

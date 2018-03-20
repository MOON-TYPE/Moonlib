//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TrelloCard.cs (20/03/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Clase base de las tarjetas de trello.						\\
// Fecha Mod:		20/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

namespace MoonAntonio.Moonlib.Trello
{
	/// <summary>
	/// <para>Clase base de las tarjetas de trello.</para>
	/// </summary>
	public class TrelloCard
	{
		#region Variables
		public string name = "";
		public string desc = "";
		public string pos = "bottom";
		public string due = "null";
		public string idList = "";
		public string urlSource = "null";
		#endregion

		#region Constructor
		public TrelloCard()
		{

		}
		#endregion
	}
}

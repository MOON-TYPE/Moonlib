//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TrelloList.cs (20/03/2018)													\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Clase base de las listas de trello.							\\
// Fecha Mod:		20/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

namespace MoonAntonio.Moonlib.Trello
{
	/// <summary>
	/// <para>Clase base de las listas de trello.</para>
	/// </summary>
	public class TrelloList
	{
		#region Variables Publicas
		public string name = "";
		public string idBoard = "";
		public string pos = "bottom";
		#endregion

		#region Constructor
		public TrelloList()
		{

		}
		#endregion
	}
}

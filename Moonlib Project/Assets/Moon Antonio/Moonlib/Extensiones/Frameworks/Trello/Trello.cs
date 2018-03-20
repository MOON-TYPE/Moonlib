//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Trello.cs (20/03/2018)														\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Clase con la funcionalidad de Trello.						\\
// Fecha Mod:		20/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.MiniJSON;
#endregion

namespace MoonAntonio.Moonlib.Trello
{
	/// <summary>
	/// <para>Clase con la funcionalidad de Trello.</para>
	/// </summary>
	public class Trello 
	{
		#region Constantes
		private const string memberBaseUrl = "https://api.trello.com/1/members/me";
		private const string boardBaseUrl = "https://api.trello.com/1/boards/";
		private const string listBaseUrl = "https://api.trello.com/1/lists/";
		private const string cardBaseUrl = "https://api.trello.com/1/cards/";
		#endregion

		#region Variables Privadas
		private string token;
		private string key;
		private List<object> boards;
		private List<object> lists;
		private List<object> cards;
		private string currentBoardId = "";
		private Dictionary<string, string> cachedLists = new Dictionary<string, string>();
		#endregion

		#region Constructor
		public Trello(string key, string token)
		{
			this.key = key;
			this.token = token;
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Comprueba si un objeto WWW ha resultado en un error, y si es asi arroja una excepcion para tratarlo.</para>
		/// </summary>
		/// <param name="errorMessage">Error.</param>
		/// <param name="www">Objeto.</param>
		private void CheckWwwStatus(string errorMessage, WWW www)
		{
			if (!string.IsNullOrEmpty(www.error))
			{
				throw new TrelloException(errorMessage + ": " + www.error);
			}
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Comprueba si la lista Trello ya ha sido almacenada en cache.</para>
		/// </summary>
		/// <param name="listName">El nombre de la lista para verificar.</param>
		/// <returns>True si la lista ha sido almacenada en cache.</returns>
		public bool IsListCached(string listName)
		{
			return cachedLists.ContainsKey(listName);
		}

		/// <summary>
		/// <para>[Async] Descarga una lista JSON analizada de las tarjetas en la cuenta de los usuarios, estas se almacenan en cache en "boards".</para>
		/// </summary>
		public IEnumerator PopulateBoardsRoutine()
		{
			boards = null;
			WWW www = new WWW(memberBaseUrl + "?" + "key=" + key + "&token=" + token + "&boards=all");

			yield return www;
			CheckWwwStatus("[Trello] La conexion a los servidores de Trello no fue posible", www);

			var dict = Json.Deserialize(www.text) as Dictionary<string, object>;

			boards = (List<object>)dict["boards"];
		}

		/// <summary>
		/// <para>Busca el tablero en "boards" y si lo encuentra lo configura como el tablero actual.</para>
		/// </summary>
		/// <param name="name">Nombre del tablero.</param>
		public void SetCurrentBoard(string name)
		{
			if (boards == null)
			{
				throw new TrelloException("[Trello] Aun no ha completado la lista de tableros, por lo que no se puede seleccionar uno.");
			}

			for (int i = 0; i < boards.Count; i++)
			{
				var board = (Dictionary<string, object>)boards[i];
				if ((string)board["name"] == name)
				{
					currentBoardId = (string)board["id"];
					return;
				}
			}

			currentBoardId = "";
			throw new TrelloException("[Trello] No se encontro el tablero.");
		}

		/// <summary>
		/// <para>[Async] completa las listas que posee la placa actual, estas se guardan en la memoria cache para una carga mas rapida de la tarjeta.</para>
		/// <para>Las listas de Trello provienen de trello como una lista de listas JSON analizadas.</para>
		/// </summary>
		public IEnumerator PopulateListsRoutine()
		{
			lists = null;
			if (currentBoardId == "")
			{
				throw new TrelloException("[Trello] No se pueden recuperar las listas, aun no ha seleccionado un tablero.");
			}

			WWW www = new WWW(boardBaseUrl + currentBoardId + "?" + "key=" + key + "&token=" + token + "&lists=all");

			yield return www;
			CheckWwwStatus("[Trello] La conexion a los servidores de Trello no fue posible", www);

			var dict = Json.Deserialize(www.text) as Dictionary<string, object>;

			lists = (List<object>)dict["lists"];

			// Cache de las listas
			for (int i = 0; i < lists.Count; i++)
			{
				var list = (Dictionary<string, object>)lists[i];
				if (IsListCached((string)list["name"])) continue;
				cachedLists.Add((string)list["name"], (string)list["id"]);
			}
		}

		/// <summary>
		/// <para>[Async] Llena las tarjetas para la lista actual, estas se guardan en la memoria cache para cargarlas mas fácilmente.</para>
		/// <para>Obtiene de trello una lista de tarjetas JSON analizadas.</para>
		/// </summary>
		public IEnumerator PopulateCardsFromListRoutine(string listId)
		{
			cards = null;
			if (listId == "")
			{
				throw new TrelloException("[Trello] No se pueden recuperar las tarjetas, aun no ha seleccionado una lista.");
			}

			WWW www = new WWW(listBaseUrl + listId + "?" + "key=" + key + "&token=" + token + "&cards=all");

			yield return www;
			CheckWwwStatus("[Trello] Algo salio mal: ", www);

			var dict = Json.Deserialize(www.text) as Dictionary<string, object>;
			cards = (List<object>)dict["cards"];
		}

		/// <summary>
		/// <para>Crea una nueva tarjeta Trello.</para>
		/// </summary>
		/// <returns>La tarjeta.</returns>
		/// <param name="listName">Nombre de la lista de trello a la que pertenecera la tarjeta.</param>
		public TrelloCard NewCard(string listName)
		{
			string currentListId = "";

			if (IsListCached(listName))
			{
				currentListId = cachedLists[listName];
			}
			else
			{
				throw new TrelloException("[Trello] Lista especificada no encontrada.");
			}

			var card = new TrelloCard();
			card.idList = currentListId;
			return card;
		}

		/// <summary>
		/// <para>Crea una nueva tarjeta Trello.</para>
		/// </summary>
		/// <returns>La tarjeta.</returns>
		/// <param name="title">Nombre de la tarjeta.</param>
		/// <param name="description">Descripcion de la tarjeta.</param>
		/// <param name="listName">Nombre de la lista trello a la que pertenecera la tarjeta.</param>
		/// <param name="newCardsOnTop">¿Deberia colocarse la tarjeta en la parte superior de la lista?</param>
		public TrelloCard NewCard(string title, string description, string listName, bool newCardsOnTop = true)
		{
			var card = NewCard(listName);
			card.name = title;
			card.desc = description;
			if (newCardsOnTop) card.pos = "top";
			return card;
		}

		/// <summary>
		/// <para>Crea un nuevo objeto de lista Trello, con la ID del board actual.</para>
		/// <para>No carga la lista.</para>
		/// </summary>
		/// <returns>La lista de objetos.</returns>
		public TrelloList NewList()
		{
			if (currentBoardId == "")
			{
				throw new TrelloException("[Trello] No se puede crear una lista si no hay un board seleccionado.");
			}

			var list = new TrelloList();
			list.idBoard = currentBoardId;
			return list;
		}

		/// <summary>
		/// <para>Crea un nuevo objeto de lista Trello, con la ID del board actual.</para>
		/// </summary>
		/// <returns>La lista de objetos.</returns>
		/// <param name="name">Nombre de la lista.</param>
		public TrelloList NewList(string name)
		{
			var list = NewList();
			list.name = name;
			return list;
		}

		/// <summary>
		/// <para>[Async] Carga un objeto TrelloCard dado a los servidores de Trello.</para>
		/// </summary>
		/// <returns>Tu card ID.</returns>
		/// <param name="card">La card a cargar.</param>
		public IEnumerator UploadCardRoutine(TrelloCard card)
		{
			WWWForm post = new WWWForm();
			post.AddField("name", card.name);
			post.AddField("desc", card.desc);
			post.AddField("pos", card.pos);
			post.AddField("due", card.due);
			post.AddField("idList", card.idList);

			WWW www = new WWW(cardBaseUrl + "?" + "key=" + key + "&token=" + token, post);
			yield return www;
			CheckWwwStatus("[Trello] No se pudo cargar una nueva tarjeta a Trello", www);

			var dict = Json.Deserialize(www.text) as Dictionary<string, object>;

			yield return (string)dict["id"];
		}

		/// <summary>
		/// <para>[Async] Carga un objeto TrelloList dado al board seleccionado actualmente.</para>
		/// </summary>
		/// <returns>Tu list ID.</returns>
		/// <param name="list">La lista a cargar.</param>
		public IEnumerator UploadListRoutine(TrelloList list)
		{
			WWWForm post = new WWWForm();
			post.AddField("name", list.name);
			post.AddField("idBoard", list.idBoard);
			post.AddField("pos", list.pos);

			WWW www = new WWW(listBaseUrl + "?" + "key=" + key + "&token=" + token, post);
			yield return www;
			CheckWwwStatus("[Trello] No se pudo cargar la nueva lista a Trello", www);

			var dict = Json.Deserialize(www.text) as Dictionary<string, object>;

			yield return (string)dict["id"];
		}

		/// <summary>
		/// <para>[Async] Rellena las tarjetas para la lista actual, estas se almacenan en cache para facilitar la carga de archivos adjuntos mas tarde.</para>
		/// </summary>
		/// <returns>Una lista de tarjetas JSON analizadas.</returns>
		public bool IsConnected()
		{
			return (currentBoardId != "") ? true : false;
		}
		#endregion
	}
}

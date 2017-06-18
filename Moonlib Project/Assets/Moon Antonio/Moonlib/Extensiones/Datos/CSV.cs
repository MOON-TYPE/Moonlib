//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CSV.cs (18/06/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) antoniomt.moon@gmail.com					\\
// Descripcion:		Extension de datos para archivos CSV						\\
// Fecha Mod:		18/06/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.IO;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Clase Custom KeyList utilizada para almacenar una clave y una lista de valores.</para>
	/// </summary>
	public class KeyList
	{
		#region Variables Privadas
		/// <summary>
		/// <para>La lista de strings se almacena como lista.</para>
		/// </summary>
		private List<string> list = new List<string>();		// La lista de strings se almacena como lista
		/// <summary>
		/// <para>La key de strings se almacena como key.</para>
		/// </summary>
		private string key = "";							// La key de strings se almacena como strings
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="KeyList"/>.</para>
		/// </summary>
		/// <param name="Key">Clave</param>
		public KeyList(string thisKey)// Constructor de KeyList
		{
			key = thisKey;
		}
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Lista</para>
		/// </summary>
		public List<string> List
		{
			get
			{
				return list;
			}
			set
			{
				list = value;
			}
		}

		/// <summary>
		/// <para>LLave</para>
		/// </summary>
		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		/// <summary>
		/// <para>Obtiene la longitud de la lista.</para>
		/// </summary>
		public int Length
		{
			get
			{
				return list.Count;
			}
		}
		#endregion
	}

	/// <summary>
	/// <para>Extension de datos para archivos CSV</para>
	/// </summary>
	public class CSV
	{
		#region Variables
		/// <summary>
		/// <para>La tabla almacena una lista de valores de KeyList, funcionando eficazmente como una matriz 2D con una clave para cada matriz almacenada.</para>
		/// </summary>
		public List<KeyList> tabla = new List<KeyList>();		// La tabla almacena una lista de valores de KeyList, funcionando eficazmente como una matriz 2D con una clave para cada matriz almacenada
		/// <summary>
		/// <para>Lista de claves utilizadas para encontrar claves referenciadas, especificadas en el CSV.</para>
		/// </summary>
		public string[] keys;									// Lista de claves utilizadas para encontrar claves referenciadas, especificadas en el CSV

		#endregion

		#region Constructores
		/// <summary>
		/// <para>Constructor cuando la clase se declara sin parametros, todas las variables internas estan vacias.</para>
		/// </summary>
		/// <param name="titulos">Internos</param>
		public CSV(string[] titulos) { } // Constructor cuando la clase se declara sin parametros, todas las variables internas estan vacias

		/// <summary>
		/// <para>Constructor que toma la ubicacion del archivo como una cadena en la declaracion.</para>
		/// </summary>
		/// <param name="file">Archivo</param>
		public CSV(string file)// Constructor que toma la ubicacion del archivo como una cadena en la declaracion
		{
			// Lee todas las lineas del archivo y las divide en filas de cadenas.
			string[] rows = File.ReadAllLines(file);

			// Obtiene todas las claves de cada una de las filas.
			keys = rows[0].Split(',');

			// Toma cada una de las claves de la matriz y modifica la tabla de acuerdo con las nuevas claves.
			foreach (string key in keys)
			{
				KeyList newList = new KeyList(key);
				tabla.Add(newList);
			}

			// Itera a traves de cada una de las filas y rellena en cada lista de KeyLists.
			for (int row = 1; row < rows.Length; row++)
			{
				string[] values = rows[row].Split(',');
				for (int value = 0; value < values.Length; value++)
				{
					tabla[value].List.Add(values[value]);
				}
			}
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Obtiene la columna con la clave "keyName".</para>
		/// </summary>
		/// <param name="keyName">Nombre de la clave</param>
		/// <returns></returns>
		public List<string> GetColumn(string keyName)// Obtiene la columna con la clave "keyName"
		{
			foreach (KeyList list in tabla)
			{
				if (list.Key == keyName)
					return list.List;
			}
			return null;
		}

		/// <summary>
		/// <para>Toma un indice y devuelve la clave correspondiente.</para>
		/// </summary>
		/// <param name="index">Indice</param>
		/// <returns>Clave correspondiente.</returns>
		public string IndexToKey(int index)// Toma un indice y devuelve la clave correspondiente
		{
			foreach (KeyList list in tabla)
			{
				if (list.Key == keys[index])
					return list.Key;
			}
			return null;
		}

		/// <summary>
		/// <para>Toma una cadena y almacena un archivo CSV en la ubicacion especificada, tomando sus valores de la tabla.</para>
		/// </summary>
		/// <param name="ruta">Ruta de guardado.</param>
		public void Save(string ruta)// Toma una cadena y almacena un archivo CSV en la ubicacion especificada, tomando sus valores de la tabla
		{
			// Declara una cadena para escribir cada una de las lineas en el contenido CSV.
			string writer = string.Join(",", keys) + "\n";

			// Obtiene el indice de la fila mas larga.
			int longestRow = 0;

			// Recorre la lista
			foreach (KeyList list in tabla)
			{
				if (list.Length > longestRow)
				{
					longestRow = list.Length;
				}
			}

			// Itera a traves de las filas y analiza la tabla en columnas.
			for (int row = 0; row < longestRow; row++)
			{
				for (int key = 0; key < keys.Length; key++)
				{
					writer = writer + tabla[key].List[row];
					if (key < keys.Length - 1)
					{
						writer = writer + ",";
					}
				}
				if (row < longestRow - 1)
				{
					writer = writer + "\n";
				}
			}

			// Escribe la cadena en un archivo.
			File.WriteAllText(ruta, writer);
		}
		#endregion
	}
}

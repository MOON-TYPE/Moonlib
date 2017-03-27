//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DebugEx.cs (27/03/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Extension de Debug de Unity									\\
// Fecha Mod:		27/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Extension de Debug de Unity</para>
	/// </summary>
	public static class DebugEx 
	{
		#region Log
		/// <summary>
		/// <para>Imprime un mensaje por consola.</para>
		/// </summary>
		/// <param name="msg">El mensaje a imprimir.</param>
		public static void Log(string msg)// Imprime un mensaje por consola
		{
			Debug.Log(msg);
		}

		/// <summary>
		/// <para>Imprime un mensaje por consola con un header [{0}].</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir.</param>
		/// <param name="header">Texto del header</param>
		public static void Log(string msg, string header)// Imprime un mensaje por consola con un header [{0}]
		{
			Debug.Log("[" + header + "] " + msg);
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color por consola y un header.</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir por consola.</param>
		/// <param name="header">Texto del header.</param>
		/// <param name="color">Color del texto del mensaje.</param>
		public static void Log(string msg, string header, Color color)// Imprime un mensaje con un color por consola y un header
		{
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("[" + header + "] " + "<color=#ff0000ff>" + msg + "</color>");
					break;

				case Color.Verde:
					Debug.Log("[" + header + "] " + "<color=#00ff00ff>" + msg + "</color>");
					break;

				case Color.Azul:
					Debug.Log("[" + header + "] " + "<color=#0000a0ff>" + msg + "</color>");
					break;

				case Color.Morado:
					Debug.Log("[" + header + "] " + "<color=#800080ff>" + msg + "</color>");
					break;

				case Color.Naranja:
					Debug.Log("[" + header + "] " + "<color=#ffa500ff>" + msg + "</color>");
					break;

				case Color.Cyan:
					Debug.Log("[" + header + "] " + "<color=#00ffffff>" + msg + "</color>");
					break;

				case Color.Blanco:
					Debug.Log("[" + header + "] " + msg);
					break;

				case Color.Negro:
					Debug.Log("[" + header + "] " + "<color=#000000ff>" + msg + "</color>");
					break;

				default:
					Debug.Log("[" + header + "] " + msg);
					break;
			}
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color y un estilo por consola con un header.</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir.</param>
		/// <param name="header">Texto del header.</param>
		/// <param name="color">Color del mensaje.</param>
		/// <param name="estilo">Estilo del mensaje.</param>
		public static void Log(string msg, string header, Color color, Estilo estilo)// Imprime un mensaje con un color y un estilo por consola con un header
		{
			#region Estilo Normal
			if (estilo == Estilo.Normal)
			{
				switch (color)
				{
					case Color.Rojo:
						Debug.Log("[" + header + "] " + "<color=#ff0000ff>" + msg + "</color>");
						break;

					case Color.Verde:
						Debug.Log("[" + header + "] " + "<color=#00ff00ff>" + msg + "</color>");
						break;

					case Color.Azul:
						Debug.Log("[" + header + "] " + "<color=#0000a0ff>" + msg + "</color>");
						break;

					case Color.Morado:
						Debug.Log("[" + header + "] " + "<color=#800080ff>" + msg + "</color>");
						break;

					case Color.Naranja:
						Debug.Log("[" + header + "] " + "<color=#ffa500ff>" + msg + "</color>");
						break;

					case Color.Cyan:
						Debug.Log("[" + header + "] " + "<color=#00ffffff>" + msg + "</color>");
						break;

					case Color.Blanco:
						Debug.Log("[" + header + "] " + msg);
						break;

					case Color.Negro:
						Debug.Log("[" + header + "] " + "<color=#000000ff>" + msg + "</color>");
						break;

					default:
						Debug.Log("[" + header + "] " + msg);
						break;
				}
			}
			#endregion

			#region Estilo Negrita
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("[" + header + "] " + "<color=#ff0000ff><b>" + msg + "</b></color>");
					break;

				case Color.Verde:
					Debug.Log("[" + header + "] " + "<color=#00ff00ff><b>" + msg + "</b></color>");
					break;

				case Color.Azul:
					Debug.Log("[" + header + "] " + "<color=#0000a0ff><b>" + msg + "</b></color>");
					break;

				case Color.Morado:
					Debug.Log("[" + header + "] " + "<color=#800080ff><b>" + msg + "</b></color>");
					break;

				case Color.Naranja:
					Debug.Log("[" + header + "] " + "<color=#ffa500ff><b>" + msg + "</b></color>");
					break;

				case Color.Cyan:
					Debug.Log("[" + header + "] " + "<color=#00ffffff><b>" + msg + "</b></color>");
					break;

				case Color.Blanco:
					Debug.Log("[" + header + "] " + "<b>" + msg + "</b>");
					break;

				case Color.Negro:
					Debug.Log("[" + header + "] " + "<color=#000000ff><b>" + msg + "</b></color>");
					break;

				default:
					Debug.Log("[" + header + "] " + "<b>" + msg + "</b>");
					break;
			}
			#endregion

			#region Italico
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("[" + header + "] " + "<color=#ff0000ff><i>" + msg + "</i></color>");
					break;

				case Color.Verde:
					Debug.Log("[" + header + "] " + "<color=#00ff00ff><i>" + msg + "</i></color>");
					break;

				case Color.Azul:
					Debug.Log("[" + header + "] " + "<color=#0000a0ff><i>" + msg + "</i></color>");
					break;

				case Color.Morado:
					Debug.Log("[" + header + "] " + "<color=#800080ff><i>" + msg + "</i></color>");
					break;

				case Color.Naranja:
					Debug.Log("[" + header + "] " + "<color=#ffa500ff><i>" + msg + "</i></color>");
					break;

				case Color.Cyan:
					Debug.Log("[" + header + "] " + "<color=#00ffffff><i>" + msg + "</i></color>");
					break;

				case Color.Blanco:
					Debug.Log("[" + header + "] " + "<i>" + msg + "</i>");
					break;

				case Color.Negro:
					Debug.Log("[" + header + "] " + "<color=#000000ff><i>" + msg + "</i></color>");
					break;

				default:
					Debug.Log("[" + header + "] " + "<i>" + msg + "</i>");
					break;
			}
			#endregion
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color por consola.</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir.</param>
		/// <param name="color">Color del texto del mensaje.</param>
		public static void Log(string msg, Color color)// Imprime un mensaje con un color por consola
		{
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("<color=#ff0000ff>" + msg + "</color>");
					break;

				case Color.Verde:
					Debug.Log("<color=#00ff00ff>" + msg + "</color>");
					break;

				case Color.Azul:
					Debug.Log("<color=#0000a0ff>" + msg + "</color>");
					break;

				case Color.Morado:
					Debug.Log("<color=#800080ff>" + msg + "</color>");
					break;

				case Color.Naranja:
					Debug.Log("<color=#ffa500ff>" + msg + "</color>");
					break;

				case Color.Cyan:
					Debug.Log("<color=#00ffffff>" + msg + "</color>");
					break;

				case Color.Blanco:
					Debug.Log(msg);
					break;

				case Color.Negro:
					Debug.Log("<color=#000000ff>" + msg + "</color>");
					break;

				default:
					Debug.Log(msg);
					break;
			}
			
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color y un estilo por consola.</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir.</param>
		/// <param name="color">Color del texto del mensaje.</param>
		/// <param name="estilo">Estilo del texto del mensaje.</param>
		public static void Log(string msg, Color color, Estilo estilo)// Imprime un mensaje con un color y un estilo por consola
		{
			#region Estilo Normal
			if (estilo == Estilo.Normal)
			{
				switch (color)
				{
					case Color.Rojo:
						Debug.Log("<color=#ff0000ff>" + msg + "</color>");
						break;

					case Color.Verde:
						Debug.Log("<color=#00ff00ff>" + msg + "</color>");
						break;

					case Color.Azul:
						Debug.Log("<color=#0000a0ff>" + msg + "</color>");
						break;

					case Color.Morado:
						Debug.Log("<color=#800080ff>" + msg + "</color>");
						break;

					case Color.Naranja:
						Debug.Log("<color=#ffa500ff>" + msg + "</color>");
						break;

					case Color.Cyan:
						Debug.Log("<color=#00ffffff>" + msg + "</color>");
						break;

					case Color.Blanco:
						Debug.Log(msg);
						break;

					case Color.Negro:
						Debug.Log("<color=#000000ff>" + msg + "</color>");
						break;

					default:
						Debug.Log(msg);
						break;
				}
			}
			#endregion

			#region Estilo Negrita
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("<color=#ff0000ff><b>" + msg + "</b></color>");
					break;

				case Color.Verde:
					Debug.Log("<color=#00ff00ff><b>" + msg + "</b></color>");
					break;

				case Color.Azul:
					Debug.Log("<color=#0000a0ff><b>" + msg + "</b></color>");
					break;

				case Color.Morado:
					Debug.Log("<color=#800080ff><b>" + msg + "</b></color>");
					break;

				case Color.Naranja:
					Debug.Log("<color=#ffa500ff><b>" + msg + "</b></color>");
					break;

				case Color.Cyan:
					Debug.Log("<color=#00ffffff><b>" + msg + "</b></color>");
					break;

				case Color.Blanco:
					Debug.Log("<b>" + msg + "</b>");
					break;

				case Color.Negro:
					Debug.Log("<color=#000000ff><b>" + msg + "</b></color>");
					break;

				default:
					Debug.Log("<b>" + msg + "</b>");
					break;
			}
			#endregion

			#region Italico
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("<color=#ff0000ff><i>" + msg + "</i></color>");
					break;

				case Color.Verde:
					Debug.Log("<color=#00ff00ff><i>" + msg + "</i></color>");
					break;

				case Color.Azul:
					Debug.Log("<color=#0000a0ff><i>" + msg + "</i></color>");
					break;

				case Color.Morado:
					Debug.Log("<color=#800080ff><i>" + msg + "</i></color>");
					break;

				case Color.Naranja:
					Debug.Log("<color=#ffa500ff><i>" + msg + "</i></color>");
					break;

				case Color.Cyan:
					Debug.Log("<color=#00ffffff><i>" + msg + "</i></color>");
					break;

				case Color.Blanco:
					Debug.Log("<i>" + msg + "</i>");
					break;

				case Color.Negro:
					Debug.Log("<color=#000000ff><i>" + msg + "</i></color>");
					break;

				default:
					Debug.Log("<i>" + msg + "</i>");
					break;
			}
			#endregion
		}
		#endregion

		#region LogWarning
		// TODO Implementar la funcionalidad de Log Warning
		#endregion

		#region LogError
		// TODO Implementar la funcionalidad de Log Error
		#endregion

		#region MLog
		/// <summary>
		/// <para>Imprime por consola un mensaje.</para>
		/// </summary>
		/// <param name="msg">Texto a imprimir por consola.</param>
		public static void MLog(string msg)// Imprime por consola un mensaje
		{
			Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + msg);
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color y un estilo por consola.</para>
		/// </summary>
		/// <param name="msg">Mensaje a imprimir.</param>
		/// <param name="color">Color del texto a imprimir.</param>
		/// <param name="estilo">Estilo del texto a imprimir.</param>
		public static void MLog(string msg, Color color, Estilo estilo)// Imprime un mensaje con un color y un estilo por consola
		{
			#region Estilo Normal
			if (estilo == Estilo.Normal)
			{
				switch (color)
				{
					case Color.Rojo:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ff0000ff>" + msg + "</color>");
						break;

					case Color.Verde:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ff00ff>" + msg + "</color>");
						break;

					case Color.Azul:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#0000a0ff>" + msg + "</color>");
						break;

					case Color.Morado:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#800080ff>" + msg + "</color>");
						break;

					case Color.Naranja:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ffa500ff>" + msg + "</color>");
						break;

					case Color.Cyan:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ffffff>" + msg + "</color>");
						break;

					case Color.Blanco:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + msg);
						break;

					case Color.Negro:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#000000ff>" + msg + "</color>");
						break;

					default:
						Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + msg);
						break;
				}
			}
			#endregion

			#region Estilo Negrita
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ff0000ff><b>" + msg + "</b></color>");
					break;

				case Color.Verde:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ff00ff><b>" + msg + "</b></color>");
					break;

				case Color.Azul:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#0000a0ff><b>" + msg + "</b></color>");
					break;

				case Color.Morado:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#800080ff><b>" + msg + "</b></color>");
					break;

				case Color.Naranja:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ffa500ff><b>" + msg + "</b></color>");
					break;

				case Color.Cyan:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ffffff><b>" + msg + "</b></color>");
					break;

				case Color.Blanco:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<b>" + msg + "</b>");
					break;

				case Color.Negro:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#000000ff><b>" + msg + "</b></color>");
					break;

				default:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<b>" + msg + "</b>");
					break;
			}
			#endregion

			#region Italico
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ff0000ff><i>" + msg + "</i></color>");
					break;

				case Color.Verde:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ff00ff><i>" + msg + "</i></color>");
					break;

				case Color.Azul:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#0000a0ff><i>" + msg + "</i></color>");
					break;

				case Color.Morado:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#800080ff><i>" + msg + "</i></color>");
					break;

				case Color.Naranja:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#ffa500ff><i>" + msg + "</i></color>");
					break;

				case Color.Cyan:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#00ffffff><i>" + msg + "</i></color>");
					break;

				case Color.Blanco:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<i>" + msg + "</i>");
					break;

				case Color.Negro:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<color=#000000ff><i>" + msg + "</i></color>");
					break;

				default:
					Debug.Log("<color=#00ff00ff><b>[LOG]</b></color> -" + "<i>" + msg + "</i>");
					break;
			}
			#endregion
		}

		/// <summary>
		/// <para>Imprime un mensaje con un color y un estilo con un header por consola.</para>
		/// </summary>
		/// <param name="header">Header del mensaje.</param>
		/// <param name="msg">Mensaje a imprimir por consola.</param>
		/// <param name="color">Color del texto del mensaje a imprimir.</param>
		/// <param name="estilo">Estilo del texto del mensaje a imprimir.</param>
		public static void MLog(string header, string msg, Color color, Estilo estilo)// Imprime un mensaje con un color y un estilo con un header por consola
		{
			#region Estilo Normal
			if (estilo == Estilo.Normal)
			{
				switch (color)
				{
					case Color.Rojo:
						Debug.Log("[" + header + "] " + "<color=#ff0000ff>" + msg + "</color>");
						break;

					case Color.Verde:
						Debug.Log("[" + header + "] " + "<color=#00ff00ff>" + msg + "</color>");
						break;

					case Color.Azul:
						Debug.Log("[" + header + "] " + "<color=#0000a0ff>" + msg + "</color>");
						break;

					case Color.Morado:
						Debug.Log("[" + header + "] " + "<color=#800080ff>" + msg + "</color>");
						break;

					case Color.Naranja:
						Debug.Log("[" + header + "] " + "<color=#ffa500ff>" + msg + "</color>");
						break;

					case Color.Cyan:
						Debug.Log("[" + header + "] " + "<color=#00ffffff>" + msg + "</color>");
						break;

					case Color.Blanco:
						Debug.Log("[" + header + "] " + msg);
						break;

					case Color.Negro:
						Debug.Log("[" + header + "] " + "<color=#000000ff>" + msg + "</color>");
						break;

					default:
						Debug.Log("[" + header + "] " + msg);
						break;
				}
			}
			#endregion

			#region Estilo Negrita
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("[" + header + "] " + "<color=#ff0000ff><b>" + msg + "</b></color>");
					break;

				case Color.Verde:
					Debug.Log("[" + header + "] " + "<color=#00ff00ff><b>" + msg + "</b></color>");
					break;

				case Color.Azul:
					Debug.Log("[" + header + "] " + "<color=#0000a0ff><b>" + msg + "</b></color>");
					break;

				case Color.Morado:
					Debug.Log("[" + header + "] " + "<color=#800080ff><b>" + msg + "</b></color>");
					break;

				case Color.Naranja:
					Debug.Log("[" + header + "] " + "<color=#ffa500ff><b>" + msg + "</b></color>");
					break;

				case Color.Cyan:
					Debug.Log("[" + header + "] " + "<color=#00ffffff><b>" + msg + "</b></color>");
					break;

				case Color.Blanco:
					Debug.Log("[" + header + "] " + "<b>" + msg + "</b>");
					break;

				case Color.Negro:
					Debug.Log("[" + header + "] " + "<color=#000000ff><b>" + msg + "</b></color>");
					break;

				default:
					Debug.Log("[" + header + "] " + "<b>" + msg + "</b>");
					break;
			}
			#endregion

			#region Italico
			switch (color)
			{
				case Color.Rojo:
					Debug.Log("[" + header + "] " + "<color=#ff0000ff><i>" + msg + "</i></color>");
					break;

				case Color.Verde:
					Debug.Log("[" + header + "] " + "<color=#00ff00ff><i>" + msg + "</i></color>");
					break;

				case Color.Azul:
					Debug.Log("[" + header + "] " + "<color=#0000a0ff><i>" + msg + "</i></color>");
					break;

				case Color.Morado:
					Debug.Log("[" + header + "] " + "<color=#800080ff><i>" + msg + "</i></color>");
					break;

				case Color.Naranja:
					Debug.Log("[" + header + "] " + "<color=#ffa500ff><i>" + msg + "</i></color>");
					break;

				case Color.Cyan:
					Debug.Log("[" + header + "] " + "<color=#00ffffff><i>" + msg + "</i></color>");
					break;

				case Color.Blanco:
					Debug.Log("[" + header + "] " + "<i>" + msg + "</i>");
					break;

				case Color.Negro:
					Debug.Log("[" + header + "] " + "<color=#000000ff><i>" + msg + "</i></color>");
					break;

				default:
					Debug.Log("[" + header + "] " + "<i>" + msg + "</i>");
					break;
			}
			#endregion
		}
		#endregion
	}

	/// <summary>
	/// <para>Colores disponibles</para>
	/// </summary>
	public enum Color
	{
		Rojo,
		Verde,
		Azul,
		Morado,
		Naranja,
		Cyan,
		Blanco,
		Negro
	}

	/// <summary>
	/// <para>Estilos disponibles</para>
	/// </summary>
	public enum Estilo
	{
		Normal,
		Negrita,
		Italico,
	}
}

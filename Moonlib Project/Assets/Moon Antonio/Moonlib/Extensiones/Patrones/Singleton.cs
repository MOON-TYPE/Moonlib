//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Singleton.cs (11/03/2018)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Implementacion generica de Singleton MonoBehaviour			\\
// Fecha Mod:		11/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Implementacion generica de Singleton MonoBehaviour.</para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Singleton<T> : MLMonoBehaviour where T : MonoBehaviour
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Instancia del singleton.</para>
		/// </summary>
		protected static T instance;												// Instancia del singleton
		#endregion

		#region  Propiedades
		/// <summary>
		/// <para>Devuelve la instancia de este singleton.</para>
		/// </summary>
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = (T)FindObjectOfType(typeof(T));

					if (instance == null)
					{
						Debug.LogError("Una instancia de " + typeof(T) + " es necesaria en la escena, pero no hay ninguno.");
					}
				}

				return instance;
			}
		}
		#endregion
	}
}
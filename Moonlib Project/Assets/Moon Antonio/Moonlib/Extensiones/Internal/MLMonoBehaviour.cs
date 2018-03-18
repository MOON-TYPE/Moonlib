//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Singleton.cs (11/03/2018)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Proporciona algunas funciones adicionales para MonoBehaviour\\
// Fecha Mod:		11/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Proporciona algunas funciones adicionales para MonoBehaviour.</para>
	/// </summary>
	public class MLMonoBehaviour : MonoBehaviour
	{
		#region Metodos Estaticos
		/// <summary>
		/// <para>Instancia un prefab.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="prefab">El prefab.</param>
		/// <returns>T.</returns>
		public static T Instantiate<T>(T prefab) where T : Component
		{
			return (T)Object.Instantiate(prefab);
		}

		/// <summary>
		/// <para>Instancia un prefab y lo agrega a un objeto.</para> 
		/// </summary>
		public static T Instantiate<T>(T prefab, GameObject root) where T : Component
		{
			var newObject = Instantiate(prefab);

			newObject.transform.SetParent(root.transform, false);

			return newObject;
		}

		/// <summary>
		/// <para>Instancia un prefab, lo agrega a un objeto y le setea la posicion y rotacion locales.</para>
		/// </summary>
		public static T Instantiate<T>(T prefab, GameObject root, Vector3 posicionLocal, Quaternion rotacionLocal) where T : Component
		{
			var newObject = Instantiate<T>(prefab);

			newObject.transform.parent = root.transform;

			newObject.transform.localPosition = posicionLocal;
			newObject.transform.localRotation = rotacionLocal;

			return newObject;
		}

		/// <summary>
		/// <para>Instancia un prefab.</para>
		/// </summary>
		/// <param name="prefab">El prefab.</param>
		/// <returns>T.</returns>
		public static GameObject Instantiate(GameObject prefab)
		{
			return Object.Instantiate(prefab);
		}

		/// <summary>
		/// <para>Instancia un prefab.</para>
		/// </summary>
		/// <param name="prefab">El prefab.</param>
		/// <returns>T.</returns>
		public static GameObject Instantiate(GameObject prefab, Vector3 posicion, Quaternion rotacion)
		{
			var newObject = Object.Instantiate(prefab, posicion, rotacion);

			return newObject;
		}

		/// <summary>
		/// <para>Instancia un prefab y lo agrega a un objeto.</para> 
		/// </summary>
		public static GameObject Instantiate(GameObject prefab, GameObject root)
		{
			var newObject = (GameObject)Object.Instantiate(prefab);

			newObject.transform.parent = root.transform;

			return newObject;
		}

		/// <summary>
		/// <para>Instancia un prefab, lo agrega a un objeto y le setea la posicion y rotacion locales.</para>
		/// </summary>
		public static GameObject Instantiate(GameObject prefab, GameObject root, Vector3 posicionLocal, Quaternion rotacionLocal)
		{
			var newObject = (GameObject)Object.Instantiate(prefab);

			newObject.transform.parent = newObject.transform;
			newObject.transform.localPosition = posicionLocal;
			newObject.transform.localRotation = rotacionLocal;

			return newObject;
		}

		#region Buscar
		/// <summary>
		/// <para>Similar a FindObjectsOfType, excepto que busca componentes que implementan una interfaz especifica.</para>
		/// </summary>
		public static List<I> FindObjectsOfInterface<I>() where I : class
		{
			var monoBehaviours = FindObjectsOfType<MonoBehaviour>();

			return monoBehaviours.Select(behaviour => behaviour.GetComponent(typeof(I))).OfType<I>().ToList();
		}
		#endregion

		#endregion

		#region API
		/// <summary>
		/// <para>Invoca la accion despues del tiempo.</para>
		/// </summary>
		public Coroutine Invoke(Action accion, float tiempo)
		{
			return MonoBehaviourExtensiones.Invoke(this, accion, tiempo);
		}

		/// <summary>
		/// <para>Invoca la accion despues del tiempo y despues vuelve a invocarlo.</para>
		/// </summary>
		public Coroutine InvokeRepeating(Action accion, float tiempo, float tiempoRepeticion)
		{
			return MonoBehaviourExtensiones.InvokeRepeating(this, accion, tiempo, tiempoRepeticion);
		}

		/// <summary>
		/// <para>Inicia un tween.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Coroutine Tween<T>(T start, T finish, float tiempoTotal, Func<T, T, float, T> lerp, Action<T> accion, Func<float> deltaTime)
		{
			return MonoBehaviourExtensiones.Tween(this, start, finish, tiempoTotal, lerp, accion, deltaTime);
		}

		/// <summary>
		/// <para>Inicia un tween.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Coroutine Tween<T>(T start, T finish, float tiempoTotal, Func<T, T, float, T> lerp, Action<T> accion)
		{
			return MonoBehaviourExtensiones.Tween(this, start, finish, tiempoTotal, lerp, accion);
		}

		/// <summary>
		/// <para>Obtiene un componente del tipo dado, o falla si no se adjunta dicho componente al componente dado.</para>
		/// </summary>
		/// <typeparam name="T">El tipo de componente para obtener.</typeparam>
		/// <returns>Un componente de tipo T unido al componente dado, si existe.
		/// </returns>
		/// <exception cref="InvalidOperationException">Cuando el componente no del tipo requerido existe en el componente dado.
		/// </exception>
		public T GetRequiredComponent<T>() where T : Component
		{
			return MonoBehaviourExtensiones.GetRequiredComponent<T>(this);
		}

		/// <summary>
		/// <para>Obtiene un componente del tipo especificado en uno de los elementos secundarios o falla si dicho componente no esta asociado al componente especificado.</para>
		/// </summary>
		/// <typeparam name="T">El tipo de componente para obtener.</typeparam>
		/// <returns>Un componente de tipo T unido al componente dado, si existe.
		/// </returns>
		/// <exception cref="InvalidOperationException">Cuando el componente no del tipo requerido existe en cualquiera de los componentes hijos dados.
		/// </exception>
		public T GetRequiredComponentInChildren<T>() where T : Component
		{
			return MonoBehaviourExtensiones.GetRequiredComponentInChildren<T>(this);
		}

		/// <summary>
		/// <para>Destruye el objeto dado utilizando Object.Destroy u Object.DestroyImmediate,</para>
		/// <para>dependiendo de si Application.isPlaying es verdadero o no. Esto es util cuando</para> 
		/// <para>metodos de escritura estan en runtime.</para>
		/// </summary>
		/// <param name="obj">Objeto a destruir.</param>
		public static void DestroyUniversal(Object obj)
		{
			if (Application.isPlaying)
			{
				Destroy(obj);
			}
			else
			{
				DestroyImmediate(obj);
			}
		}
		#endregion
	}

	/// <summary>
	/// <para>Proporciona extensiones utiles para MonoBehaviours.</para>
	/// </summary>
	public static class MonoBehaviourExtensiones
	{
		#region Clonacion
		/// <summary>
		/// <para>Clona un objeto.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T Clone<T>(this T obj) where T : MonoBehaviour
		{
			return MLMonoBehaviour.Instantiate<T>(obj);
		}

		/// <summary>
		/// <para>Clona un objeto.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static List<T> Clone<T>(this T obj, int count) where T : MonoBehaviour
		{
			var list = new List<T>();

			for (int i = 0; i < count; i++)
			{
				list.Add(obj.Clone<T>());
			}

			return list;
		}
		#endregion

		#region Corrutinas
		/// <summary>
		/// <para>Invoca la accion despues del tiempo.</para>
		/// </summary>
		public static Coroutine Invoke(this MonoBehaviour monoBehaviour, Action accion, float tiempo)
		{
			return monoBehaviour.StartCoroutine(InvokeImpl(accion, tiempo));
		}

		/// <summary>
		/// <para>Invoca la accion despues del tiempo.</para>
		/// </summary>
		private static IEnumerator InvokeImpl(Action accion, float tiempo)
		{
			yield return new WaitForSeconds(tiempo);

			accion();
		}

		/// <summary>
		/// <para>Invoca la accion despues del tiempo y despues vuelve a invocarlo.</para>
		/// </summary>
		public static Coroutine InvokeRepeating(this MonoBehaviour monoBehaviour, Action accion, float tiempo, float tiempoRepeticion)
		{
			return monoBehaviour.StartCoroutine(InvokeRepeatingImpl(accion, tiempo, tiempoRepeticion));
		}

		/// <summary>
		/// <para>Invoca la accion despues del tiempo y despues vuelve a invocarlo.</para>
		/// </summary>
		private static IEnumerator InvokeRepeatingImpl(Action accion, float tiempo, float tiempoRepeticion)
		{
			yield return new WaitForSeconds(tiempo);

			while (true)
			{
				accion();
				yield return new WaitForSeconds(tiempoRepeticion);
			}
		}
		#endregion

		#region Tweening
		/// <summary>
		/// <para>Inicia un tween.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Coroutine Tween<T>(this MonoBehaviour monoBehaviour, T start, T finish, float tiempoTotal, Func<T, T, float, T> lerp, Action<T> accion)
		{
			return Tween(monoBehaviour, start, finish, tiempoTotal, lerp, accion, () => UnityEngine.Time.deltaTime);
		}

		/// <summary>
		/// <para>Inicia un tween.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static Coroutine Tween<T>(this MonoBehaviour monoBehaviour, T start, T finish, float tiempoTotal, Func<T, T, float, T> lerp, Action<T> accion, Func<float> deltaTime)
		{
			return monoBehaviour.StartCoroutine(TweenImpl(start, finish, tiempoTotal, lerp, accion, deltaTime));
		}

		/// <summary>
		/// <para>Inicia un tween.</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private static IEnumerator TweenImpl<T>( T start, T finish, float tiempoTotal, Func<T, T, float, T> lerp, Action<T> accion, Func<float> deltaTime)
		{
			float tiempo = 0;
			float t = 0;

			while (t < 1)
			{
				var actual = lerp(start, finish, t);
				accion(actual);

				tiempo += deltaTime();
				t = tiempo / tiempoTotal;

				yield return null;
			}

			accion(finish);
		}
		#endregion

		#region Children
		/// <summary>
		/// <para>Busca un hijo.</para>
		/// </summary>
		/// <param name="componente">Componente.</param>
		/// <param name="nombre">Nombre del child.</param>
		/// <returns></returns>
		public static GameObject FindChild(this Component componente, string nombre)
		{
			return componente.transform.Find(nombre).gameObject;
		}

		/// <summary>
		/// <para>Busca un hijo</para>
		/// </summary>
		/// <param name="componente">Componente.</param>
		/// <param name="nombre">Nombre del child.</param>
		/// <param name="recursivo">Es recursivo.</param>
		/// <returns></returns>
		public static GameObject FindChild(this Component componente, string nombre, bool recursivo)
		{
			if (recursivo) return componente.FindChild(nombre);

			return FindChildRecursively(componente.transform, nombre);
		}

		/// <summary>
		/// <para>Busca un hijo.</para>
		/// </summary>
		private static GameObject FindChildRecursively(Transform target, string nombre)
		{
			if (target.name == nombre) return target.gameObject;

			for (var i = 0; i < target.childCount; ++i)
			{
				var result = FindChildRecursively(target.GetChild(i), nombre);

				if (result != null) return result;
			}

			return null;
		}
		#endregion

		#region Componentes
		/// <summary>
		/// <para>Obtiene un componente del tipo dado, o falla si no se adjunta dicho componente al componente dado.</para>
		/// </summary>
		/// <typeparam name="T">El tipo de componente.</typeparam>
		/// <param name="thisComponent">El componente a comprobar.</param>
		/// <returns>Un componente de tipo T unido al componente dado, si existe.
		/// </returns>
		public static T GetRequiredComponent<T>(this Component thisComponent) where T : Component
		{
			var retrievedComponent = thisComponent.GetComponent<T>();

			if (retrievedComponent == null)
			{
				throw new InvalidOperationException(string.Format("GameObject \"{0}\" ({1}) no tiene un componente de tipo {2}", thisComponent.name, thisComponent.GetType(), typeof(T)));
			}

			return retrievedComponent;
		}

		/// <summary>
		/// <para>Obtiene un componente del tipo especificado en uno de los elementos secundarios o falla si dicho componente no esta asociado al componente especificado.</para>
		/// </summary>
		/// <typeparam name="T">El tipo de componente.</typeparam>
		/// <param name="thisComponent">El componente a comprobar.</param>
		/// <returns>Un componente de tipo T unido al componente dado, si existe.
		/// </returns>
		public static T GetRequiredComponentInChildren<T>(this Component thisComponent) where T : Component
		{
			var retrievedComponent = thisComponent.GetComponentInChildren<T>();

			if (retrievedComponent == null)
			{
				throw new InvalidOperationException(string.Format("GameObject \"{0}\" ({1}) no tiene un hijo con componente de tipo {2}", thisComponent.name, thisComponent.GetType(), typeof(T)));
			}

			return retrievedComponent;
		}

		/// <summary>
		/// <para>Obtiene un componente adjunto que implementa la interfaz del parametro de tipo.</para>
		/// </summary>
		/// <typeparam name="TInterface">El tipo de interfaz.</typeparam>
		/// <param name="thisComponent">El componente.</param>
		/// <returns>TInterface.</returns>
		public static TInterface GetInterfaceComponent<TInterface>(this Component thisComponent) where TInterface : class
		{
			return thisComponent.GetComponent(typeof(TInterface)) as TInterface;
		}
		#endregion
	}
}

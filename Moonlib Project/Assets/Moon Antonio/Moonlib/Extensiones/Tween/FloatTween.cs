﻿//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// FloatTween.cs (22/09/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tween para un float											\\
// Fecha Mod:		22/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.Events;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Tween para un float.</para>
	/// </summary>
	public struct FloatTween : ITweenValor
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Floar inicial.</para>
		/// </summary>
		private float floatInicial;									// Floar inicial
		/// <summary>
		/// <para>Float final.</para>
		/// </summary>
		private float floatFinal;									// Float final
		/// <summary>
		/// <para>Duracion.</para>
		/// </summary>
		private float duracion;										// Duracion
		/// <summary>
		/// <para>Determina si se ignora el timeScale.</para>
		/// </summary>
		private bool ignorarTimeScale;								// Determina si se ignora el timeScale
		/// <summary>
		/// <para>Tipo de easing del tween.</para>
		/// </summary>
		private TweenEasing easing;									// Tipo de easing del tween
		/// <summary>
		/// <para>Evento de tween.</para>
		/// </summary>
		private FloatTweenCallback objetivo;						// Evento de tween
		/// <summary>
		/// <para>Evento de tween finalizado.</para>
		/// </summary>
		private FloatFinalizadoCallback finalizado;                 // Evento de tween finalizado
		#endregion

		#region Eventos
		public class FloatTweenCallback : UnityEvent<float> { }
		public class FloatFinalizadoCallback : UnityEvent { }
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Obtiene o establece el floar inicial.</para>
		/// </summary>
		/// <value>El floar inicial.</value>
		public float FloatInicial
		{
			get { return floatInicial; }
			set { floatInicial = value; }
		}

		/// <summary>
		/// <para>Obtiene o establece el float final.</para>
		/// </summary>
		/// <value>El float final.</value>
		public float FloatFinal
		{
			get { return floatFinal; }
			set { floatFinal = value; }
		}

		/// <summary>
		/// <para>Obtiene o establece la duracion.</para>
		/// </summary>
		/// <value>La duracion.</value>
		public float Duracion
		{
			get { return duracion; }
			set { duracion = value; }
		}

		/// <summary>
		/// <para>Obtiene o establece un valor que indica si <see cref = "MoonAntonio.MGUI.UI.Tweens.FloatTween" /> debe ignorar el timeScale.</para>
		/// </summary>
		/// <value><c>true</c> si se ignora el time scale; sino, <c>false</c>.</value>
		public bool IgnorarTimeScale
		{
			get { return ignorarTimeScale; }
			set { ignorarTimeScale = value; }
		}

		/// <summary>
		/// <para>Obtiene o establece el tipo de easing del Tween.</para>
		/// </summary>
		/// <value>El easing.</value>
		public TweenEasing Easing
		{
			get { return easing; }
			set { easing = value; }
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Interpola el float basado en el porcentaje.</para>
		/// </summary>
		/// <param name="valor">porcentaje.</param>
		public void TweenValor(float valor)// Interpola el float basado en el porcentaje
		{
			// Si el objetivo no es valido, volver
			if (!TargetValido()) return;

			objetivo.Invoke(Mathf.Lerp(floatInicial, floatFinal, valor));
		}

		/// <summary>
		/// <para>Activa el evento cuando cambia el tween.</para>
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void AddOnCambioCallback(UnityAction<float> callback)// Activa el evento cuando cambia el tween
		{
			if (objetivo == null) objetivo = new FloatTweenCallback();

			objetivo.AddListener(callback);
		}

		/// <summary>
		/// <para>Activa el evento cuando finaliza el tween.</para>
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void AddOnFinalizadoCallback(UnityAction callback)// Activa el evento cuando finaliza el tween
		{
			if (finalizado == null) finalizado = new FloatFinalizadoCallback();

			finalizado.AddListener(callback);
		}

		/// <summary>
		/// <para>Cuando finaliza el tween.</para>
		/// </summary>
		public void Finalizado()// Cuando finaliza el tween
		{
			if (finalizado != null) finalizado.Invoke();
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene si se ignora el TimeScale.</para>
		/// </summary>
		/// <returns></returns>
		public bool GetIgnorarTimeScale()// Obtiene si se ignora el TimeScale
		{
			return ignorarTimeScale;
		}

		/// <summary>
		/// <para>Obtiene la duracion del tween.</para>
		/// </summary>
		/// <returns></returns>
		public float GetDuracion()// Obtiene la duracion del tween
		{
			return duracion;
		}

		/// <summary>
		/// <para>Comprueba si el target es valido.</para>
		/// </summary>
		/// <returns></returns>
		public bool TargetValido()// Comprueba si el target es valido
		{
			return objetivo != null;
		}
		#endregion
	}
}
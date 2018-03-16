//                                  ┌∩┐(◣_◢)┌∩┐
//																							\\
// DatePickerControl.cs (16/03/2018)														\\
// Autor: Man Sanz (NNA Gamers) & Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com	\\
// Descripcion:		Proporciona algunas funciones para DateTime								\\
// Fecha Mod:		16/03/2018																\\
// Ultima Mod:		Version Inicial															\\
//******************************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
#endregion

namespace MoonAntonio.Moonlib
{
	#region Clases
	/// <summary>
	/// <para>Clase de Data.</para>
	/// </summary>
	[Serializable]
	public class Date
	{
		public bool fontSizeCustom;
		public InputField day;
		public int fontSizeDay = 1;
		public InputField month;
		public int fontSizeMonth = 1;
		public InputField year;
		public int fontSizeYear = 1;
	}

	/// <summary>
	/// <para>Clase de Tiempo.</para>
	/// </summary>
	[Serializable]
	public class Time
	{
		public bool fontSizeCustom;
		public InputField hour;
		public int fontSizeHour = 1;
		public InputField minute;
		public int fontSizeMinute = 1;
		public InputField second;
		public int fontSizeSecond = 1;
	}
	#endregion

	#region Logica
	/// <summary>
	/// <para>Proporciona algunas funciones para DateTime.</para>
	/// </summary>
	public class DatePickerControl : MonoBehaviour
	{
		#region Variables Publicas
		public static DateTime DateGlobal;
		public DateTime fecha;
		public static string dateStringFormato;
		public Text dateText;
		public nFormato formato = nFormato.Default;
		[HideInInspector]
		public string formatoCustom = "dddd dd/MM/yyyy HH:mm:ss";
		[HideInInspector]
		public char separator = '/';
		[HideInInspector]
		public bool dateOn;
		[HideInInspector]
		public Date inputFieldDate;
		[HideInInspector]
		public bool timeOn;
		[HideInInspector]
		public Time inputFieldTime;
		#endregion

		#region Enums
		public enum nFormato
		{
			Default,
			dd_MM_yyyy,
			MM_dd_yyyy,
			yyyy_MM_dd,
			yyyy_dd_MM,
			ddd_dd_MM_yyyy,
			ddd_MM_dd_yyyy,
			ddd,
			dddd,
			HH_mm,
			HH_mm_ss,
			hh_mmtt,
			hh_mm_sstt,
			custom
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="DatePickerControl"/>.</para>
		/// </summary>
		private void Start()
		{
			if (dateOn && inputFieldDate.fontSizeCustom)
			{
				if (inputFieldDate.day != null)
					inputFieldDate.day.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldDate.fontSizeDay;

				if (inputFieldDate.month != null)
					inputFieldDate.month.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldDate.fontSizeMonth;

				if (inputFieldDate.year != null)
					inputFieldDate.year.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldDate.fontSizeYear;
			}

			if (timeOn && inputFieldTime.fontSizeCustom)
			{
				if (inputFieldTime.hour != null)
					inputFieldTime.hour.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldTime.fontSizeHour;

				if (inputFieldTime.minute != null)
					inputFieldTime.minute.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldTime.fontSizeMinute;

				if (inputFieldTime.second != null)
					inputFieldTime.second.transform.GetChild(1).GetComponent<Text>().fontSize = inputFieldTime.fontSizeSecond;
			}
			fecha = System.DateTime.Now;
			ActualizarFecha();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="DatePickerControl"/>.</para>
		/// </summary>
		private void Update()
		{
			if (dateText != null)
			{
				if (formato == nFormato.Default)
				{
					dateText.text = dateStringFormato = DateGlobal.ToString();
				}
				else if (formato == nFormato.custom)
				{
					if (formatoCustom == "")
					{
						dateText.text = dateStringFormato = DateGlobal.ToString();
					}
					else
					{
						dateText.text = dateStringFormato = DateGlobal.ToString(formatoCustom);
					}
				}
				else
				{
					dateText.text = dateStringFormato = DateGlobal.ToString(formato.ToString().Replace('_', separator));
				}
			}
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Input del date time.</para>
		/// </summary>
		public void InputDateTime()
		{
			int d = -1, M = -1, y = -1, h = -1, m = -1, s = -1;

			if (inputFieldDate.day != null && dateOn)
			{
				d = int.Parse(inputFieldDate.day.text);
			}
			else
			{
				d = System.DateTime.Now.Day;
			}
			if (inputFieldDate.month != null && dateOn)
			{
				M = int.Parse(inputFieldDate.month.text);
			}
			else
			{
				M = System.DateTime.Now.Month;
			}
			if (inputFieldDate.year != null && dateOn)
			{
				y = int.Parse(inputFieldDate.year.text);
			}
			else
			{
				y = System.DateTime.Now.Year;
			}
			if (inputFieldTime.hour != null && timeOn)
			{
				h = int.Parse(inputFieldTime.hour.text);
			}
			else
			{
				h = System.DateTime.Now.Hour;
			}
			if (inputFieldTime.minute != null && timeOn)
			{
				m = int.Parse(inputFieldTime.minute.text);
			}
			else
			{
				m = System.DateTime.Now.Minute;
			}
			if (inputFieldTime.second != null && timeOn)
			{
				s = int.Parse(inputFieldTime.second.text);
			}
			else
			{
				s = System.DateTime.Now.Second;
			}
			if (dateOn && timeOn)
			{
				try
				{
					fecha = new DateTime(y, M, d, h, m, s);
					DateGlobal = fecha;
				}
				catch
				{
					if (d > 28 && M == 2)
					{
						fecha = new DateTime(y, 2, 28);
					}
					else
					{
						try
						{
							DiaMin();
						}
						catch
						{
						}
					}
					fecha = new DateTime(DateGlobal.Year, DateGlobal.Month, DateGlobal.Day,
						DateGlobal.Hour, DateGlobal.Minute, DateGlobal.Second);
					Debug.Log("Fecha Invalida");
					ActualizarFecha();
				}
			}
			else if (dateOn)
			{
				try
				{
					fecha = new DateTime(y, M, d,
						System.DateTime.Now.Hour, System.DateTime.Now.Minute, System.DateTime.Now.Second);
					DateGlobal = fecha;
				}
				catch
				{
					if (d > 28 && M == 2)
					{
						fecha = new DateTime(y, 2, 28);
					}
					else
					{
						try
						{
							DiaMin();
						}
						catch
						{
						}
					}
					Debug.Log("Fecha Invalida");
					ActualizarFecha();
				}
			}
			else if (timeOn)
			{
				try
				{
					fecha = new DateTime(y, M, d, h, m, s);
					DateGlobal = fecha;
				}
				catch
				{
					fecha = new DateTime(DateGlobal.Year, DateGlobal.Month, DateGlobal.Day,
						DateGlobal.Hour, DateGlobal.Minute, DateGlobal.Second);

					Debug.Log("Fecha Invalida");
					ActualizarFecha();
				}
			}
			ActualizarFecha();
		}

		/// <summary>
		/// <para>Actualiza la fecha del picker.</para>
		/// </summary>
		public void ActualizarFecha()
		{
			if (dateOn)
			{
				if (inputFieldDate.day != null)
				{
					inputFieldDate.day.text = "" + fecha.Day;
				}
				if (inputFieldDate.month != null)
				{
					inputFieldDate.month.text = "" + fecha.Month;
				}
				if (inputFieldDate.year != null)
				{
					inputFieldDate.year.text = "" + fecha.Year;
				}
			}
			if (timeOn)
			{
				if (inputFieldTime.hour != null)
				{
					inputFieldTime.hour.text = "" + fecha.Hour;
				}
				if (inputFieldTime.minute != null)
				{
					inputFieldTime.minute.text = "" + fecha.Minute;
				}
				if (inputFieldTime.second != null)
				{
					inputFieldTime.second.text = "" + fecha.Second;
				}
			}
			DateGlobal = fecha;
		}
		#endregion

		#region API
		public void DiaMax()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day + 1, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				Debug.Log("(+) No hay mas dias");
			}
			ActualizarFecha();
		}

		public void DiaMin()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day - 1, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				Debug.Log("(-) No hay mas dias");
			}
			ActualizarFecha();
		}

		public void MesMax()
		{
			try
			{
				if (fecha.Day > 28 && fecha.Month == 1)
				{
					fecha = new DateTime(fecha.Year, fecha.Month, 28, fecha.Hour, fecha.Minute, fecha.Second);
				}
				fecha = new DateTime(fecha.Year, fecha.Month + 1, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				if (fecha.Day > 1 && fecha.Month < 12)
				{
					try
					{
						DiaMin();
					}
					catch
					{
					}
				}
				Debug.Log("(+) No hay mas meses");
			}
			ActualizarFecha();
		}

		public void MesMin()
		{
			try
			{
				if (fecha.Day > 28 && fecha.Month == 3)
				{
					fecha = new DateTime(fecha.Year, fecha.Month, 28, fecha.Hour, fecha.Minute, fecha.Second);
				}
				fecha = new DateTime(fecha.Year, fecha.Month - 1, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				if (fecha.Day > 1 && fecha.Month > 1)
				{
					try
					{
						DiaMin();
					}
					catch
					{
					}
				}
				Debug.Log("(-) No hay mas meses");
			}
			ActualizarFecha();
		}

		public void YearMax()
		{
			try
			{
				fecha = new DateTime(fecha.Year + 1, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				if (fecha.Year < DateTime.MaxValue.Year)
				{
					try
					{
						DiaMin();
						fecha = new DateTime(fecha.Year + 1, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
					}
					catch
					{
					}
				}
				Debug.Log("(+) No hay mas años");
			}
			ActualizarFecha();
		}

		public void YearMin()
		{
			try
			{
				fecha = new DateTime(fecha.Year - 1, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
			}
			catch
			{
				if (fecha.Year > 1)
				{
					try
					{
						DiaMin();
						fecha = new DateTime(fecha.Year - 1, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second);
					}
					catch
					{
					}
				}
				Debug.Log("(-) No hay mas años");
			}
			ActualizarFecha();
		}

		public void HourMax()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour + 1, fecha.Minute, fecha.Second);
			}
			catch
			{
				Debug.Log("(+) No hay mas horas");
			}
			ActualizarFecha();
		}

		public void HourMin()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour - 1, fecha.Minute, fecha.Second);
			}
			catch
			{
				Debug.Log("(-) No hay mas horas");
			}
			ActualizarFecha();
		}

		public void MinuteMax()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute + 1, fecha.Second);
			}
			catch
			{
				Debug.Log("(+) No hay mas minutos");
			}
			ActualizarFecha();
		}

		public void MinuteMin()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute - 1, fecha.Second);
			}
			catch
			{
				Debug.Log("(-) No hay mas minutos");
			}
			ActualizarFecha();
		}

		public void SecondMax()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second + 1);
			}
			catch
			{
				Debug.Log("(+) No hay mas segundos");
			}
			ActualizarFecha();
		}

		public void SecondMin()
		{
			try
			{
				fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second - 1);
			}
			catch
			{
				Debug.Log("(-) No hay mas segundos");
			}
			ActualizarFecha();
		}

		public void FechaHoy()
		{
			fecha = System.DateTime.Now;
			ActualizarFecha();
		}
		#endregion
	}
	#endregion

	#region Inspector
#if UNITY_EDITOR
	/// <summary>
	/// <para>Inspector de <see cref="DatePickerControl"/>.</para>
	/// </summary>
	[CustomEditor(typeof(DatePickerControl))]
	public class DatePickerControl_Editor : Editor
	{
		#region GUI
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			DatePickerControl script = (DatePickerControl)target;

			if (script.formato == DatePickerControl.nFormato.custom)
			{
				EditorGUILayout.PrefixLabel("Format Custom");
				script.formatoCustom = EditorGUILayout.TextArea(script.formatoCustom);
			}
			else if (script.formato != DatePickerControl.nFormato.Default)
			{
				string aux = "";
				aux = script.separator.ToString();
				EditorGUILayout.PrefixLabel("Separator");
				script.separator = EditorGUILayout.TextArea(aux)[0];
			}

			script.dateOn = EditorGUILayout.Toggle("Date On", script.dateOn);

			if (script.dateOn)
			{

				script.inputFieldDate.fontSizeCustom = EditorGUILayout.ToggleLeft
					("Font Size Custom", script.inputFieldDate.fontSizeCustom);

				script.inputFieldDate.day = EditorGUILayout.ObjectField
					("     InputFiel Day", script.inputFieldDate.day, typeof(InputField), true) as InputField;
				if (script.inputFieldDate.fontSizeCustom)
					script.inputFieldDate.fontSizeDay = EditorGUILayout.IntField("       Font Size Day",
						script.inputFieldDate.fontSizeDay);

				script.inputFieldDate.month = EditorGUILayout.ObjectField
					("     InputFiel Month", script.inputFieldDate.month, typeof(InputField), true) as InputField;
				if (script.inputFieldDate.fontSizeCustom)
					script.inputFieldDate.fontSizeMonth = EditorGUILayout.IntField("       Font Size Month",
						script.inputFieldDate.fontSizeMonth);

				script.inputFieldDate.year = EditorGUILayout.ObjectField
					("     InputFiel Year", script.inputFieldDate.year, typeof(InputField), true) as InputField;
				if (script.inputFieldDate.fontSizeCustom)
					script.inputFieldDate.fontSizeYear = EditorGUILayout.IntField("       Font Size Year",
						script.inputFieldDate.fontSizeYear);

				EditorGUILayout.Space();
			}

			script.timeOn = EditorGUILayout.Toggle("Time On", script.timeOn);

			if (script.timeOn)
			{

				script.inputFieldTime.fontSizeCustom = EditorGUILayout.ToggleLeft
					("Font Size Custom", script.inputFieldTime.fontSizeCustom);

				script.inputFieldTime.hour = EditorGUILayout.ObjectField
					("     InputFiel Hour", script.inputFieldTime.hour, typeof(InputField), true) as InputField;
				if (script.inputFieldTime.fontSizeCustom)
					script.inputFieldTime.fontSizeHour = EditorGUILayout.IntField("       Font Size Hour",
						script.inputFieldTime.fontSizeHour);

				script.inputFieldTime.minute = EditorGUILayout.ObjectField
					("     InputFiel Minute", script.inputFieldTime.minute, typeof(InputField), true) as InputField;
				if (script.inputFieldTime.fontSizeCustom)
					script.inputFieldTime.fontSizeMinute = EditorGUILayout.IntField("       Font Size Minute",
						script.inputFieldTime.fontSizeMinute);

				script.inputFieldTime.second = EditorGUILayout.ObjectField
					("     InputFiel Second", script.inputFieldTime.second, typeof(InputField), true) as InputField;
				if (script.inputFieldTime.fontSizeCustom)
					script.inputFieldTime.fontSizeSecond = EditorGUILayout.IntField("       Font Size Second",
						script.inputFieldTime.fontSizeSecond);

				EditorGUILayout.Space();
			}
		}
		#endregion
	}
#endif
	#endregion
}
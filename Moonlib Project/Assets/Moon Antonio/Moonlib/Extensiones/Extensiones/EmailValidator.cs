//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EmailValidator.cs (26/03/2018)												\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Ayudante validador de un correo electronico.				\\
// Fecha Mod:		26/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System;
using System.Globalization;
using System.Text.RegularExpressions;
#endregion

namespace MoonAntonio.Moonlib.Extensiones
{
	/// <summary>
	/// <para>Ayudante validador de un correo electronico.</para>
	/// </summary>
	internal class EmailValidator
	{
		#region Variables Privadas
		/// <summary>
		/// <para>True si el email es valido.</para>
		/// </summary>
		private bool invalid;                                   // True si el email es valido
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>True si el email es valido.</para>
		/// </summary>
		/// <param name="strIn"></param>
		/// <returns></returns>
		public bool IsValidEmail(string strIn)// True si el email es valido
		{
			invalid = false;
			if (String.IsNullOrEmpty(strIn)) return false;

			// Usar la clase IdnMapping para convertir nombres de dominio Unicode.
			strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper, RegexOptions.None);

			if (invalid) return false;

			// Devuelve true si strIng esta en formato de email valido.
			return Regex.IsMatch(strIn,
								 @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
								 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
								 RegexOptions.IgnoreCase);
		}
		#endregion

		#region Funcionalidad Interna
		/// <summary>
		/// <para>Convertir nombres de dominio en Unicode.</para>
		/// </summary>
		/// <param name="match"></param>
		/// <returns></returns>
		private string DomainMapper(Match match)// Convertir nombres de dominio en Unicode
		{
			IdnMapping idn = new IdnMapping();

			string domainName = match.Groups[2].Value;
			try
			{
				domainName = idn.GetAscii(domainName);
			}
			catch (ArgumentException)
			{
				invalid = true;
			}
			return match.Groups[1].Value + domainName;
		}
		#endregion
	}
}

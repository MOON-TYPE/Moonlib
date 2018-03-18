//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LongProt.cs (18/03/2018)														\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Contenedor para la proteccion de valores de tipo int64.		\\
// Fecha Mod:		18/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Runtime.InteropServices;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Contenedor para la proteccion de valores de tipo int64.</para>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct LongProt 
	{
		#region Constantes
		/// <summary>
		/// <para>Mascara para la proteccion.</para>
		/// </summary>
		private const ulong MascaraXor = 0xaaaaaaaaaaaaaaaa;		// Mascara para la proteccion
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Encriptado del valor.</para>
		/// </summary>
		[FieldOffset(0)] private long encriptado;					// Encriptado del valor
		/// <summary>
		/// <para>Conversion inicial.</para>
		/// </summary>
		[FieldOffset(0)] private ulong conversion;					// Conversion inicial
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Obtener el valor cifrado (para la serializacion u otra cosa).</para>
		/// </summary>
		public long ValorEncriptado
		{
			get
			{
				// Solucion para el constructor init.
				if (conversion == 0 && ((int)encriptado == 0))
				{
					conversion = MascaraXor;
				}
				return encriptado;
			}
		}
		#endregion

		#region Operadores
		public static implicit operator long(LongProt v)
		{
			v.conversion ^= MascaraXor;
			var f = v.encriptado;
			v.conversion ^= MascaraXor;
			return f;
		}

		public static implicit operator LongProt(long v)
		{
			var p = new LongProt();
			p.encriptado = v;
			p.conversion ^= MascaraXor;
			return p;
		}
		#endregion
	}
}

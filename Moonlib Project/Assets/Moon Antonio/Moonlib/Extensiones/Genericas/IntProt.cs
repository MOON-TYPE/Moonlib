//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// IntProt.cs (18/03/2018)														\\
// Autor: Antonio Mateo (.\Moon Antonio) 	antoniomt.moon@gmail.com			\\
// Descripcion:		Contenedor para la proteccion de valores de tipo int32.		\\
// Fecha Mod:		18/03/2018													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using System.Runtime.InteropServices;
#endregion

namespace MoonAntonio.Moonlib
{
	/// <summary>
	/// <para>Contenedor para la proteccion de valores de tipo int32.</para>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct IntProt 
	{
		#region Constantes
		/// <summary>
		/// <para>Mascara para la proteccion.</para>
		/// </summary>
		private const uint MascaraXor = 0xaaaaaaaa;					// Mascara para la proteccion
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Encriptado del valor.</para>
		/// </summary>
		[FieldOffset(0)] private int encriptado;					// Encriptado del valor
		/// <summary>
		/// <para>Conversion inicial.</para>
		/// </summary>
		[FieldOffset(0)] private uint conversion;					// Conversion inicial
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Obtener el valor cifrado (para la serializacion u otra cosa).</para>
		/// </summary>
		public int ValorEncriptado
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
		public static implicit operator int(IntProt v)
		{
			v.conversion ^= MascaraXor;
			var f = v.encriptado;
			v.conversion ^= MascaraXor;
			return f;
		}

		public static implicit operator IntProt(int v)
		{
			var p = new IntProt();
			p.encriptado = v;
			p.conversion ^= MascaraXor;
			return p;
		}
		#endregion
	}
}

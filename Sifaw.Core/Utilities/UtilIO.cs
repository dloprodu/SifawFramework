/*
 * Sifaw.Core.Utilities
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics.Contracts;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Clase Util con funciones de utilidad con Streams.
	/// </summary>
	public static class UtilIO
	{
		/// <summary>
		/// Realiza la conversión desde un String a un Stream.
		/// </summary>
		/// <param name="str">String a convertir</param>
		/// <param name="encoding">Tipo de codificación</param>
		public static Stream StringToStream(String str, Encoding encoding)
		{
			char[] charArray = str.ToCharArray();
			byte[] byteArray = new byte[encoding.GetByteCount(charArray)];
			encoding.GetEncoder().GetBytes(charArray, 0, charArray.Length, byteArray, 0, true);
			return new MemoryStream(byteArray);
		}

		/// <summary>
		/// Realiza la conversión desde un Stream a un string.
		/// </summary>
		/// <param name="stream">Stream</param>
		/// <param name="encoding">Encoding</param>
		public static string StreamToString(Stream stream, Encoding encoding)
		{
			int count = (int)stream.Length;
			byte[] byteArray = new byte[count];
			int i = stream.Read(byteArray, 0, (int)stream.Length);
			char[] charArray = new char[encoding.GetCharCount(byteArray, 0, count)];
			charArray = encoding.GetChars(byteArray);
			return new String(charArray);
		}

		/// <summary>
		/// Obtiene un recurso incrustado en el ensamblado devolviéndolo como de tipo String.
		/// </summary>
		/// <param name="recurso">Nombre completo incluyendo el espacio de nombres del recurso</param>
		/// <param name="encoding">Tipo de codificación</param>
		/// <example>
		/// 	System.Text.Encoding enconding = new System.Text.ASCIIEncoding();
		///		String str = UtilIO.ObtenerRecursoString("EkadeWIN.ConsultasAbiertas.Informes.InformeSinAgrup.rdlc", enconding);
		/// </example>
		public static String GetAssemblyResource(String recurso, Encoding encoding)
		{
			string resource = string.Empty;

			using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(recurso))
			{
				resource = StreamToString(stream, encoding);
			}

			return resource;
		}

		/// <summary>
		/// Devuelve una copia de un objeto serializable.
		/// </summary>
		/// <typeparam name="T">Tipo del objeto a copiar.</typeparam>
		/// <param name="source">Objeto seriablizable a copiar.</param>
		/// <exception cref="ArgumentException">source no es serializable.</exception>
		/// <returns>Copia del objeto.</returns>
		public static T Clone<T>(T source)
		{
			if (!typeof(T).IsSerializable)
				throw new ArgumentException("El tipo de dato debe ser serializable.");

			T target = default(T);

			if (!Object.ReferenceEquals(source, null))
			{
				// Creamos un stream en memoria.		
				using (Stream stream = new MemoryStream())
				{
					IFormatter formatter = new BinaryFormatter();
					formatter.Serialize(stream, source);
					stream.Seek(0, SeekOrigin.Begin);
					// Deserializamos la porción de memoria en el nuevo objeto
					target = (T)formatter.Deserialize(stream);
				}
			}

			return target;
		}
	}
}
/*
 * Sifaw.Core.Utilities
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Proporciona m�todos est�ticos para operaciones con ficheros.
	/// </summary>
	public static class UtilFile
	{
		/// <summary>
		/// Crea un fichero temporal en la ruta definida por el sistema para los archivos temporales del usuario local,
		/// dicho fichero tendr� 0 bytes una vez creado, y devuelve la ruta completa del fichero.
		/// </summary>
		/// <example>
		/// <code>
		///		string name = UtilFile.GetTempFileName("kmz");
		///		FileStream fs = File.OpenWrite(name);
		/// </code>
		/// </example>
		/// <param name="extension">
		/// Designa la extensi�n del fichero. Si es igual a string.Empty se le asigna la
		/// extensi�n por defecto.
		/// </param>
		public static String GetTempFileName(string extension)
		{
			string file = Path.GetTempFileName();

			if (!String.IsNullOrEmpty(extension))
				file = Path.ChangeExtension(file, extension);

			return file;
		}

		/// <summary>
		/// Crea un fichero temporal en la ruta definida por el sistema para los archivos temporales del usuario local,
		/// dicho fichero tendr� 0 bytes una vez creado, y devuelve la ruta completa del fichero.
		/// </summary>
		public static String GetTempFileName()
		{
			return GetTempFileName(string.Empty);
		}

		/// <summary>
		/// Devuelve el directorio de configuraci�n para la aplicaci�n especificada.
		/// </summary>
		/// <param name="application">Nombre de la aplicaci�n.</param>
		/// <returns>Ruta completa del directorio de configuraci�n.</returns>
		public static String GetConfigurationFolder(string application)
		{
			string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string dir2 = "." + Path.DirectorySeparatorChar + application + Path.DirectorySeparatorChar;
			string dirconf = Path.GetFullPath(Path.Combine(dir1, dir2));
			return dirconf;
		}

		/// <summary>
		/// Devuelve la ruta donde est� alojada el ejecutable de la aplicaci�n.
		/// </summary>
		public static string GetApplicationDirectory()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		}

		/// <summary>
		/// Devuelve un valor que indica si el nombre del fichero es v�lido.
		/// </summary>
		/// <param name="file">NOmbre del fichero a chequear.</param>
		/// <returns><c>true</c> si el <c>file</c> es un nombre de fichero v�lido, <c>false</c> en caso contrario.</returns>
		public static bool IsValidFilename(string file)
		{
			if (file.Trim().Equals(string.Empty))
			{
				return false;
			}

			Regex regex = new Regex("[" + Regex.Escape(new string(Path.GetInvalidPathChars())) + "]");
			if (regex.IsMatch(file))
			{
				return false;
			}

			string fileName = Path.GetFileName(file);
			if (fileName.Trim().Equals(string.Empty))
			{
				return false;
			}

			regex = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");
			if (regex.IsMatch(fileName))
			{
				return false;
			}

			return true;
		}
	}
}
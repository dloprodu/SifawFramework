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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Proporciona métodos estáticos para operaciones con ficheros.
	/// </summary>
	public static class UtilFile
	{
		/// <summary>
		/// Crea un fichero temporal en la ruta definida por windows para los archivos temporales del usuario local.
		/// Dicho fichero tendrá 0 bytes una vez creado.
		/// Se devuelve la ruta completa al nombrado fichero.
		/// Ejemplo de utilización: 
		///				string nombreDocGoogleEarth = UtilTempFile.ObtenFicheroTemp("kmz");
		///				FileStream fs = File.OpenWrite(nombreDocGoogleEarth);
		/// </summary>
		/// <param name="extension">
		/// Designa la extensión del documento. Si es igual a string.Empty se le asigna la
		/// extensión "TMP" por defecto.
		/// </param>
		public static String GetTempFileName(string extension)
		{
			string file = Path.GetTempFileName();

			if (!String.IsNullOrEmpty(extension))
				file = Path.ChangeExtension(file, extension);

			return file;
		}

		public static String GetTempFileName()
		{
			return GetTempFileName(string.Empty);
		}

		public static String GetConfigurationFolder(string application)
		{
			string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string dir2 = "." + Path.DirectorySeparatorChar + application + Path.DirectorySeparatorChar;
			string dirconf = Path.GetFullPath(Path.Combine(dir1, dir2));
			return dirconf;
		}

		/// <summary>
		/// Devuelve el path completo para un nombre de archivo en el directorio temporal.
		/// </summary>
		public static String GetFullTempPath(string filename)
		{
			return Path.Combine(Path.GetTempPath(), filename);
		}

		public static String GetFullTempPath()
		{
			return Path.GetTempPath();
		}

		/// <summary>
		/// Devuelve la ruta donde está alojada el ejecutable
		/// </summary>
		public static string GetApplicationDirectory()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
		}

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
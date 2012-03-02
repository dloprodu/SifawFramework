/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una sección de un objeto <see cref="UITable"/>.
	/// </summary>
	/// <remarks>
	/// Una sección viene definida por una colección de filas.
	/// </remarks>
	[Serializable]
	public abstract class UITableSection : IEquatable<UITableSection>
	{
		#region Fields

		private string _name = string.Empty;
		private string _caption = string.Empty;
		private string _detail = string.Empty;
		private UITableRowCollection _rows;

		//private int _rowHeight = 18;


		#endregion

		#region Properties

		/// <summary>
		/// Obtiene el nombre de la sección.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Obtiene el título de la sección.
		/// </summary>
		public string Caption
		{
			get { return _caption; }
			set { _caption = value; }
		}

		/// <summary>
		/// Obtiene la descripción de la sección.
		/// </summary>
		public string Detail
		{
			get { return _detail; }
			set { _detail = value; }
		}

		/// <summary>
		/// Obtiene las filas de la sección.
		/// </summary>
		public UITableRowCollection Rows
		{
			get
			{
				if (_rows == null)
					_rows = new UITableRowCollection(this);

				return _rows;
			}
		}

		#endregion

		#region Consctructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSection"/>, estableciendo un valor
		/// en la propiedad <see cref="Name"/>.
		/// </summary>
		/// <param name="name">Nombre de la sección.</param>
		public UITableSection(string name)
		{
			this._name = name;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Devuelve la representación de cadena de un objeto <see cref="UITableSection"/>.
		/// </summary>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Determina si un objeto <see cref="UITableSection"/> proporcionado es equivalente al objeto <see cref="UITableSection"/> actual.
		/// </summary>
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj);
		}

		/// <summary>
		/// Obtiene un código hash de este objeto <see cref="UITableSection"/>.
		/// </summary>
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		#endregion

		#region IEquatable<UITableSection> Members

		/// <summary>
		/// Determina si un objeto <see cref="UITableSection"/> proporcionado es equivalente al objeto <see cref="UITableSection"/> actual.
		/// </summary>
		public bool Equals(UITableSection other)
		{
			return ReferenceEquals(this, other);
		}

		#endregion
	
		#region Miscellany

		/// <summary>
		/// Representa la colección de filas que definen un objeto <see cref="UITableSection"/>.
		/// </summary>
		[Serializable]
		public class UITableRowCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly UITableSection Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la fila en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la fila que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="UITableRow"/> que representa la fila
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public UITableRow this[int index]
			{
				get { return ((UITableRow)List[index]); }
			}

			/// <summary>
			/// Obtiene de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a recuperar de la colección.</param>
			/// <returns>Objeto <see cref="UITableRow"/> con la clave especificada.</returns>
			public UITableRow this[string key]
			{
				get
				{
					foreach (UITableRow obj in List)
						if (obj.Name.Equals(key))
							return obj;

					return null;
				}
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableRowCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="UITableSection"/> que posee esta colección.</param>
			public UITableRowCollection(UITableSection owner)
			{
				this.Owner = owner;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="UITableRow"/> existente a la colección.
			/// </summary>
			/// <param name="row"> Objeto <see cref="UITableRow"/> que se va a agregar a la colección.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(UITableRow row)
			{
				return (List.Add(row));
			}

			/// <summary>
			/// Devuelve el índice de la fila especificada incluida en la colección.
			/// </summary>
			/// <param name="row"><see cref="UITableRow"/> que representa la fila que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la fila en la colección.
			/// Si la fila no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(UITableRow row)
			{
				return (List.IndexOf(row));
			}

			/// <summary>
			/// Determina el índice de la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila cuyo índice se va a recuperar.</param>
			/// <returns>
			/// Índice de base cero de la primera aparición de la fila con el nombre especificado,
			/// si se encuentra; de lo contrario, -1.
			/// </returns>
			public int IndexOfKey(string key)
			{
				for (int i = 0; i < List.Count; i++)
					if (this[i].Name.Equals(key))
						return i;

				return -1;
			}

			/// <summary>
			/// Inserta una sección existente en la colección, en el índice
			/// especificado.
			/// </summary>
			/// <param name="index">Posición de índice de base cero donde se inserta la fila.</param>
			/// <param name="row">Objeto <see cref="UITableRow"/> que se va a insertar en la colección.</param>
			public void Insert(int index, UITableRow row)
			{
				List.Insert(index, row);
			}

			/// <summary>
			/// Quita la fila especificado de la colección.
			/// </summary>
			/// <param name="row">
			/// <see cref="UITableRow"/> que representa la fila
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(UITableRow row)
			{
				List.Remove(row);				
			}

			/// <summary>
			/// Quita de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a quitar de la colección.</param>
			public void RemoveByKey(string key)
			{
				UITableRow obj = this[key];

				if (obj != null)
					Remove(obj);
			}

			/// <summary>
			/// Determina si la fila especificado se encuentra en la colección.
			/// </summary>
			/// <param name="row">
			/// <see cref="UITableRow"/> que representa la fila 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la fila; en caso contrario, false.
			/// </returns>
			public bool Contains(UITableRow row)
			{
				return (List.Contains(row));
			}

			/// <summary>
			/// Determina si una seccón con la clave especificada está incluida en la colección.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a buscar.</param>
			/// <returns>
			/// true si la fila con el nombre especificado está incluida en la colección;
			/// en caso contrario, false.
			/// </returns>
			public bool ContainsKey(string key)
			{
				return (this[key] != null);
			}

			#endregion
		}

		#endregion
	}
}
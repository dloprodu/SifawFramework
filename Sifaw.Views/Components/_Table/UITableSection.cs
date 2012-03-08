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

using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una sección de un objeto <see cref="UITable"/>.
	/// </summary>
	/// <remarks>
	/// Una sección viene definida por una colección de filas.
	/// </remarks>
	[Serializable]
	public class UITableSection : IEquatable<UITableSection>
	{
		#region Fields

		private string _name = string.Empty;
		private string _caption = string.Empty;
		private string _detail = string.Empty;
		private UITableSectionRowCollection _rows;
		private UISettings _settings;

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
		public UITableSectionRowCollection Rows
		{
			get
			{
				if (_rows == null)
					_rows = new UITableSectionRowCollection(this);

				return _rows;
			}
		}

		/// <summary>
		/// Obtiene o establece los ajustes de la sección de tabla.
		/// </summary>
		public UISettings Settings
		{
			get { return _settings; }
			set { _settings = value; }
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

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSection"/>, estableciendo valores
		/// en las propiedades <see cref="Name"/> y <see cref="Settings"/>.
		/// </summary>
		/// <param name="name">Nombre de la sección.</param>
		/// <param name="settings">Ajustes de la sección.</param>
		public UITableSection(string name, UISettings settings)
			: this(name)
		{
			this._settings = settings;
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
		/// Provee un conjunto de propiedades que permiten modificar la apariencia
		/// de un componente de interfaz de usuario.
		/// </summary>
		public struct UISettings
		{
			/// <summary>
			/// Obtiene un <see cref="UISettings"/> con unos valores por defecto.
			/// </summary>
			public static readonly UISettings Default;

			#region Fields

			/// <summary>
			/// Obtiene o establece el pincel que describe el fondo del elemento.
			/// </summ
			public UIBrush Background;

			/// <summary>
			/// Obtiene o establece el grosor del borde del componente.
			/// </summary>
			public UIFrame Border;

			/// <summary>
			/// Obtiene o establece un pincel que describe el fondo del borde del componente.
			/// </summary>
			public UIFrameBrush BorderBrush;

			/// <summary>
			/// Obtiene o establece el alto de las filas de la sección.
			/// </summary>
			public double RowHeight;

			#endregion

			#region Constructor

			static UISettings()
			{
				Default = new UISettings(
					  background: new UISolidBrush(UIColors.WhiteColors.White)
					, border: new UIFrame(1)
					, borderBrush: new UIFrameBrush(new UISolidBrush(UIColors.BlueColors.RoyalBlue))
					, rowHeight: 18);			
			}

			/// <summary>
			/// Inicializa una nueva instancia de la estructura <see cref="UISettings"/>.
			/// </summary>
			public UISettings(UIBrush background, UIFrame border, UIFrameBrush borderBrush, double rowHeight)
			{
				Background = background;
				Border = border;
				BorderBrush = borderBrush;
				RowHeight = rowHeight;
			}

			#endregion
		}

		/// <summary>
		/// Representa la colección de filas que definen un objeto <see cref="UITableSection"/>.
		/// </summary>
		[Serializable]
		public class UITableSectionRowCollection : CollectionBase
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
			/// <see cref="UITableSectionRow"/> que representa la fila
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public UITableSectionRow this[int index]
			{
				get { return ((UITableSectionRow)List[index]); }
			}

			/// <summary>
			/// Obtiene de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a recuperar de la colección.</param>
			/// <returns>Objeto <see cref="UITableSectionRow"/> con la clave especificada.</returns>
			public UITableSectionRow this[string key]
			{
				get
				{
					foreach (UITableSectionRow obj in List)
						if (obj.Name.Equals(key))
							return obj;

					return null;
				}
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableSectionRowCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="UITableSection"/> que posee esta colección.</param>
			public UITableSectionRowCollection(UITableSection owner)
			{
				this.Owner = owner;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="UITableSectionRow"/> existente a la colección.
			/// </summary>
			/// <param name="name">Nombre de la fila.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una fila con igual nombre.", "name");

				return (List.Add(new UITableSectionRow(name)));
			}

			/// <summary>
			/// Agrega un objeto <see cref="UITableSectionRow"/> existente a la colección.
			/// </summary>
			/// <param name="name">Nombre de la fila.</param>
			/// <param name="cells">Configuración de celdas del fila.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name, UITableCell[] cells)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una fila con igual nombre.", "name");

				return (List.Add(new UITableSectionRow(name, cells)));
			}

			/// <summary>
			/// Agrega un objeto <see cref="UITableSectionRow"/> existente a la colección.
			/// </summary>
			/// <param name="name">Nombre de la fila.</param>
			/// <param name="cells">Configuración de celdas del fila.</param>
			/// <param name="child">Tabla hija.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(string name, UITableCell[] cells, UITable child)
			{
				if (ContainsKey(name))
					throw new ArgumentException("Ya existe una fila con igual nombre.", "name");

				return (List.Add(new UITableSectionRow(name, cells, child)));
			}

			/// <summary>
			/// Devuelve el índice de la fila especificada incluida en la colección.
			/// </summary>
			/// <param name="row"><see cref="UITableSectionRow"/> que representa la fila que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la fila en la colección.
			/// Si la fila no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(UITableSectionRow row)
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
			/// <param name="row">Objeto <see cref="UITableSectionRow"/> que se va a insertar en la colección.</param>
			public void Insert(int index, UITableSectionRow row)
			{
				List.Insert(index, row);
			}

			/// <summary>
			/// Quita la fila especificado de la colección.
			/// </summary>
			/// <param name="row">
			/// <see cref="UITableSectionRow"/> que representa la fila
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(UITableSectionRow row)
			{
				List.Remove(row);				
			}

			/// <summary>
			/// Quita de la colección la fila con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la fila que se va a quitar de la colección.</param>
			public void RemoveByKey(string key)
			{
				UITableSectionRow obj = this[key];

				if (obj != null)
					Remove(obj);
			}

			/// <summary>
			/// Determina si la fila especificado se encuentra en la colección.
			/// </summary>
			/// <param name="row">
			/// <see cref="UITableSectionRow"/> que representa la fila 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la fila; en caso contrario, false.
			/// </returns>
			public bool Contains(UITableSectionRow row)
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
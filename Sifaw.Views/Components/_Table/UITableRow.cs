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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una fila de un objeto <see cref="UITableSection"/>.
	/// </summary>
	/// <remarks>
	/// Una fila viene definida por una colección de celdas.
	/// </remarks>
	[Serializable]
	public class UITableRow : IEquatable<UITableRow>
	{
		#region Fileds

		private string _name = string.Empty;
        private UITableCellCollection _cells = null;
		private UITable _childTable = null;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene el nombre de la fila.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Obtiene las celdas de la fila.
		/// </summary>
        public UITableCellCollection Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new UITableCellCollection(this);

                return _cells;
            }
        }

		/// <summary>
		/// Obtiene la tabla secundaria asociada a la fila.
		/// </summary>
		public UITable ChildTable
		{
			get { return _childTable; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableRow"/>, estableciendo un valor
		/// en la propiedad <see cref="Name"/>.
		/// </summary>
		/// <param name="name">Nombre de la fila.</param>
		public UITableRow(string name)
		{
			this._name = name;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Devuelve la representación de cadena de un objeto <see cref="UITableRow"/>.
		/// </summary>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Determina si un objeto <see cref="UITableRow"/> proporcionado es equivalente al objeto <see cref="UITableRow"/> actual.
		/// </summary>
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj);
		}

		/// <summary>
		/// Obtiene un código hash de este objeto <see cref="UITableRow"/>.
		/// </summary>
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		#endregion

		#region IEquatable<UITableRow> Members

		/// <summary>
		/// Determina si un objeto <see cref="UITableRow"/> proporcionado es equivalente al objeto <see cref="UITableRow"/> actual.
		/// </summary>
		public bool Equals(UITableRow other)
		{
			return ReferenceEquals(this, other);
		}

		#endregion

		#region Miscellany

		/// <summary>
		/// Representa la colección de celdas que definen un objeto <see cref="UITableRow"/>.
		/// </summary>
		[Serializable]
		public class UITableCellCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly UITableRow Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la celda en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la celda que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="UITableCell"/> que representa la celda
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public UITableCell this[int index]
			{
				get { return ((UITableCell)List[index]); }
			}

			/// <summary>
			/// Obtiene de la colección la celda con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la celda que se va a recuperar de la colección.</param>
			/// <returns>Objeto <see cref="UITableCell"/> con la clave especificada.</returns>
			public UITableCell this[string key]
			{
				get
				{
					foreach (UITableCell obj in List)
						if (obj.Name.Equals(key))
							return obj;

					return null;
				}
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableCellCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="UITableCell"/> que posee esta colección.</param>
			public UITableCellCollection(UITableRow owner)
			{
				this.Owner = owner;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="UITableCell"/> existente a la colección.
			/// </summary>
			/// <param name="cell"> Objeto <see cref="UITableCell"/> que se va a agregar a la colección.</param>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add(UITableCell cell)
			{
				return (List.Add(cell));
			}

			/// <summary>
			/// Devuelve el índice de la celda especificada incluida en la colección.
			/// </summary>
			/// <param name="cell"><see cref="UITableCell"/> que representa la celda que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la celda en la colección.
			/// Si la celda no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(UITableCell cell)
			{
				return (List.IndexOf(cell));
			}

			/// <summary>
			/// Determina el índice de la celda con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la celda cuyo índice se va a recuperar.</param>
			/// <returns>
			/// Índice de base cero de la primera aparición de la celda con el nombre especificado,
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
			/// <param name="index">Posición de índice de base cero donde se inserta la celda.</param>
			/// <param name="cell">Objeto <see cref="UITableCell"/> que se va a insertar en la colección.</param>
			public void Insert(int index, UITableCell cell)
			{
				List.Insert(index, cell);
			}

			/// <summary>
			/// Quita la celda especificado de la colección.
			/// </summary>
			/// <param name="cell">
			/// <see cref="UITableCell"/> que representa la celda
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(UITableCell cell)
			{
				List.Remove(cell);				
			}

			/// <summary>
			/// Quita de la colección la celda con la clave especificada.
			/// </summary>
			/// <param name="key">Nombre de la celda que se va a quitar de la colección.</param>
			public void RemoveByKey(string key)
			{
				UITableCell obj = this[key];

				if (obj != null)
					Remove(obj);
			}

			/// <summary>
			/// Determina si la celda especificado se encuentra en la colección.
			/// </summary>
			/// <param name="cell">
			/// <see cref="UITableCell"/> que representa la celda 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la celda; en caso contrario, false.
			/// </returns>
			public bool Contains(UITableCell cell)
			{
				return (List.Contains(cell));
			}

			/// <summary>
			/// Determina si una seccón con la clave especificada está incluida en la colección.
			/// </summary>
			/// <param name="key">Nombre de la celda que se va a buscar.</param>
			/// <returns>
			/// true si la celda con el nombre especificado está incluida en la colección;
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
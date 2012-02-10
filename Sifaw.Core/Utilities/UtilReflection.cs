///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Fichero contenedor de tipos de datos miscelaneos y funciones de utilidad.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 05/10/2011 Creación del fichero
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Proporciona métodos estáticos para operaciones con objetos.
	/// </summary>
	public static class UtilReflection
	{
		/// <summary>
		/// Devuelve todos los campos especificados teniendo en cuenta las clases heredadas.
		/// </summary>
		/// <param name="type">Tipo base</param>
		/// <param name="flags">Flags de busqueda</param>
		public static List<FieldInfo> GetAllFields(Type type, BindingFlags flags)
		{
			if (type == typeof(object))
				return new List<FieldInfo>();

			// Obtenemos los campos de la base 
			List<FieldInfo> list = GetAllFields(type.BaseType, flags);
			list.AddRange(type.GetFields(flags));
			return list;
		}

		/// <summary>
		/// Devuelve el valor que tenga el objeto en la propiedad indicada.
		/// </summary>
		public static object GetValue(object obj, string name)
		{
			Type currentType = obj.GetType();

			if (name.Contains("."))
			{
				string propiedad = name.Substring(0, name.IndexOf('.'));
				string propiedades_restantes = name.Substring(name.IndexOf('.') + 1);

				PropertyInfo pi_objeto_interno = currentType.GetProperty(propiedad);
				object objeto_interno = pi_objeto_interno.GetValue(obj, null);

				return (objeto_interno != null) ? GetValue(objeto_interno, propiedades_restantes) : null;
			}

			PropertyInfo pi = currentType.GetProperty(name);
			object valor = pi.GetValue(obj, null);

			return valor;
		}

		/// <summary>
		/// Graba el valor indicado en la propiedad del objeto.
		/// </summary>
		public static void SetValue(object obj, string name, object value)
		{
			Type currentType = obj.GetType();

			if (name.Contains("."))
			{
				string propiedad = name.Substring(0, name.IndexOf('.'));
				string propiedades_restantes = name.Substring(name.IndexOf('.') + 1);

				PropertyInfo pi_objeto_interno = currentType.GetProperty(propiedad);
				object objeto_interno = pi_objeto_interno.GetValue(obj, null);

				if (objeto_interno != null)
					SetValue(objeto_interno, propiedades_restantes, value);

				return;
			}

			PropertyInfo pi = currentType.GetProperty(name);

			pi.SetValue(obj, value, null);

			return;
		}

		/// <summary>
		/// Engancha, a través de un método dinámico, un evento a un manejador genérico.
		/// Útil para enganchar eventos de tipos genéricos.
		/// </summary>
		/// <example>  
		/// Agregar un manejador al evento CCUFinalizado es más complicado. La definición base del evento CCUFinalizado cumple
		/// la siguiente firma: 
		///      
		///      public event CCUFinalizadoEventHandler<![CDATA[<TParamCtrlFinalizar> ]]> CCUFinalizado;
		/// 
		/// a partir de la cual, para cada una de las controladoras se debe proporcionar un CCUFinalizado particular
		/// en base a la clase especificada como TParamCtrlFinalizar. Esto hace imposible generalizar de un modo directo
		/// el manejador de dicho evento.
		///
		/// Para solucionar el problema y no tener que crear un manejador específico cada vez que se agregue una nueva controladora,
		/// se creará mediante un método dinámico el manejador específico a cada controladora que se desee enlazar.
		/// </example>
		/// <remarks>
		/// Referencia a documentación usada:
		///
		/// http://msdn.microsoft.com/en-us/library/ms228976.aspx
		/// http://msdn.microsoft.com/en-us/library/system.reflection.eventinfo.addeventhandler.aspx
		/// http://msdn.microsoft.com/en-us/library/exczf7b9.aspx
		/// </remarks>
		/// <param name="eventSource">Objeto que lanza en evento.</param>
		/// <param name="eventName">Evento a enchar.</param>
		/// <param name="eventListener">Objeto que escucha el evento.</param>
		/// <param name="eventListenerType">Tipo del objeto que escucha el evento. Se debe de indicar el tipo que contiene al manejador.</param>
		/// <param name="handler">Nombre del método que manejará el evento.</param>
		/// <param name="delegade">Delegado del evento.</param>
		public static void SubscribeToEvent(
			  object eventSource
			, string eventName
			, object eventListener
			, Type eventListenerType
			, string handler
			, Delegate delegade)
		{
			// Se obtiene información sobre el evento al que se le quiere enlazar un manejador mediante un método dinámico.
			EventInfo eventInfo = eventSource.GetType().GetEvent(eventName, BindingFlags.Public | BindingFlags.Instance);
			Type eventHandlerType = eventInfo.EventHandlerType;

			// Mediante el tipo del manejador, se podrá obtener los parámetros que son necesarios para llamar al manejador.
			// Esto se hace consultando los parámetros del método Invoke asociado.
			MethodInfo invokeMethod = eventHandlerType.GetMethod("Invoke");
			ParameterInfo[] parms = invokeMethod.GetParameters();
			Type[] parmTypes = new Type[parms.Length + 1];

			// Hay que tener en cuenta que al ser un método que se llamará dentro del ámbito del objeto actual, 
			// se le deberá proporcionar una referencia al mismo.
			parmTypes[0] = eventListenerType;
			for (int i = 1; i < parmTypes.Length; i++)
			{
				parmTypes[i] = parms[i - 1].ParameterType;
			}

			// Se crea el método dinámico que se enlazará al evento.
			DynamicMethod dynamicHandlerEvent = new DynamicMethod(string.Format("DynamicHandler_{0}", eventName), null, parmTypes, eventListenerType);
			ILGenerator ilgDynamicCodeEvent = dynamicHandlerEvent.GetILGenerator();

			// El argumento 'manejador' se usará como método puente para ejecutar todo el conjunto común de código
			// para todos y cada uno de los CCUFinalizado.
			MethodInfo staticHandlerEvent = eventListenerType.GetMethod(handler, BindingFlags.NonPublic | BindingFlags.Instance);

			// MSLI para la llamada a ctrlActualNuevoEstandar_CCUFinalizado. 
			// La sección de código es una réplica de lo que generaría el compilador.
			ilgDynamicCodeEvent.Emit(OpCodes.Nop);
			ilgDynamicCodeEvent.Emit(OpCodes.Ldarg_0);  // Mete en pila la referencia a la clase contenedora (this).
			ilgDynamicCodeEvent.Emit(OpCodes.Ldarg_1);  // sender.
			ilgDynamicCodeEvent.Emit(OpCodes.Ldarg_2);  // Parámetro.
			ilgDynamicCodeEvent.Emit(OpCodes.Call, staticHandlerEvent); // Llama a eventSource_evento
			ilgDynamicCodeEvent.Emit(OpCodes.Nop);
			ilgDynamicCodeEvent.Emit(OpCodes.Ret);

			// Por último, se enlaza el manejador.
			delegade = dynamicHandlerEvent.CreateDelegate(eventHandlerType, eventListener);
			eventInfo.AddEventHandler(eventSource, delegade);
		}
	}
}

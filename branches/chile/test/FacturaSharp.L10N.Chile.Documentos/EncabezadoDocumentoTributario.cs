using System;

namespace FacturaSharp.L10N.Chile.Documentos
{
	public class EncabezadoDocumentoTributario
	{
		// Propiedades
		
		public TipoDocumentoTributario TipoDocumento
		{
			get; private set;
		}
		public string Version
		{
			get; private set;
		}
		
		
		
		// Constructor
		
		public EncabezadoDocumentoTributario (TipoDocumentoTributario tipoDocumento)
		{
			// Versión
			this.Version = "1.0";
			
			// Guardar tipo
			this.TipoDocumento = tipoDocumento;
		}
	}
}

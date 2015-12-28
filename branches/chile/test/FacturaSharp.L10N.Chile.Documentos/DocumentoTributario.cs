using System;

namespace FacturaSharp.L10N.Chile.Documentos
{
	public abstract class DocumentoTributario
	{
		// Propiedades
		
		public EncabezadoDocumentoTributario Encabezado
		{
			get; private set;
		}
		
		
		
		// Constructor
		
		protected DocumentoTributario (TipoDocumentoTributario tipoDocumento)
		{
			// Crear encabezado
			this.Encabezado = new EncabezadoDocumentoTributario (tipoDocumento);
		}
	}
}

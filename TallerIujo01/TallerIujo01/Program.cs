/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 17/04/2026
 * Hora: 10:53
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace TallerIujo01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("=== Taller 01 ===");
			 
			// 1. El dato del usuario
			string registroUsuario = "	ID_77;	juanperez;	EXAMEN_FINAL.PDF; 	95";
			
			Console.WriteLine(registroUsuario);
			string registroLimpio = registroUsuario.Trim();
			Console.WriteLine(registroLimpio);
			
			string[] partes = registroLimpio.Split(';');
			string id = partes[0].Trim();
			string nombre = partes[1].Trim();
			string descripcion = partes[2].Trim();
			string nota = partes[3].Trim();
			
			Console.WriteLine(string.Format("El ID es: {0} del usuario: {1} descripción: {2} con la nota: {3}", id, nombre, descripcion, nota));
			
			// Flujo de Archivos
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIUJO");
			string rutaReportes = Path.Combine(rutaRaiz, "Reportes");
			
			if (!Directory.Exists(rutaReportes))
			{
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Carpeta de reportes creada exitosamente");
			}
			
			string archivoTexto = Path.Combine(rutaReportes, "notas.txt");
			Console.WriteLine(archivoTexto);
			
			using (StreamWriter sw = new StreamWriter(archivoTexto, true))
			{
				sw.WriteLine(string.Format("ESTUDIANTE: {0}	|	NOTA: {1}	|	FECHA: {2: yyyy-MM-dd HH:mm}", nombre, nota, DateTime.Now));
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
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
			
			// DESAFIO 1
			
			string datos = "usuario;clave123";
			
			string[] partesClave = datos.Split(';');
			string clave = partesClave[1];
			
			if (clave.Contains("123"))
			{
				using (StreamWriter sw = new StreamWriter("Seguridad.txt", true))
				{
					sw.WriteLine("Clave Débil detectada");
				}
				Console.WriteLine("Aviso guardado en Seguridad.txt");
			}
			
			else
			{
				Console.WriteLine("La clave es segura");
			}
			
			// DESAFIO 2 
			
			string origen = "avatar.jpg";
			string destino = "respaldo.jpg";
			
			try
			{
				using (FileStream fsOrigen = new FileStream(origen, FileMode.Open, FileAccess.Read))
				using (FileStream fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
				{
					byte[] buffer = new byte[1024];
					int bytesLeidos;
					
					Console.WriteLine("Iniciado copiado de imágenes...");
					
					while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0)
					{
						fsDestino.Write(buffer, 0, bytesLeidos);
					}
				}
				Console.WriteLine("Imagen clonada con éxito como respaldo.jpg");
			}
			
			catch (FileNotFoundException)
			{
				Console.WriteLine("ERROR: no se encontró el archivo avatar.jpg");
			}
			
			catch (Exception ex)
			{
				Console.WriteLine("Ocurrió un error" + ex.Message);
			}
			
			// DESAFIO 3
			
			string rutaCarpeta = AppDomain.CurrentDomain.BaseDirectory;
            string[] archivos = Directory.GetFiles(rutaCarpeta);

            foreach (string archivo in archivos)
            {
                FileInfo info = new FileInfo(archivo);
                if (info.Length > 5120)
                {
                    if (info.Name != "DesafiosVarios.exe" && info.Name != "avatar.jpg")
                    {
                        Console.WriteLine("Borrando archivo pesado: " + info.Name);
                    }
                }
            }

            Console.WriteLine("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
    }
}
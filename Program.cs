using CoreEscuela;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

var engine = new EscuelaEngine();
engine.Inicializar();
Printer.EscribirTitulo("Bienvenidos a la escuela");
Printer.Beep();
ImprimirCursosEscuela(engine.Escuela);

void ImprimirCursosEscuela(Escuela escuela)
{
    Printer.EscribirTitulo("Cursos de la Escuela");
    if (escuela?.Cursos != null)
    {
        foreach (var curso in escuela.Cursos)
        {
            WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
        }
    }
}
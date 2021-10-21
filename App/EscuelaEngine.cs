using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Medellín");
            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
            Console.WriteLine("Proceso terminado");
        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignatura)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var random = new Random();
                        for (int i = 0; i < 5; i++)
                        {
                            Evaluacion evaluacion = new Evaluacion()
                            {
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = (float)(random.NextDouble() * (5.0 - 0.0) + 0.0),
                            };
                            alumno.Evaluaciones.Add(evaluacion);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignatura = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };

            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}
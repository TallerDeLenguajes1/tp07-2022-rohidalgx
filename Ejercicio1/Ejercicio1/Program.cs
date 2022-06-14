using Ejercicio1;

public class Program
{

    private static readonly string[] Descripciones = { "Trabajar", "Tomar Cafe", "Limpiar", "Ordenar", "Hacer cosas" };
    private const int MaximoDuracion = 100;

    public static int Main(string[] args)
    {
        string? BusquedaDescripcion;

        List<Tarea> tareas = new List<Tarea>();
        List<Tarea> tareasHechas = new List<Tarea>();
        List<Tarea> tareasBuscadas = new List<Tarea>();

        Console.WriteLine("Ingrese cuantas tareas crear aleatoriamente");
        int cantidadTareas = int.Parse(Console.ReadLine());

        /*
        *   Creamos las tareas aleatorias
        */
        for (uint i = 0; i < cantidadTareas; i++)
        {
            Tarea temporal = CrearTareaAleatoria((int)i);
            tareas.Add(temporal);
            temporal.MostrarTarea();
        }

        /*
        *   Movemos las tareas pendientes a las realizadas
        */
        foreach (Tarea tarea in tareas)
        {
            Console.WriteLine("¿Desea moverla a tareas pendiente? - (1 - Sí, 2 - No)");
            tarea.MostrarTarea();

            int Respuesta = Int32.Parse(Console.ReadLine());

            if (Respuesta == 1)
            {
                tareasHechas.Add(tarea);
            }
        }

        // Elimino todas las tareas pendientes que se encuentren en hechas
        tareas = tareas.Except(tareasHechas).ToList();

        /*
        *   Buscamos tareas pendientes por descripción
        */
        Console.WriteLine("Ingrese una descripción para buscar las tareas");
        BusquedaDescripcion = Console.ReadLine();

        foreach (Tarea temporal in tareas)
        {
            if (temporal.Descripcion.ToLower().Contains(BusquedaDescripcion.ToLower()))
            {
                tareasBuscadas.Add(temporal);
            }
        }

        Console.WriteLine("\n---- Tareas Buscadas ---");
        tareasBuscadas.ForEach(t => t.MostrarTarea());

        Console.WriteLine("\n--- Tareas Pendientes ---");
        tareas.ForEach(t => t.MostrarTarea());

        Console.WriteLine("\n--- Tareas Hechas ---");
        tareasHechas.ForEach(t => t.MostrarTarea());

        return 0;
    }


    /*
    *   Devuelve una tarea aleatoria
    */
    public static Tarea CrearTareaAleatoria(int ID)
    {
        Random aleatorio = new Random();
        int indiceDescripcion = aleatorio.Next(0, Descripciones.Length);
        int duracion = new Random().Next(0, MaximoDuracion);
        string descripcionAleatoria = Descripciones[indiceDescripcion];

        return new Tarea(ID, descripcionAleatoria, duracion);
    }
}


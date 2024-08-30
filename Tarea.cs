using System;

namespace ToDoListApp
{
    public class Tarea
    {
        public string Descripcion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public bool Completada { get; set; }

        //Constructor de las tareas
        public Tarea(string descripcion, DateTime? fechaLimite = null)
        {
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            Completada = false;
        }
        //Metodo que activa las Tareas
        public void MarcarComoCompletada()
        {
            Completada = true;
        }
        //Método que describe la tarea
        public override string ToString()
        {
            string estado = Completada ? "Completada" : "Pendiente";
            return $"Descripción: {Descripcion}, \nFecha Límite: {FechaLimite?.ToString("d") ?? "Sin fecha"}, \nEstado: {estado}\n";
        }
    }
}


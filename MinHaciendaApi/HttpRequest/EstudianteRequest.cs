﻿namespace MinHaciendaApi.HttpRequest
{
    public class EstudianteRequest
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
    }
}

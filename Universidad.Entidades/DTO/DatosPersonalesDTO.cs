﻿namespace Universidad.Entidades.DTO;

public class DatosPersonalesDTO
{
    public int IdDatos { get; set; }
    public string DNI { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

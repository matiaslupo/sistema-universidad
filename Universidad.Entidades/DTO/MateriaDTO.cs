﻿namespace Universidad.Entidades.DTO;

public class MateriaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public CarreraDTO Carrera { get; set; }
}

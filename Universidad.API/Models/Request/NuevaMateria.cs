using System.ComponentModel.DataAnnotations;

namespace Universidad.API.Models.Request;

public class NuevaMateria
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "El campo 'nombre de materia' es requerido.")]
    public string Nombre { get; set; } = string.Empty;
    [Required]
    [Range(1, int.MaxValue)]
    public int IdCarrera { get; set; }
}

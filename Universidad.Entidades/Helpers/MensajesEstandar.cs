namespace Universidad.Entidades.Helpers;

public static class MensajesEstandar
{
    public static string EntidadCreada(string nombreEntidad)
    {
        return $"{nombreEntidad} creado con exito.";
    }

    public static string Error(Exception e, string operacion)
    {
        return $"Ha ocurrido un error al realizar la operacion {operacion}. \n {e.Message} \n {e.StackTrace}"; 
    }

    public static string NoEncontrado(string nombreEntidad)
    {
        return $"No se ha encontrado {nombreEntidad} con esas credenciales.";
    }

    public static string Exito()
    {
        return "Operacion exitosa";
    }
}

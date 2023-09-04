namespace Universidad.Entidades.Interfaces;

public interface CRUD<T>
{
    public int Crear(T datos);

    public T ObtenerPorId(int id);

    public void EliminarPorId(int id);
}

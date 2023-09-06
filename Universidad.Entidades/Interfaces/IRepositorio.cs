namespace Universidad.Entidades.Interfaces;

public interface IRepositorio<T>
{
    public int Crear(T datos);
    public List<T> Listar();

    public T ObtenerPorId(int id);

    public void EliminarPorId(int id);
}

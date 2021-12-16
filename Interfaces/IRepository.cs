namespace tv_series_registration_app.Interfaces
{
    public interface IRepository<T>
    {
         List<T> ListSeries();
         T ReturnById(int id);
         void InsertSerie(T entity);
         void DeleteSerie(int id);
         void UpdateSerie(int id, T entity);
         int NextId();
    }
}
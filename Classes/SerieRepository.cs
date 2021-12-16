using tv_series_registration_app.Interfaces;

namespace tv_series_registration_app
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSeries = new List<Serie>();
        public void DeleteSerie(int id)
        {
            listSeries[id].DeletedSerie();
        }

        public void InsertSerie(Serie entity)
        {
            listSeries.Add(entity);
        }

        public List<Serie> ListSeries()
        {
            return listSeries;
        }

        public int NextId()
        {
            return listSeries.Count;
        }

        public void UpdateSerie(int id, Serie entity)
        {
            listSeries[id] = entity;
        }

        public Serie ReturnById(int id)
        {
            return listSeries[id];
        }
    }
}
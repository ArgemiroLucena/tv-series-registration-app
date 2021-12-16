namespace tv_series_registration_app
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Tittle { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string tittle, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Tittle = tittle;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "Gênero: " + this.Genre + Environment.NewLine;
            ret += "Título: " + this.Tittle + Environment.NewLine;
            ret += "Descrição: " + this.Description + Environment.NewLine;
            ret += "Ano de Início: " + this.Year + Environment.NewLine;
            ret += "Excluído: " + this.Deleted;
            return ret;
        }

        public string returnTittle()
        {
            return this.Tittle;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void DeletedSerie()
        {
            this.Deleted = true;
        }
    }
}
namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public List<ML.Libro> Libros { get; set; }
    }
}
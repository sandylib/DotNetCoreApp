using System.ComponentModel.DataAnnotations;

namespace DotnetCoreApp.Entities
{
    public class MovieData
    {
        [Key]
        public int MovieId { get; set; }
        public string Cast { get; set; }
        public string Classification { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public int ReleaseDate { get; set; }
        public string Title { get; set; }
    }
}

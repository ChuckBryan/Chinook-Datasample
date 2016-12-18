namespace Chinook3.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Album")]
    public class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }
    }
}
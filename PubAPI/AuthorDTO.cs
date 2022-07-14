using System.Drawing;

namespace PubAPI
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Color? FavoriteColor { get; set; }
    }
}

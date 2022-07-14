// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using System.Drawing;

Console.WriteLine("Posting a new author - testing out ValueConverter feature of EF Core 6");


var options = new DbContextOptionsBuilder<PubContext>()
    .UseSqlServer("Data Source = he209504\\sqlexpress01; Initial Catalog = PubDatabase_M12_Api_EfCoreCourse; Trusted_Connection=true");



using var pubContext = new PubContext(options.Options);


var authorInsert = new PublisherDomain.Author
{
    FirstName = "Claude",
    LastName = "Monet",
    FavoriteColor = Color.Aquamarine
}; 

pubContext.Authors.Add(authorInsert);

await pubContext.SaveChangesAsync();

var insertedAuthor = pubContext.Authors.Find(authorInsert.AuthorId);

string convertColorToArgbName(Color someColor) => Color.FromArgb(Color.Aquamarine.ToArgb()).Name;

string insertedAuthorFavoriteColorArgb = convertColorToArgbName(authorInsert.FavoriteColor.Value);
string aquaMarineColorArgb = convertColorToArgbName(Color.Aquamarine);

Console.WriteLine($"Favorite color is expected? {insertedAuthorFavoriteColorArgb.Equals(aquaMarineColorArgb)}");

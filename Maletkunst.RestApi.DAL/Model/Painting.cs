namespace RestApi.DAL.Model;

public class Painting
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Artist { get; set; }
    public string Description { get; set; }

    public string Category { get; set; }

    public Painting(string title, decimal price, int stock, string artist, string description, string category)
    {
        Title = title;
        Price = price;
        Stock = stock;
        Artist = artist;
        Description = description;
        Category = category;
    }

    public Painting()
    {

    }

    public Painting(int id, string title, decimal price, int stock, string artist, string description, string category)
        : this(title, price, stock, artist, description, category)
    {
        Id = id;
    }

    public override string? ToString() => $"{Id}, {Title}, {Price},{Stock},{Artist},{Description}, {Category}";
}
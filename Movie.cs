public class Movie
{
    public string title { get; set; }
    public int Year { get; set; }
    public int minutes { get; set; }
    public int serialNumber { get; set; }
    public int price { get; set; }
    public string director { get; set; }

    public override string ToString()
    {
        return $"{title} {Year} {minutes} {serialNumber} {price} {director}";
    }
}
public class User
{
     public int id { get; set; }
    public string name { get; set; }
    public string eMail { get; set; }
    public int phoneNumber { get; set; }
    public string city { get; set; }
    public int postalCode { get; set; }

    public override string ToString()
    {
        return $"{id} {name} {eMail} {phoneNumber} {city} {postalCode}";
    }
}
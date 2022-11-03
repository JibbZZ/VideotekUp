using Dapper;
using MySqlConnector;

class Videotek
{
    /*public int id { get; set; }
    public string name { get; set; }
    public string eMail { get; set; }
    public int phoneNumber { get; set; }
    public string city { get; set; }
    public int postalCode { get; set; }
    public string title { get; set; }
    public int Year { get; set; }
    public int minutes { get; set; }
    public int serialNumber { get; set; }
    public int price { get; set; }
    public string director { get; set; }*/
    
    public void Start()
    {

        string prompt = "Välkommen till Videoteket";
        string[] options = { "Movies", "Rent Movies", "Profile", "Exit" };
        Menu menu = new Menu(prompt, options);
        int SelectedIndex = menu.Run();

        switch (SelectedIndex)
        {
            case 0:
                ListMovies();
                break;
            case 1:
                RentMovies();
                break;
            case 2:
                ShowProfile();
                break;
            case 3:
                ExitGame();
                break;
        }

    }

    private void ExitGame()
    {
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
        Environment.Exit(0);

    }
    private void ListMovies()

    {
        {

            using (var connection = new MySqlConnection("Server=localhost;Database=videotek;Uid=root;"))
            {
                var movies = connection.Query<Movie>("SELECT title FROM Movies").ToList();
                foreach (Movie m in movies)
                {
                    Console.WriteLine(m.title);
                }
            }

        }

    }
    private void RentMovies()
    {




    }
    private void ShowProfile()
    {

        using (var connection = new MySqlConnection("Server=localhost;Database=videotek;Uid=root;"))
        {
            var users = connection.Query<User>("SELECT id, name, eMail, phoneNumber, city, postalCode FROM Users;").ToList();
            foreach (User u in users)
            {
                Console.WriteLine(u.id + "  " + u.name + " " + u.eMail + " " + u.phoneNumber + " " + u.city + " " + u.postalCode);
            }
        }

    }

}
using Dapper;
using MySqlConnector;

class Videotek
{    
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
                ShowMember();
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
         using (var connection = new MySqlConnection("Server=localhost;Database=videotek;Uid=root;"))
         {
            var movies = connection.Query<Movie>("SELECT title FROM Movies").ToList();
            foreach (Movie m in movies)
            {
                Console.WriteLine(m.title);
            }
         }
    }
    private void RentMovies()
    {
        using (var connection = new MySqlConnection("Server=localhost;Database=videotek;Uid=root;"))
        {
            var order = connection.Query<Order>("SELECT id, user_id, movie_id, rent_date (dd/mm/yy) FROM Orders").ToList();
            foreach (Order o in order)
            {
                Console.WriteLine("ID: " + o.id + ", " + "User ID: "+ o.user_id + ", " + "Movie ID: " + o.movie_id + ", " + "Rented at: " + o.rent_date);
            }
        }
    }
    private void ShowMember()
    {

        using (var connection = new MySqlConnection("Server=localhost;Database=videotek;Uid=root;"))
        {
            var users = connection.Query<User>("SELECT id, name, eMail, phoneNumber, city, postalCode FROM Users;").ToList();
            foreach (User u in users)
            {
                Console.WriteLine("ID: " + u.id + ", " + "Name: " + u.name + ", " + "Email: " + u.eMail + ", " + "Phonenumber: " + u.phoneNumber + ", " + "City: " + u.city + ", " + "Postal code: " + u.postalCode);
            }
        }

    }

}
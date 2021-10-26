using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBuildBlockbusterLab
{
    internal class BlockBuster
    {
        private List<string> genres = new List<string>()
        {
            "Drama",
            "Comedy",
            "Horror",
            "Romance",
            "Action"
        };

        private List<Movie> movies = new List<Movie>()
        {
            new DVD("The Lord of the Ring: Fellowship of the Ring", Movie.Genre.Romance, 178, new List<string> {"A wizard is never late, Frodo Baggins. Nor is he early. He arrives precisely when he means to.",
                "No, thank you! We don't want any more visitors, well-wishers or distant relations!",
                "I don't know half of you half as well as I should like; and I like less than half of you half as well as you deserve.",
                "YOU SHALL NOT PASS!",
                "Fly you fools!",
                "I made a promise, Mr Frodo. A promise. \"Don't you leave him Samwise Gamgee.\" And I don't mean to. I don't mean to."}),

            new DVD("The Lord of the Ring: Twin Towers", Movie.Genre.Drama, 179, new List<string> {"They're taking the hobbits to Isengard.",
                "Saruman!",
                "Po-tay-toes! Boil 'em, mash 'em, stick 'em in a stew.",
                "Give me your name horse-master, and I shall give you mine.",
                "Legolas! two already!",
                " What! Ain't no pointy eared elf outscoring me!! raaaahrr",
                "The battle of Helm's Deep is over; the battle for Middle Earth is about to begin."}),

            new DVD("The Lord of the Ring: Return of the King", Movie.Genre.Horror, 201, new List<string> {"I am no MAN!",
                "CERTAINTY OF DEATH. SMALL CHANCE OF SUCCESS. WHAT ARE WE WAITING FOR?",
                "I can't carry it for you, but I canmm carry YOU.",
                "For Frodo.",
                "It's over. It's done.",
                "Here at last... comes the end of our fellowship. I will not say do not weep, for not all tears are an evil.",}),

            new VHS("The Hobbit: An Unexpected Journey", Movie.Genre.Comedy, 169, new List<string> {"True courage is not knowing when to take a life, but when it spare it.",
                "The world is not in your books and maps. It's out there.",
                "I'm going on an adventure!",
                "These are gundabad wargs. They will outrun you!",
                "These are Rhosgobel Rabbits! I'd like to see them try.",
                "I can't just running off into the blue. I'm a Baggins of bag end!"}),

            new VHS("The Hobbit: The Desolation of Smaug", Movie.Genre.Action, 161, new List<string> {" Come out. Don't be shy. Step into the light.",
                "I am King Under the Mountain!",
                "Do not think that flattery will keep you alive.",
                "Well, thief! Where are you?!",
                "My teeth are swords! My claws are spears! My wings are a hurricane!",
                "I am fire... I am death."}),

            new VHS("The Hobbit: The Battle of the Five Armies", Movie.Genre.Romance, 144, new List<string> {"You have no place here! You are nameless! Go back to the shadow from whence you came!",
                "You've won the mountain, is that not enough?",
                "That is Dain Ironfoot, Thorin's cousin. I've always felt Thorin was the more reasonable of the two...",
                "Leave Sauron to me!",
                "I am sorry that I made you a part of my perils...",
                "No! I am glad to have shared in your perils - that is more than any Baggins deserves!"})
        };

        private void OrderMovieList()
        {
            movies = movies.OrderBy(movie => movie.Title).ToList();
        }

        public void PrintMovies()
        {
            OrderMovieList();
            Console.WriteLine("Here are the available movies:");
            foreach (Movie movie in movies)
            {
                Console.WriteLine("{0, -5} {1}", $"[{movies.IndexOf(movie) + 1}]:", movie.Title);
            }
        }

        public void Checkout()
        {
            try
            {
                PrintMovies();
                Console.WriteLine();
                int userChoice = int.Parse(GetUserInput("Please enter which movie you would like to watch: "));
                Console.WriteLine(movies[userChoice - 1]);

                if (WatchMovie())
                {
                    movies[userChoice - 1].Play();
                }
            }
            catch
            {
                Console.WriteLine("Invalid movie Index");
                Checkout();
            }
        }

        public bool WatchMovie()
        {
            string answer = GetUserInput("Do you want to watch the movie? (y/n): ");

            switch (answer.Trim().ToLower())
            {
                case "y":
                    return true;

                case "n":
                    return false;

                default:
                    Console.WriteLine("That input was invalid. Please try again");
                    return WatchMovie();
            }
        }

        public void PlayAllMovies()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This is to show off the playing of the whole movies");

            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
                movie.PlayWholeMovie();
            }
        }

        public string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string output = Console.ReadLine().Trim().ToLower();
            Console.WriteLine();

            return output;
        }
    }
}
/*
 *Create a WPF application that will call a web-service and answer a few questions for the user.  
 * It is up to you to create an appropriate WPF interface (e.g. GUI), however, you need to have a 
 * button for the user to click to start the process, each question should be displayed with the 
 * answer next to it where the user cannot change the answer (don’t want them faking the results!).  
 * Anytime that there is a movie title in the answer, it should link 
 * to the IMDB link associated with it.  
 * The URL for the webservice is http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100 
 *  Note, there is an URL parameter (e.g. query string) with 100.  This limits the results to 100 
 *  so that it is faster, you can move it up and down based upon your connection, 
 *  it should not affect your code at all.
 * The questions your application need to answer for the user, are as follows:
        List all of the different genres for the movies
        Which movie has the highest IMDB score?
        List all of the different movies that have a number of voted users with 350000 or more
        How many movies where Anthony Russo is the director?
        How many movies where Robert Downey Jr. is the actor 1? 
 
 * @Author : Adam Ackerman
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JSON_Movie_Review
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClearAll();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            List<Movie> MoviesNumberUsersVoted = new List<Movie>();

            //Get all of the data we need to perform our analytics
            List<Movie> movies = GettingDataFromWebservice();

            //Start answering our questions

            // 1.List all of the different genres for the movies
            GetAllGenresForMovies(movies);

            // 2. Which movie has the highest IMDB score?
            GetHighestIMDBScoreMovies(movies);

            // 3. List all of the different movies that have a number of voted users with 350000 or more
            GetAllMoviesWithVotedUsersGreaterThan(movies, 350000);

            // 4. How many movies where Anthony Russo is the director ?
            HowManyMoviesAnthonyRussoDirected(movies);

            // 5. How many movies where Robert Downey Jr. is the actor 1 ?
            HowManyMoviesRobertDowneyJrWasActor1(movies);

        }

        /// <summary>
        /// Determines the number of movies where RDJ was actor 1
        /// </summary>
        /// <param name="movies">The dataset to go through</param>
        private void HowManyMoviesRobertDowneyJrWasActor1(List<Movie> movies)
        {
            int count = 0;
            foreach (var movie in movies)
            {
                if (movie.actor_1_name == "Robert Downey Jr.")
                {
                    count++;
                }
            }
            txtRobertDowney.Text = count.ToString("N0");
        }

        /// <summary>
        /// Determines the number of movies where AR was the director
        /// </summary>
        /// <param name="movies">The dataset to go through</param>
        private void HowManyMoviesAnthonyRussoDirected(List<Movie> movies)
        {
            int count = 0;
            foreach (var movie in movies)
            {
                if (movie.director_name == "Anthony Russo")
                {
                    count++;
                }
            }
            txtAnthonyRusso.Text = count.ToString("N0");
        }

        /// <summary>
        /// Get all the movies from the data set that are greater than or equal to a value
        /// </summary>
        /// <param name="movies">The data to go through</param>
        /// <param name="v">The value that property should be >= </param>
        private void GetAllMoviesWithVotedUsersGreaterThan(List<Movie> movies, int v)
        {
            foreach (var movie in movies)
            {
                if (movie.num_voted_users >= v)
                {
                    Hyperlink h = new Hyperlink();
                    h.NavigateUri = new Uri(movie.movie_imdb_link);
                    h.Inlines.Add(movie.movie_title);
                    h.RequestNavigate += LinkOnRequestNavigate;

                    lstVotedUsers.Items.Add(h);
                }
            }
        }

        /// <summary>
        /// Get the highest IMDB_Score from the dataset
        /// </summary>
        /// <param name="movies">A list of Movie instances that we want to get the genres from.</param>
        private void GetHighestIMDBScoreMovies(List<Movie> movies)
        {
            List<Movie> highestIMDBScores = new List<Movie>();
            foreach (var movie in movies)
            {
                if (highestIMDBScores.Count < 1)
                {
                    highestIMDBScores.Add(movie);
                    continue;
                }
                else
                {
                    if (highestIMDBScores[0].imdb_score < movie.imdb_score) // we have new highest imdb_score
                    {
                        highestIMDBScores.Clear();
                        highestIMDBScores.Add(movie);
                    }
                    else if (highestIMDBScores[0].imdb_score == movie.imdb_score) // have the same score, so add this movie to the list
                    {
                        highestIMDBScores.Add(movie);
                    }
                    else// the current instance of Movie (movie)
                    {
                        // don't need to add to the list, or clear the list
                    }
                }
            }
            if (highestIMDBScores.Count() > 1)
            {
                string content = "";
                foreach (var m in highestIMDBScores)
                {
                    content += m.movie_title + '\n';
                }
                txtHighestIMDBScore.Text = content;

            }
            else
            {
                Hyperlink h = new Hyperlink();
                h.NavigateUri = new Uri(highestIMDBScores[0].movie_imdb_link);
                h.Inlines.Add(highestIMDBScores[0].movie_title);
                h.RequestNavigate += LinkOnRequestNavigate;

                txtHighestIMDBScore.Inlines.Add(h);
            }
        }

        private void LinkOnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        /// <summary>
        /// Get all the genres from all the movies and add them to the listbox
        /// </summary>
        /// <param name="movies">A list of Movie instances that we want to get the genres from.</param>
        private void GetAllGenresForMovies(List<Movie> movies)
        {
            Dictionary<string, int> genres = new Dictionary<string, int>();
            foreach (var movie in movies)
            {
                if (movie.genres.Contains("|"))
                {
                    var gs = movie.genres.Split('|');
                    foreach (var g in gs)
                    {
                        if (genres.ContainsKey(g))
                        {
                            genres[g] = genres[g]+1;
                        }
                        else
                        {
                            genres.Add(g, 1);
                        }
                        //lstGenres.Items.Add(g);
                    }
                }
                else
                {
                    if (genres.ContainsKey(movie.genres))
                    {
                        genres[movie.genres] = genres[movie.genres] + 1;
                    }
                    else
                    {
                        genres.Add(movie.genres, 1);
                    }
                    //lstGenres.Items.Add(movie.genres);
                }
            }

            foreach (var key in genres.Keys)
            {
                lstGenres.Items.Add($"{key}({genres[key].ToString("N0")})");
            }
        }

        /// <summary>
        /// Get the list of movies from the provided web-service
        /// </summary>
        /// <returns>A list of Movie objects</returns>
        private static List<Movie> GettingDataFromWebservice()
        {
            List<Movie> movies;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(@"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            }

            return movies;
        }

        /// <summary>
        /// Clears all of the output controls.
        /// </summary>
        private void ClearAll()
        {
            txtAnthonyRusso.Inlines.Clear();
            txtHighestIMDBScore.Inlines.Clear();
            txtRobertDowney.Inlines.Clear();
            lstGenres.Items.Clear();
            lstVotedUsers.Items.Clear();
        }
    }
}

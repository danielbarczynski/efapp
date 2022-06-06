using Microsoft.EntityFrameworkCore;

namespace efapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDbContext();
            MovieController controller = new MovieController(context);

            var movie1 = new Movie() { Name = "LOTR", Price = 45 };
            var movie2 = new Movie() { Name = "Witcher", Price = 35 };

            //controller.Add(movie1);
            //controller.Add(movie2);

            //controller.Update(1, "hp", 10);

            var movies = context.Movies.ToList();

            foreach (var item in movies)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + "pln");
            }

            controller.Search("t");
            controller.Find(10);
            controller.Find2(11);
        }
    }
}
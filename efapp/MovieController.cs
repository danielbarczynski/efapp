using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efapp
{
    public class MovieController
    {
        AppDbContext _db;

        public MovieController(AppDbContext db)
        {
            _db = db;
        }

        public void Add(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {     
            _db.Movies.Remove(new Movie { Id = id });
            _db.SaveChanges();
        }

        public void Update(int id, string name, int price)
        {
            _db.Movies.Update(new Movie { Id = id, Name = name, Price = price});
            _db.SaveChanges();
        }

        public void Search(string name)
        {
            IQueryable<Movie> query = _db.Movies.Where(x => x.Name.Contains(name));

            var query2 = query.ToList().OrderByDescending(x => x.Id);

            Console.WriteLine($"\nQuery: {name}");
            foreach (var item in query2)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Price + "pln");
            }
            
        }

        public void Find(int id)
        {
            var query = _db.Movies.FirstOrDefault(x => x.Id == id);
            Console.WriteLine($"\nFind: {id}");
            Console.WriteLine(query.Id + " " + query.Name + " " + query.Price + "pln");
        }
        
        public void Find2(int id)
        {
            var query = _db.Movies.Find(id);
            Console.WriteLine($"\nFind2: {id}");
            Console.WriteLine(query.Id + " " + query.Name + " " + query.Price + "pln");
        }
    }
}

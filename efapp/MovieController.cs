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
    }
}

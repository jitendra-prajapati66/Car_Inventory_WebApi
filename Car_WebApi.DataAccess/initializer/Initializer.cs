using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace Car_WebApi.DataAccess.initializer
{
    public class Initializer : IInitializer
    {
        private readonly ApplicationDBContext _db;
        public Initializer(ApplicationDBContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

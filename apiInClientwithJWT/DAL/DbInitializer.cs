using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using apiInClientwithJWT.Models;

namespace apiInClientwithJWT.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(ApiContext context)
        {
            // Ensure the DB exists
            context.Database.EnsureCreated();

            // Look for any records
            if (context.Api.Any() || context.User.Any())
            {
                return; // DB has records. No need to go further.
            }

            var api = new Api[]
            {
                new Api { Message = "Hello!", CreatedOn = DateTime.UtcNow },
                new Api { Message = "Hello There!", CreatedOn = DateTime.UtcNow },
                new Api { Message = "Hello World!", CreatedOn = DateTime.UtcNow },
                new Api { Message = "Hello Gorgeous!", CreatedOn = DateTime.UtcNow },
                new Api { Message = "Hello Dolly!", CreatedOn = DateTime.UtcNow }
            };

            foreach (Api a in api)
            {
                context.Api.Add(a);
            }

            context.SaveChanges();

            var users = new User[]
            {
                new User { Username = "letmein", Password = "$2a$12$NEF72rLLUh6bBcIa0xuwvueg6RmdUkdt9FJ65o2e1qJPafRJtgvn6"}
            };

            foreach (User user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();
        }
    }
}

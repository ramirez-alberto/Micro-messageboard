using Microsoft.EntityFrameworkCore;
using Micro_messageboard.Models;

namespace Micro_messageboard.Data
{
    public class SeedMicroMessageBoard
    {
        public static void Initialize(MicroMessageBoardContext context)
        {

            if (context.Users.Any())
                return;

            var users = new User[]
            {
                new User {UserName = "User1", Email = "a@gmail.com", Password = "1234567889"},
                new User {UserName = "User2", Email = "b@gmail.com", Password = "1234567889"},
                new User {UserName = "User3", Email = "c@gmail.com", Password = "1234567889"},
                new User {UserName = "User4", Email = "d@gmail.com", Password = "1234567889"},
                new User {UserName = "User5", Email = "e@gmail.com", Password = "1234567889"},
                new User {UserName = "User6", Email = "f@gmail.com", Password = "1234567889"}
            };

            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post { Title="Post Example0", Body="A body", UserId=users.Single(u => u.UserName == "User1").UserId},
                new Post { Title="Post Example1", Body="A body", UserId=users.Single(u => u.UserName == "User1").UserId},
                new Post { Title="Post Example2", Body="A body", UserId=users.Single(u => u.UserName == "User1").UserId}
            };

            foreach (Post post in posts)
            {
                context.Posts.Add(post);
            }
            context.SaveChanges();
        }
    }
}

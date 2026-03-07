using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31LINQExercise
{
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }

    internal class _09SocialMediaAnalytics
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                    new User{Id=1, Name="A", Country="India"},
                    new User{Id=2, Name="B", Country="USA"}
            };

            var posts = new List<Post>
            {
                    new Post{UserId=1, Likes=100},
                    new Post{UserId=1, Likes=50}
            };

            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("top User By total Likes");
            var TopLiked = users.Join(posts, u => u.Id, p => p.UserId, (u, p) => new
            {
                ID = u.Id,
                Likes = p.Likes

            }).GroupBy(c => c.ID).Select(z => new
            {

                Id = z.Key,
                TotalLikes = z.Sum(s => s.Likes)
            }).OrderByDescending(t => t.TotalLikes).First();

            Console.WriteLine(TopLiked.Id + " - " + TopLiked.TotalLikes);
            Console.WriteLine("---------------");
            Console.WriteLine("Group Users By Country");

            var groupbyCountry = users.GroupBy(x => x.Country).ToList();
            foreach (var i in groupbyCountry)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
                {
                    Console.WriteLine("ID -" + j.Id);
                }
            }

            var inactiveUsers = users.GroupJoin(posts, user => user.Id, post => post.UserId, (user, userPosts) => new
               {
                   User = user,
                   Posts = userPosts
               })
               .Where(x => !x.Posts.Any())
               .Select(x => x.User);

            Console.WriteLine("---------------");
            Console.WriteLine("Inacive Users: ");
            foreach (var user in inactiveUsers)
            {
                Console.WriteLine($"{user.Name}");
            }

            double averageLikes = posts.Average(p => p.Likes);
            Console.WriteLine("---------------------");
            Console.WriteLine("Average Likes Per Post: " + averageLikes);





        }
    }
}

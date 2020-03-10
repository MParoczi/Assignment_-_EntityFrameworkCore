using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.Contexts;
using Blog.Models;

namespace Blog.Data.Resources
{
    public static class DbInitializer
    {
        public static void Initialize(BlogContext context)
        {
            if (context.Users.Any() && context.Posts.Any())
            {
                return;
            }

            User winstonChurchill = new User
                {Id = Guid.NewGuid().ToString(), FirstName = "Winston", LastName = "Churchill", Posts = new List<Post>()};
            User albertEinstein = new User
                {Id = Guid.NewGuid().ToString(), FirstName = "Albert", LastName = "Einstein", Posts = new List<Post>()};
            User abrahamLincoln = new User
                {Id = Guid.NewGuid().ToString(), FirstName = "Abraham", LastName = "Lincoln", Posts = new List<Post>()};


            User[] users =
            {
                winstonChurchill,
                albertEinstein,
                abrahamLincoln
            };

            foreach (User user in users) context.Users.Add(user);

            context.SaveChangesAsync();

            Post quoteOne = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = winstonChurchill,
                UserId = winstonChurchill.Id, 
                Content = "We make a living by what we get, but we make a life by what we give."
            };
            Post quoteTwo = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = winstonChurchill,
                UserId = winstonChurchill.Id, 
                Content = "If you’re going through hell, keep going."
            };
            Post quoteThree = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = winstonChurchill,
                UserId = winstonChurchill.Id, 
                Content = "You have enemies? Good. That means you’ve stood up for something, sometime in your life."
            };
            Post quoteFour = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = albertEinstein,
                UserId = albertEinstein.Id, 
                Content = "Look deep into nature, and then you will understand everything better."
            };
            Post quoteFive = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = albertEinstein,
                UserId = albertEinstein.Id, 
                Content = "All religions, arts and sciences are branches of the same tree."
            };
            Post quoteSix = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = albertEinstein,
                UserId = albertEinstein.Id, 
                Content = "A human being is part of a whole called by us “Universe.”"
            };
            Post quoteSeven = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = abrahamLincoln,
                UserId = abrahamLincoln.Id, 
                Content = "Whatever you are, be a good one."
            };
            Post quoteEight = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = abrahamLincoln,
                UserId = abrahamLincoln.Id, 
                Content = "I would rather be a little nobody, then to be a evil somebody."
            };
            Post quoteNine = new Post
            { 
                Id = Guid.NewGuid().ToString(),
                User = abrahamLincoln,
                UserId = abrahamLincoln.Id, 
                Content = "Folks are usually about as happy as they make their minds up to be."
            };

            Post[] posts =
            {
                quoteOne,
                quoteTwo,
                quoteThree,
                quoteFour,
                quoteFive,
                quoteSix,
                quoteSeven,
                quoteEight,
                quoteNine
            };

            foreach (Post post in posts)
            {
                post.User.Posts.Add(post);
                context.Users.Update(post.User);
                context.Posts.Add(post);
            }

            context.SaveChangesAsync();
        }
    }
}
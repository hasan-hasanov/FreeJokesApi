using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstract;
using Domain.Entities;
using Moq;

namespace Application.Test
{
    public class UnitTestContext
    {
        public List<Category> Categories { get; set; }

        public List<Joke> Jokes { get; set; }

        public Mock<IJokeService> JokeService { get; set; }

        public UnitTestContext()
        {
            Categories = GetCategories();
            Jokes = GetJokes();

            JokeService = new Mock<IJokeService>();

            JokeService.SetupGet(j => j.Categories).Returns(Categories);
            JokeService.SetupGet(j => j.Jokes).Returns(Jokes);
        }

        private List<Category> GetCategories()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Description = "Stupid"
                },
                new Category()
                {
                    Id = 2,
                    Description = "Programmer"
                },
                new Category()
                {
                    Id = 3,
                    Description = "Animal"
                }
            };
        }

        private List<Joke> GetJokes()
        {
            return new List<Joke>()
            {
                new Joke()
                {
                    Id = "d5f812512f7f426999f9daf79b78fe73",
                    Description = "Q: Why did the chewing gum cross the road? \n A: He was stuck to the chicken's foot.",
                    CategoryId = 3
                },
                new Joke()
                {
                    Id = "9734f88b513c4f88a51eb829ee3f3ce1",
                    Description = "Animals have two vital functions in today's society: to be delicious and to fit well.",
                    CategoryId = 3
                },
                new Joke()
                {
                    Id = "cfe96a38ae9c49b3b2922c0ca3aecec4",
                    Description = "What did Harry Potter do when he found the three-headed dog? \n He ran... wouldn't you?.",
                    CategoryId = 3
                },
                new Joke()
                {
                    Id = "2cbcff3a6fc443d18e6c36cbb25370d0",
                    Description = "A man enters a taxi with a hot dog. \n – Excuse me, this is not a restaurant! \n – I know. That’s why I brought my own food!",
                    CategoryId = 1
                },
                new Joke()
                {
                    Id = "5e150abacd2d46caa1955f81a0dd038a",
                    Description = "The congress regarding hypochondria was canceled due to illness.",
                    CategoryId = 1
                },
                new Joke()
                {
                    Id = "002515add8124a4a8072bdb6f1dbf3bb",
                    Description = "A SQL query goes into a bar, walks up to two tables and asks, \"Can I join you?\"",
                    CategoryId = 2
                },
                new Joke()
                {
                    Id = "eaaf9a581b39486eb6cd49d3a3880402",
                    Description = "Q: how many programmers does it take to change a light bulb? \n A: none, that's a hardware problem",
                    CategoryId = 2
                }
            };
        }
    }
}

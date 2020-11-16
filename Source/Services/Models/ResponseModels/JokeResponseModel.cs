using Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Services.Models.ResponseModels
{
    public class JokeResponseModel
    {
        public JokeResponseModel(Joke joke, float rating)
        {
            Id = joke.Id;
            Category = joke.Category.Name;
            Rating = rating;
            Parts = joke.Parts.Select(c => new JokePartResponseModel(c)).ToList();
            JokeFlags = joke.JokeFlags?.Select(c => c.Flag.Name).ToList();
        }

        public long Id { get; set; }

        public string Category { get; set; }

        public List<JokePartResponseModel> Parts { get; set; }

        public List<string> JokeFlags { get; set; }

        public float Rating { get; set; }
    }
}

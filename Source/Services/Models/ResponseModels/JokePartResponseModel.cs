using Core.Entities;

namespace Services.Models.ResponseModels
{
    public class JokePartResponseModel
    {
        public JokePartResponseModel(Part part)
        {
            Part = part.JokePart;
            Order = part.Order;
        }

        public string Part { get; }

        public int Order { get; set; }
    }
}

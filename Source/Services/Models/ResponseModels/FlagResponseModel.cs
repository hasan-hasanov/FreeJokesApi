using Core.Entities;

namespace Services.Models.ResponseModels
{
    public class FlagResponseModel
    {
        public FlagResponseModel(Flag flag)
        {
            Id = flag.Id;
            Name = flag.Name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}

using Bogus;
using FizzWare.NBuilder;
using GamblingAPI.Models;


namespace GamblingAPI.Data
{
    public class DBInitializer
    {
        public List<Player> Players { get; set; }

        public DBInitializer()
        {
            GeneratingDataUsingBogus();
            //SeedDataUsingNBuilder();
        }

        private void GeneratingDataUsingBogus()
        {
            const int numToSeed = 100;

            var pId = 1;
            var startPoints = 10000;
            var currentPoints = 0;
            Faker<Player> playerFaker = new Faker<Player>()
                .StrictMode(false)
                .UseSeed(1000)
                .RuleFor(p => p.ID, f => pId++)
                .RuleFor(p => p.OpeningPoints, startPoints)
                .RuleFor(p => p.CurrentPoints, currentPoints)
                ;

            Players = playerFaker.Generate(numToSeed);
        }

        protected void SeedDataUsingNBuilder()
        {
            Players = Builder<Player>.CreateListOfSize(10)
                .All()
                .With(player => player.OpeningPoints = 10000)
                .With(player => player.CurrentPoints = 0)
                .Build()
                .ToList();
        }
    }
}

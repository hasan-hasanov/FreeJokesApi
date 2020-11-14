using Core.Entities;
using System.Collections.Generic;

namespace Adapter.Database.Contexts.Seed
{
    public class CategorySeeds
    {
        public CategorySeeds()
        {
            Categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Airplane Jokes" },
                new Category() { Id = 2, Name = "Animal Jokes" },
                new Category() { Id = 3, Name = "Baby Jokes" },
                new Category() { Id = 4, Name = "Bar & Drinking Jokes" },
                new Category() { Id = 5, Name = "Business Jokes" },
                new Category() { Id = 6, Name = "College Jokes" },
                new Category() { Id = 7, Name = "Computer Jokes" },
                new Category() { Id = 8, Name = "Cross the Road Jokes" },
                new Category() { Id = 9, Name = "Dentist Jokes" },
                new Category() { Id = 10, Name = "Doctor Jokes" },
                new Category() { Id = 11, Name = "Dumb Criminals" },
                new Category() { Id = 12, Name = "Elderly Jokes" },
                new Category() { Id = 13, Name = "Entertainment Jokes" },
                new Category() { Id = 14, Name = "Family Jokes" },
                new Category() { Id = 15, Name = "Farmer Jokes" },
                new Category() { Id = 16, Name = "Food Jokes" },
                new Category() { Id = 17, Name = "Golf Jokes" },
                new Category() { Id = 18, Name = "Holiday Jokes" },
                new Category() { Id = 19, Name = "Judge Jokes" },
                new Category() { Id = 20, Name = "Kid Jokes" },
                new Category() { Id = 21, Name = "Knock Knock Jokes" },
                new Category() { Id = 22, Name = "Lawyer Jokes" },
                new Category() { Id = 23, Name = "Lightbulb Jokes" },
                new Category() { Id = 24, Name = "Little Johnny Jokes" },
                new Category() { Id = 25, Name = "Love Jokes" },
                new Category() { Id = 26, Name = "Marriage Jokes" },
                new Category() { Id = 27, Name = "Military Jokes" },
                new Category() { Id = 28, Name = "Misc Jokes" },
                new Category() { Id = 29, Name = "Money Jokes" },
                new Category() { Id = 30, Name = "Musician Jokes" },
                new Category() { Id = 31, Name = "National Jokes" },
                new Category() { Id = 32, Name = "News Jokes" },
                new Category() { Id = 33, Name = "Office Jokes" },
                new Category() { Id = 34, Name = "One Liner Jokes" },
                new Category() { Id = 35, Name = "Pickup Jokes" },
                new Category() { Id = 36, Name = "Police Jokes" },
                new Category() { Id = 37, Name = "Political Jokes" },
                new Category() { Id = 38, Name = "Pop Culture Jokes" },
                new Category() { Id = 39, Name = "Programmer Jokes" },
                new Category() { Id = 40, Name = "Puns" },
                new Category() { Id = 41, Name = "Relationship Jokes" },
                new Category() { Id = 42, Name = "Religious Jokes" },
                new Category() { Id = 43, Name = "Salespeople Jokes" },
                new Category() { Id = 44, Name = "School Jokes" },
                new Category() { Id = 45, Name = "Science Jokes" },
                new Category() { Id = 46, Name = "Scifi Jokes" },
                new Category() { Id = 47, Name = "Sport Jokes" },
                new Category() { Id = 48, Name = "Star Wars Jokes" },
                new Category() { Id = 49, Name = "Teacher Jokes" },
                new Category() { Id = 50, Name = "Technology Jokes" },
                new Category() { Id = 51, Name = "Word Play Jokes" },
                new Category() { Id = 52, Name = "Work Jokes" },
                new Category() { Id = 53, Name = "Yo Momma Jokes" },
            };
        }

        public List<Category> Categories { get; }
    }
}

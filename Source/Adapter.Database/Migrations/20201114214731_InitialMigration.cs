using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adapter.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jokes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jokes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jokes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JokeFlags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeId = table.Column<long>(type: "bigint", nullable: false),
                    FlagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JokeFlags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JokeFlags_Flags_FlagId",
                        column: x => x.FlagId,
                        principalTable: "Flags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JokeFlags_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    JokePart = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeRating = table.Column<float>(type: "real", nullable: false),
                    JokeId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Jokes_JokeId",
                        column: x => x.JokeId,
                        principalTable: "Jokes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Airplane Jokes" },
                    { 31L, "National Jokes" },
                    { 32L, "News Jokes" },
                    { 33L, "Office Jokes" },
                    { 34L, "One Liner Jokes" },
                    { 35L, "Pickup Jokes" },
                    { 36L, "Police Jokes" },
                    { 37L, "Political Jokes" },
                    { 38L, "Pop Culture Jokes" },
                    { 39L, "Programmer Jokes" },
                    { 40L, "Puns" },
                    { 41L, "Relationship Jokes" },
                    { 42L, "Religious Jokes" },
                    { 43L, "Salespeople Jokes" },
                    { 44L, "School Jokes" },
                    { 45L, "Science Jokes" },
                    { 46L, "Scifi Jokes" },
                    { 47L, "Sport Jokes" },
                    { 48L, "Star Wars Jokes" },
                    { 49L, "Teacher Jokes" },
                    { 50L, "Technology Jokes" },
                    { 51L, "Word Play Jokes" },
                    { 52L, "Work Jokes" },
                    { 53L, "Yo Momma Jokes" },
                    { 29L, "Money Jokes" },
                    { 28L, "Misc Jokes" },
                    { 30L, "Musician Jokes" },
                    { 26L, "Marriage Jokes" },
                    { 2L, "Animal Jokes" },
                    { 3L, "Baby Jokes" },
                    { 4L, "Bar & Drinking Jokes" },
                    { 5L, "Business Jokes" },
                    { 6L, "College Jokes" },
                    { 7L, "Computer Jokes" },
                    { 8L, "Cross the Road Jokes" },
                    { 9L, "Dentist Jokes" },
                    { 10L, "Doctor Jokes" },
                    { 11L, "Dumb Criminals" },
                    { 27L, "Military Jokes" },
                    { 13L, "Entertainment Jokes" },
                    { 12L, "Elderly Jokes" },
                    { 15L, "Farmer Jokes" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 25L, "Love Jokes" },
                    { 24L, "Little Johnny Jokes" },
                    { 14L, "Family Jokes" },
                    { 22L, "Lawyer Jokes" },
                    { 21L, "Knock Knock Jokes" },
                    { 23L, "Lightbulb Jokes" },
                    { 19L, "Judge Jokes" },
                    { 18L, "Holiday Jokes" },
                    { 17L, "Golf Jokes" },
                    { 16L, "Food Jokes" },
                    { 20L, "Kid Jokes" }
                });

            migrationBuilder.InsertData(
                table: "Flags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5L, "Sexist" },
                    { 1L, "NSFW" },
                    { 2L, "Religious" },
                    { 3L, "Political" },
                    { 4L, "Racist" },
                    { 6L, "Adult" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JokeFlags_FlagId",
                table: "JokeFlags",
                column: "FlagId");

            migrationBuilder.CreateIndex(
                name: "IX_JokeFlags_JokeId",
                table: "JokeFlags",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jokes_CategoryId",
                table: "Jokes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_JokeId",
                table: "Parts",
                column: "JokeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_JokeId",
                table: "Ratings",
                column: "JokeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JokeFlags");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropTable(
                name: "Jokes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

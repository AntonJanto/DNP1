using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    StreetName = table.Column<string>(nullable: false),
                    HouseNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => new { x.HouseNumber, x.StreetName });
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "Adults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adults_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Sex = table.Column<string>(nullable: true),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChildInterest",
                columns: table => new
                {
                    ChildId = table.Column<int>(nullable: false),
                    InterestId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildInterest", x => new { x.ChildId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_ChildInterest_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildInterest_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Species = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: true),
                    FamilyHouseNumber = table.Column<int>(nullable: true),
                    FamilyStreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_Families_FamilyHouseNumber_FamilyStreetName",
                        columns: x => new { x.FamilyHouseNumber, x.FamilyStreetName },
                        principalTable: "Families",
                        principalColumns: new[] { "HouseNumber", "StreetName" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adults_FamilyHouseNumber_FamilyStreetName",
                table: "Adults",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });

            migrationBuilder.CreateIndex(
                name: "IX_ChildInterest_InterestId",
                table: "ChildInterest",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_FamilyHouseNumber_FamilyStreetName",
                table: "Children",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ChildId",
                table: "Pets",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_FamilyHouseNumber_FamilyStreetName",
                table: "Pets",
                columns: new[] { "FamilyHouseNumber", "FamilyStreetName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adults");

            migrationBuilder.DropTable(
                name: "ChildInterest");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TodosWebAPI.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 1, false, "diam. Aliquam id tortor eget ante aliquet commodo non", 7 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 2, true, "ornare, leo ac imperdiet malesuada, nisl quam dapibus", 4 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 3, false, "eget ante aliquet commodo non a nulla.", 6 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 4, true, "Nulla nec lacus nibh. Quisque bibendum", 7 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 5, true, "potenti.Proin commodo felis tempor, maximus sem", 9 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 6, false, "tortor quis bibendum blandit. Sed", 8 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 7, false, "neque vulputate at. Aliquam luctus dictum", 7 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 8, true, "et, ultricies ipsum. Proin rhoncus congue nisi, eu interdum", 3 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 9, false, "dictum enim quis pharetra consequat. Sed tempus", 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 10, false, "sollicitudin lacus ac ultricies viverra.", 5 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 11, false, "eu neque condimentum, eleifend mollis", 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 12, true, "dapibus lectus, venenatis congue urna. Praesent egestas", 3 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 13, false, "maximus urna, at sagittis odio. Ut auctor urna ac", 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 14, false, "a tellus ultrices, consequat dui et,", 8 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "IsCompleted", "Title", "UserID" },
                values: new object[] { 15, true, "libero vitae aliquet. Nulla eu", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "TodoID",
                keyValue: 15);
        }
    }
}

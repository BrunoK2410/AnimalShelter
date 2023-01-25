using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class addRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bc78a633-4752-4a82-bad2-cc97e8be5599");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa020e44-cb5c-4746-95bc-cffc3d3c566f", "admin@gmail.com", true, "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBdFuqjxrrAqgyAnzkqyrZaTT+osGZhnhn0y806bSveJqr98r9QcLFOZPL7A6dgskg==", "c0d1b865-4c9d-48a9-9c16-6c10188a88e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6a30b890-d5e2-4b14-a9ce-8e7919ff3e94");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "433a08f4-9e93-4abd-b020-0157f214ad55", null, false, null, "AQAAAAEAACcQAAAAEDWsHVD0l7NEO7hdiwTQq73yAYrq2ueLBrJgI+Tf5N/OaOYY0KCaFgxuF+Cvpq6QFQ==", "fcce5163-16f3-45d3-a694-211be5985c7d" });
        }
    }
}

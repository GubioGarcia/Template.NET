using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("09ac9fd2-5b00-4d22-8884-4d988a04182b"), "userdefault@template.com", "User Default" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09ac9fd2-5b00-4d22-8884-4d988a04182b"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoAPI.Migrations
{
    public partial class AddUserApiKeysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserApiKeys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    UserID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApiKeys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserApiKeys_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 28, 11, 58, 0, 682, DateTimeKind.Utc).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 28, 11, 58, 0, 682, DateTimeKind.Utc).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 28, 11, 58, 0, 682, DateTimeKind.Utc).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 28, 11, 58, 0, 682, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 28, 11, 58, 0, 682, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_UserID",
                table: "UserApiKeys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_Value",
                table: "UserApiKeys",
                column: "Value",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserApiKeys");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 2, 1, 54, 823, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 2, 1, 54, 823, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 2, 1, 54, 823, DateTimeKind.Utc).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 2, 1, 54, 823, DateTimeKind.Utc).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 27, 2, 1, 54, 823, DateTimeKind.Utc).AddTicks(8988));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInfoAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MatricNumber = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student_Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Course_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Course_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DateAdded", "Name" },
                values: new object[] { 1, new DateTime(2022, 10, 25, 1, 16, 23, 243, DateTimeKind.Utc).AddTicks(1972), "Chemistry" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DateAdded", "Name" },
                values: new object[] { 2, new DateTime(2022, 10, 25, 1, 16, 23, 243, DateTimeKind.Utc).AddTicks(1977), "Physics" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateAdded", "MatricNumber", "Name" },
                values: new object[] { 1, new DateTime(2022, 10, 25, 1, 16, 23, 243, DateTimeKind.Utc).AddTicks(2163), "2017/345", "Zadok Joshua" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateAdded", "MatricNumber", "Name" },
                values: new object[] { 2, new DateTime(2022, 10, 25, 1, 16, 23, 243, DateTimeKind.Utc).AddTicks(2166), "2017/343", "Trinity Ikpe" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateAdded", "MatricNumber", "Name" },
                values: new object[] { 3, new DateTime(2022, 10, 25, 1, 16, 23, 243, DateTimeKind.Utc).AddTicks(2168), "2017/343", "James Sam" });

            migrationBuilder.InsertData(
                table: "Student_Course",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Student_Course",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[] { 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Student_Course",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.InsertData(
                table: "Student_Course",
                columns: new[] { "Id", "CourseId", "StudentId" },
                values: new object[] { 4, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_CourseId",
                table: "Student_Course",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Course_StudentId",
                table: "Student_Course",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Course");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

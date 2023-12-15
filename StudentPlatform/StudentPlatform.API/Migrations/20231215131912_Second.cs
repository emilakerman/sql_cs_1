using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPlatform.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                table: "CourseStudent",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentsId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Students_StudentId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseStudent",
                newName: "StudentsId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudent_StudentId",
                table: "CourseStudent",
                newName: "IX_CourseStudent_StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Students_StudentsId",
                table: "CourseStudent",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

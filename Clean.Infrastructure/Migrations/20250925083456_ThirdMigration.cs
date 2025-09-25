using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_classrooms_AttendanceId",
                table: "attendance");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "attendance");

            migrationBuilder.AlterColumn<string>(
                name: "ClassroomId",
                table: "attendance",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "LessonId",
                table: "attendance",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<string>(type: "text", nullable: false),
                    TimetableId = table.Column<string>(type: "text", nullable: false),
                    LessonDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClassroomId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "classrooms",
                        principalColumn: "ClassroomId");
                    table.ForeignKey(
                        name: "FK_Lessons_timetables_TimetableId",
                        column: x => x.TimetableId,
                        principalTable: "timetables",
                        principalColumn: "TimetableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendance_ClassroomId",
                table: "attendance",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_attendance_LessonId",
                table: "attendance",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassroomId",
                table: "Lessons",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TimetableId",
                table: "Lessons",
                column: "TimetableId");

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_Lessons_LessonId",
                table: "attendance",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_classrooms_ClassroomId",
                table: "attendance",
                column: "ClassroomId",
                principalTable: "classrooms",
                principalColumn: "ClassroomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_attendance_Lessons_LessonId",
                table: "attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_attendance_classrooms_ClassroomId",
                table: "attendance");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_attendance_ClassroomId",
                table: "attendance");

            migrationBuilder.DropIndex(
                name: "IX_attendance_LessonId",
                table: "attendance");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "attendance");

            migrationBuilder.AlterColumn<string>(
                name: "ClassroomId",
                table: "attendance",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "attendance",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_attendance_classrooms_AttendanceId",
                table: "attendance",
                column: "AttendanceId",
                principalTable: "classrooms",
                principalColumn: "ClassroomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

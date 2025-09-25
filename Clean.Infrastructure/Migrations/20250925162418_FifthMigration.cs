using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupMember_StudentGroup_GroupId",
                table: "StudentGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupMember_students_StudentId",
                table: "StudentGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_StudentGroup_StudentGroupId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroupMember",
                table: "StudentGroupMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup");

            migrationBuilder.RenameTable(
                name: "StudentGroupMember",
                newName: "StudentGroupMembers");

            migrationBuilder.RenameTable(
                name: "StudentGroup",
                newName: "StudentGroups");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroupMember_GroupId",
                table: "StudentGroupMembers",
                newName: "IX_StudentGroupMembers_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroupMembers",
                table: "StudentGroupMembers",
                columns: new[] { "StudentId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupMembers_StudentGroups_GroupId",
                table: "StudentGroupMembers",
                column: "GroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupMembers_students_StudentId",
                table: "StudentGroupMembers",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_StudentGroups_StudentGroupId",
                table: "timetables",
                column: "StudentGroupId",
                principalTable: "StudentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupMembers_StudentGroups_GroupId",
                table: "StudentGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupMembers_students_StudentId",
                table: "StudentGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_timetables_StudentGroups_StudentGroupId",
                table: "timetables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroups",
                table: "StudentGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentGroupMembers",
                table: "StudentGroupMembers");

            migrationBuilder.RenameTable(
                name: "StudentGroups",
                newName: "StudentGroup");

            migrationBuilder.RenameTable(
                name: "StudentGroupMembers",
                newName: "StudentGroupMember");

            migrationBuilder.RenameIndex(
                name: "IX_StudentGroupMembers_GroupId",
                table: "StudentGroupMember",
                newName: "IX_StudentGroupMember_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroup",
                table: "StudentGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentGroupMember",
                table: "StudentGroupMember",
                columns: new[] { "StudentId", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupMember_StudentGroup_GroupId",
                table: "StudentGroupMember",
                column: "GroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupMember_students_StudentId",
                table: "StudentGroupMember",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_timetables_StudentGroup_StudentGroupId",
                table: "timetables",
                column: "StudentGroupId",
                principalTable: "StudentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

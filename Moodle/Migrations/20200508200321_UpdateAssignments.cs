using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moodle.Migrations
{
    public partial class UpdateAssignments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"),
                column: "CourseId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"),
                column: "CourseId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"),
                column: "CourseId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"),
                column: "CourseId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}

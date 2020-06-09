using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moodle.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "SubmissionId",
                keyValue: new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"));

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "SubmissionId",
                keyValue: new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"));

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "CourseId", "Description" },
                values: new object[] { new Guid("87a56797-c2f3-47cb-aa17-f940a61f5ae7"), "Project setup", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "create a  new web API project and configure it to the project" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "CourseId", "Description" },
                values: new object[] { new Guid("3d7ebe4b-d62f-4d09-b37c-9081609dc025"), "Configuring a logging service", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "add a logging service to the project" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "CourseId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "Score", "SectionId", "Submission_Comment", "UserId" },
                values: new object[] { new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"), new Guid("87a56797-c2f3-47cb-aa17-f940a61f5ae7"), "3.0", new Guid("7cf612a1-824c-46cd-9067-77f74489216b"), "you did good on the assignment", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "Score", "SectionId", "Submission_Comment", "UserId" },
                values: new object[] { new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"), new Guid("3d7ebe4b-d62f-4d09-b37c-9081609dc025"), "1.0", new Guid("7cf612a1-824c-46cd-9067-77f74489216b"), "you did not complete the assignment", new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "SubmissionId",
                keyValue: new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"));

            migrationBuilder.DeleteData(
                table: "Submissions",
                keyColumn: "SubmissionId",
                keyValue: new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("3d7ebe4b-d62f-4d09-b37c-9081609dc025"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: new Guid("87a56797-c2f3-47cb-aa17-f940a61f5ae7"));

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "CourseId", "Description" },
                values: new object[] { new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"), "Project setup", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "create a  new web API project and configure it to the project" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "CourseId", "Description" },
                values: new object[] { new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"), "Configuring a logging service", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "add a logging service to the project" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionId",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "CourseId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "Score", "SectionId", "Submission_Comment", "UserId" },
                values: new object[] { new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"), new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"), "3.0", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "you did good on the assignment", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "Score", "SectionId", "Submission_Comment", "UserId" },
                values: new object[] { new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"), new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"), "1.0", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "you did not complete the assignment", new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });
        }
    }
}

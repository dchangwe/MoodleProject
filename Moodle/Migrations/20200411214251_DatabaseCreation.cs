using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Moodle.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(nullable: false),
                    CourseName = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<Guid>(nullable: false),
                    AssignmentName = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    SubmissionId = table.Column<Guid>(nullable: false),
                    Score = table.Column<string>(nullable: false),
                    Submission_Comment = table.Column<string>(maxLength: 60, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    AssignmentId = table.Column<Guid>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_Submissions_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId");
                        //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description" },
                values: new object[,]
                {
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "WebAPI and Intermediate C#", "This course teaches students to develop RESTful Web Service API using C# .Net Core" },
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Introduction to C#", "learning object oriented programming" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "danachangwe@gmail.com", "Dana", "Changwe", "263vvqh" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "pharris@gmail.com", "Patrick", "Harris", "36yqnsuw" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "CourseId", "Description" },
                values: new object[,]
                {
                    { new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"), "Project setup", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "create a  new web API project and configure it to the project" },
                    { new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"), "Configuring a logging service", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "add a logging service to the project" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "CourseId", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "12/05/2020", "03/04/2020" },
                    { new Guid("7cf612a1-824c-46cd-9067-77f74489216b"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "25/06/2020", "25/05/2020" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "SectionId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c4c987d5-4254-47da-9f55-3da2f6d7f078"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("e2708e39-c561-4708-9167-48579b3cd0ff"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "SubmissionId", "AssignmentId", "Score", "SectionId", "Submission_Comment", "UserId" },
                values: new object[,]
                {
                    { new Guid("f069b2ff-c17e-404c-ae78-bd9cfec1adf2"), new Guid("77a56797-c2f3-47cb-aa17-f940a61f5ae7"), "3.0", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "you did good on the assignment", new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("23f77b75-70be-4059-a6a7-62b5f522ef9e"), new Guid("2d7ebe4b-d62f-4d09-b37c-9081609dc025"), "1.0", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "you did not complete the assignment", new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SectionId",
                table: "Enrollments",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_AssignmentId",
                table: "Submissions",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_SectionId",
                table: "Submissions",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}

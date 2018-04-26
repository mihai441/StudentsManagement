using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentsManagement.Persistence.EF.Migrations
{
    public partial class changedstudentactivityrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Students_StudentId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_StudentId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "StudentActivityDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentActivityDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentActivityDetails_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentActivityDetails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityDetails_ActivityId",
                table: "StudentActivityDetails",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityDetails_StudentId",
                table: "StudentActivityDetails",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentActivityDetails");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Activities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_StudentId",
                table: "Activities",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Students_StudentId",
                table: "Activities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

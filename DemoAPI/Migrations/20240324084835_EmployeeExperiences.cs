using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeExperiences",
                columns: table => new
                {
                    EmployeeExperiendId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Position = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Salary = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DateJoin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DateResign = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExperiences", x => x.EmployeeExperiendId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeExperiences");
        }
    }
}

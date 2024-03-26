using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Employees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    EmployeeNameKh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmployeeNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PositionId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DepartmentId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    VillageId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DepartmentNameKh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DepartmentNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsActive = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LastUpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    lastUpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}

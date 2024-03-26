using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeEducations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeEductions",
                columns: table => new
                {
                    EmployeeEducationId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EmployeeId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EducationLevel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Majo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SchoolName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    YearStart = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    YearEnd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEductions", x => x.EmployeeEducationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeEductions");
        }
    }
}

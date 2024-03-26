using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Postions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PositionNameKh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PositionNameEn = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsAvtive = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LastUpdateBy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}

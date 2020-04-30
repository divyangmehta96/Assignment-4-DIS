using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IEXTrading.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    UId = table.Column<Guid>(nullable: false),
                    age = table.Column<string>(nullable: true),
                    cod = table.Column<string>(nullable: true),
                    descriptionofinjury = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    race = table.Column<string>(nullable: true),
                    sex = table.Column<string>(nullable: true),
                    times = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equities",
                columns: table => new
                {
                    EquityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecUId = table.Column<Guid>(nullable: true),
                    change = table.Column<float>(nullable: false),
                    changeOverTime = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    high = table.Column<float>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    low = table.Column<float>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    symbol = table.Column<string>(nullable: true),
                    unadjustedVolume = table.Column<int>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    vwap = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equities", x => x.EquityId);
                    table.ForeignKey(
                        name: "FK_Equities_Companies_RecUId",
                        column: x => x.RecUId,
                        principalTable: "Companies",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equities_RecUId",
                table: "Equities",
                column: "RecUId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Equities");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "Catagory_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "Event_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SubCatagory_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Catagory",
                columns: table => new
                {
                    CatagoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagory", x => x.CatagoryID);
                });

            migrationBuilder.CreateTable(
                name: "SubCatagory",
                columns: table => new
                {
                    SubCatagoryID = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCatagory", x => x.SubCatagoryID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Fee = table.Column<decimal>(nullable: false),
                    EventStartDate = table.Column<string>(nullable: false),
                    EventEndDate = table.Column<string>(nullable: false),
                    EventStartTime = table.Column<string>(nullable: false),
                    EventEndTime = table.Column<string>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    EventImageUrl = table.Column<string>(nullable: true),
                    Created = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    EventCategoryId = table.Column<int>(nullable: false),
                    EventSubCatagoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Catagory_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "Catagory",
                        principalColumn: "CatagoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_SubCatagory_EventSubCatagoryId",
                        column: x => x.EventSubCatagoryId,
                        principalTable: "SubCatagory",
                        principalColumn: "SubCatagoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventCategoryId",
                table: "Event",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventSubCatagoryId",
                table: "Event",
                column: "EventSubCatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Catagory");

            migrationBuilder.DropTable(
                name: "SubCatagory");

            migrationBuilder.DropSequence(
                name: "Catagory_hilo");

            migrationBuilder.DropSequence(
                name: "Event_hilo");

            migrationBuilder.DropSequence(
                name: "SubCatagory_hilo");
        }
    }
}

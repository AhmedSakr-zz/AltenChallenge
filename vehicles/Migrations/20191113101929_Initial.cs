using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vehicles.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    DeletedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    DeletedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<string>(maxLength: 17, nullable: true),
                    RegNo = table.Column<string>(maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarStatusTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    UpdatedById = table.Column<int>(nullable: true),
                    DeletedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    CarId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarStatusTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarStatusTransactions_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarStatusTransactions_CarStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "CarStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Connected" },
                    { 2, "DisConnected" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "FullName", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cementvägen 8, 111 11 Södertälje", -1, new DateTime(2019, 11, 13, 12, 19, 28, 892, DateTimeKind.Local).AddTicks(9203), null, null, "Kalles Grustransporter AB", null, null },
                    { 2, "Balkvägen 12, 222 22 Stockholm", -1, new DateTime(2019, 11, 13, 12, 19, 28, 893, DateTimeKind.Local).AddTicks(9692), null, null, "Johans Bulk AB", null, null },
                    { 3, "Budgetvägen 1, 333 33 Uppsala", -1, new DateTime(2019, 11, 13, 12, 19, 28, 893, DateTimeKind.Local).AddTicks(9700), null, null, "Haralds Värdetransporter AB", null, null }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "CustomerId", "DeletedById", "DeletedDate", "RegNo", "UpdatedById", "UpdatedDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3262), 1, null, null, "ABC123", null, null, "YS2R4X20005399401" },
                    { 2, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3300), 1, null, null, "DEF456", null, null, "VLUR4X20009093588" },
                    { 3, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3304), 1, null, null, "GHI789", null, null, "VLUR4X20009048066" },
                    { 4, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3305), 2, null, null, "JKL012", null, null, "YS2R4X20005388011" },
                    { 5, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3307), 2, null, null, "MNO345", null, null, "YS2R4X20005387949" },
                    { 6, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3312), 3, null, null, "PQR678", null, null, "VLUR4X20009048066" },
                    { 7, -1, new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3313), 3, null, null, "STU901", null, null, "YS2R4X20005387055" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarStatusTransactions_CarId",
                table: "CarStatusTransactions",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarStatusTransactions_StatusId",
                table: "CarStatusTransactions",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarStatusTransactions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarStatuses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

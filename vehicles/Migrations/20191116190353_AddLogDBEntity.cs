using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vehicles.Migrations
{
    public partial class AddLogDBEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LogType = table.Column<string>(nullable: true),
                    LogMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDatas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8777));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8781));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 404, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 401, DateTimeKind.Local).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 402, DateTimeKind.Local).AddTicks(9689));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 16, 21, 3, 53, 402, DateTimeKind.Local).AddTicks(9699));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogDatas");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5165));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5170));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 557, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 561, DateTimeKind.Local).AddTicks(7806));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 16, 0, 46, 561, DateTimeKind.Local).AddTicks(7839));
        }
    }
}

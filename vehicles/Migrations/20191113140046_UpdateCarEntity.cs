using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vehicles.Migrations
{
    public partial class UpdateCarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStatusId",
                table: "Cars",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5107), 1 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5165), 1 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5169), 2 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5170), 1 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5175), 1 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5182), 1 });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "CurrentStatusId" },
                values: new object[] { new DateTime(2019, 11, 13, 16, 0, 46, 564, DateTimeKind.Local).AddTicks(5184), 2 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrentStatusId",
                table: "Cars",
                column: "CurrentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarStatuses_CurrentStatusId",
                table: "Cars",
                column: "CurrentStatusId",
                principalTable: "CarStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarStatuses_CurrentStatusId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrentStatusId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CurrentStatusId",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3262));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3307));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3312));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 895, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 892, DateTimeKind.Local).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 893, DateTimeKind.Local).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 11, 13, 12, 19, 28, 893, DateTimeKind.Local).AddTicks(9700));
        }
    }
}

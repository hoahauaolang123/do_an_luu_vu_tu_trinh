using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chats_AspNetUsers_receiverId",
                table: "chats");

            migrationBuilder.DropForeignKey(
                name: "FK_chats_AspNetUsers_senderId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_receiverId",
                table: "chats");

            migrationBuilder.DropIndex(
                name: "IX_chats_senderId",
                table: "chats");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("078269d8-1a12-4592-b92e-7ff1a876a5f2"),
                column: "ConcurrencyStamp",
                value: "b034a582-dce5-4d6e-9784-a82788066171");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d9186ba-2cd6-4b6c-b729-4e605de1019f"),
                column: "ConcurrencyStamp",
                value: "cd6bc0b1-1240-4ea8-af49-a7ad78a256ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4557893f-1f56-4b6f-bb3b-caefd62c8c49"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1960103-7aa7-4d6c-b5c0-25581605a93f", "AQAAAAEAACcQAAAAEA1Pju3U1m0k5tjLb2dbqVrjRcT0gSx4LGHn0wA1VWSyCUpq8ziW2w/RFJVUoHAB4Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("078269d8-1a12-4592-b92e-7ff1a876a5f2"),
                column: "ConcurrencyStamp",
                value: "943356e1-3acd-4cd3-8bb0-9db6e3342d15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d9186ba-2cd6-4b6c-b729-4e605de1019f"),
                column: "ConcurrencyStamp",
                value: "d8eea28a-90f7-425f-9745-2ed952a3c4a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4557893f-1f56-4b6f-bb3b-caefd62c8c49"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9535bc4-932c-4d4c-8e50-d7a9cb3468f3", "AQAAAAEAACcQAAAAENxOAUED25p7X3sUHCmr66PtTEHVkLdizpMfpBDtmbOpHENeBYyneF5xPWETjyKP0w==" });

            migrationBuilder.CreateIndex(
                name: "IX_chats_receiverId",
                table: "chats",
                column: "receiverId");

            migrationBuilder.CreateIndex(
                name: "IX_chats_senderId",
                table: "chats",
                column: "senderId");

            migrationBuilder.AddForeignKey(
                name: "FK_chats_AspNetUsers_receiverId",
                table: "chats",
                column: "receiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chats_AspNetUsers_senderId",
                table: "chats",
                column: "senderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

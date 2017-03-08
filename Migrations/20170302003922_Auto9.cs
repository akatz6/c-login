using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace craigslist.Migrations
{
    public partial class Auto9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoId",
                table: "AutoTalk",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AutoTalk_AutoId",
                table: "AutoTalk",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoTalk_UserId",
                table: "AutoTalk",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoTalk_Auto_AutoId",
                table: "AutoTalk",
                column: "AutoId",
                principalTable: "Auto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoTalk_User_UserId",
                table: "AutoTalk",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoTalk_Auto_AutoId",
                table: "AutoTalk");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoTalk_User_UserId",
                table: "AutoTalk");

            migrationBuilder.DropIndex(
                name: "IX_AutoTalk_AutoId",
                table: "AutoTalk");

            migrationBuilder.DropIndex(
                name: "IX_AutoTalk_UserId",
                table: "AutoTalk");

            migrationBuilder.DropColumn(
                name: "AutoId",
                table: "AutoTalk");
        }
    }
}

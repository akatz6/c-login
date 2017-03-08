using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace craigslist.Migrations
{
    public partial class jobTalk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTalk_Auto_JobId",
                table: "JobTalk");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTalk_Job_JobId",
                table: "JobTalk",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTalk_Job_JobId",
                table: "JobTalk");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTalk_Auto_JobId",
                table: "JobTalk",
                column: "JobId",
                principalTable: "Auto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

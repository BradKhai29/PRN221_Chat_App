using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class M1UpdateUserTokensandAccountStatusenumsvalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredAt",
                table: "UserTokens",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountStatuses",
                keyColumn: "Id",
                keyValue: new Guid("cc751bfc-77b9-4a97-85d4-c88e1f3db4de"),
                column: "Name",
                value: "EmailConfirmed");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AccessTokenId",
                table: "RefreshTokens",
                column: "AccessTokenId",
                unique: true)
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Value",
                table: "RefreshTokens",
                column: "Value",
                unique: true)
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_AccessTokenId",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_Value",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "ExpiredAt",
                table: "UserTokens");

            migrationBuilder.UpdateData(
                table: "AccountStatuses",
                keyColumn: "Id",
                keyValue: new Guid("cc751bfc-77b9-4a97-85d4-c88e1f3db4de"),
                column: "Name",
                value: "Registered");
        }
    }
}

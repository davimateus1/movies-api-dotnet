﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaters_Addresses_AddressId",
                table: "MovieTheaters",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

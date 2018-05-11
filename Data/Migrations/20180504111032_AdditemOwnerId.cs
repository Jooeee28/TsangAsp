using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AspNetCoreToDo.Data.Migrations
{
    public partial class AdditemOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
             //   name: "PK_Items",
            //    table: "Items");

          //  migrationBuilder.RenameTable(
          //      name: "Items",
          //      newName: "items");

            migrationBuilder.AddColumn<string>(
                name: "OwnderId",
                table: "items",
                nullable: true);

           //migrationBuilder.AddPrimaryKey(
            //    name: "PK_items",
            //    table: "items",
            //    column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DropPrimaryKey(
           //     name: "PK_items",
            //    table: "items");

            migrationBuilder.DropColumn(
                name: "OwnderId",
                table: "items");

           // migrationBuilder.RenameTable(
           //     name: "items",
           //     newName: "Items");

           // migrationBuilder.AddPrimaryKey(
           //     name: "PK_Items",
           //     table: "Items",
           //     column: "ID");
        }
    }
}

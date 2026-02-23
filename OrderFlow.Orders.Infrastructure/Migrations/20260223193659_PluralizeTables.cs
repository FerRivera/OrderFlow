using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow.Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PluralizeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_outbox_message",
                table: "outbox_message");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order",
                table: "order");

            migrationBuilder.RenameTable(
                name: "outbox_message",
                newName: "outbox_messages");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.AddPrimaryKey(
                name: "pk_outbox_messages",
                table: "outbox_messages",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                table: "orders",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_outbox_messages",
                table: "outbox_messages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "outbox_messages",
                newName: "outbox_message");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.AddPrimaryKey(
                name: "pk_outbox_message",
                table: "outbox_message",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order",
                table: "order",
                column: "id");
        }
    }
}

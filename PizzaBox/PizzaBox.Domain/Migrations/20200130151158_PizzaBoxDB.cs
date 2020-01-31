using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Domain.Migrations
{
    public partial class PizzaBoxDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PizzaBox");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Cheese",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheese", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Crust",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    username = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    password = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    crustid = table.Column<int>(name: "crust id", nullable: true),
                    cheeseid = table.Column<int>(name: "cheese id", nullable: true),
                    sauceid = table.Column<int>(name: "sauce id", nullable: true),
                    sizeid = table.Column<int>(name: "size id", nullable: true),
                    toppingid = table.Column<int>(name: "topping id", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.id);
                    table.ForeignKey(
                        name: "FK__Pizzas__cheese_id",
                        column: x => x.cheeseid,
                        principalSchema: "PizzaBox",
                        principalTable: "Cheese",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pizzas__crust_id",
                        column: x => x.crustid,
                        principalSchema: "PizzaBox",
                        principalTable: "Crust",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pizzas__sauce_id",
                        column: x => x.sauceid,
                        principalSchema: "PizzaBox",
                        principalTable: "Sauces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pizzas__size_id",
                        column: x => x.sizeid,
                        principalSchema: "PizzaBox",
                        principalTable: "Sizes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Pizzas__topping",
                        column: x => x.toppingid,
                        principalSchema: "PizzaBox",
                        principalTable: "Toppings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.id);
                    table.ForeignKey(
                        name: "FK_Stores_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stores_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "PizzaBox",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "PizzaBox",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: false),
                    store_id = table.Column<int>(nullable: false),
                    totalprice = table.Column<decimal>(name: "total price", type: "decimal(18, 0)", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK__Orders__store_id",
                        column: x => x.store_id,
                        principalSchema: "PizzaBox",
                        principalTable: "Stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Orders__user_id",
                        column: x => x.user_id,
                        principalSchema: "PizzaBox",
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "PizzaBox",
                columns: table => new
                {
                    storeid = table.Column<int>(name: "store id", nullable: false),
                    pizzaid = table.Column<int>(name: "pizza id", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Store_Piz", x => new { x.storeid, x.pizzaid });
                    table.ForeignKey(
                        name: "FK__Store_Piz",
                        column: x => x.pizzaid,
                        principalSchema: "PizzaBox",
                        principalTable: "Pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Store_Piz__store",
                        column: x => x.storeid,
                        principalSchema: "PizzaBox",
                        principalTable: "Stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Pizzas",
                schema: "PizzaBox",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    pizza_id = table.Column<int>(nullable: false),
                    OrderPizzaId = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_Piz", x => new { x.order_id, x.pizza_id });
                    table.ForeignKey(
                        name: "FK__Order_Piz__order",
                        column: x => x.order_id,
                        principalSchema: "PizzaBox",
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Order_Piz__pizza",
                        column: x => x.pizza_id,
                        principalSchema: "PizzaBox",
                        principalTable: "Pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Cheeses",
                schema: "PizzaBox",
                table: "Cheese",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Crusts",
                schema: "PizzaBox",
                table: "Crust",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Pizzas_pizza_id",
                schema: "PizzaBox",
                table: "Order_Pizzas",
                column: "pizza_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_store_id",
                schema: "PizzaBox",
                table: "Orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_user_id",
                schema: "PizzaBox",
                table: "Orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_cheese id",
                schema: "PizzaBox",
                table: "Pizzas",
                column: "cheese id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_crust id",
                schema: "PizzaBox",
                table: "Pizzas",
                column: "crust id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_sauce id",
                schema: "PizzaBox",
                table: "Pizzas",
                column: "sauce id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_size id",
                schema: "PizzaBox",
                table: "Pizzas",
                column: "size id");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_topping id",
                schema: "PizzaBox",
                table: "Pizzas",
                column: "topping id");

            migrationBuilder.CreateIndex(
                name: "UQ__Sauces",
                schema: "PizzaBox",
                table: "Sauces",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Sizes",
                schema: "PizzaBox",
                table: "Sizes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_pizza id",
                schema: "PizzaBox",
                table: "Store",
                column: "pizza id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AddressId",
                schema: "PizzaBox",
                table: "Stores",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UQ__Stores",
                schema: "PizzaBox",
                table: "Stores",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                schema: "PizzaBox",
                table: "Stores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "UQ__Toppings",
                schema: "PizzaBox",
                table: "Toppings",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                schema: "PizzaBox",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users",
                schema: "PizzaBox",
                table: "Users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Pizzas",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Pizzas",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Cheese",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Crust",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Sauces",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Sizes",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Toppings",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "PizzaBox");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

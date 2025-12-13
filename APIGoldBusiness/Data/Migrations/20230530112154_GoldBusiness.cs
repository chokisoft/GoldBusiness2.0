using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldBusiness.Data.Migrations
{
    /// <inheritdoc />
    public partial class GoldBusiness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Acceso_1",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acceso_2",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acceso_3",
                table: "AspNetUsers",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ChangePassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsernameChangeLimit",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: true),
                    BicoSwift = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(4,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Direccion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Web = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Telefono1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteTemporal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTransaccion = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Transaccion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Cuenta = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Inventario = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Debito = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credito = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteTemporal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdTurno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Cajero = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    Fondo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Extraccion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cierre = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdTurno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: true),
                    BicoSwift = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Iva = table.Column<decimal>(type: "decimal(4,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Direccion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Web = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    email2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Telefono1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGrupoCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    GrupoCuenta = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Deudora = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGrupoCuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGrupoCuenta_GrupoCuenta",
                        column: x => x.GrupoCuenta,
                        principalTable: "GrupoCuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CajaRegistradora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTurno = table.Column<int>(type: "int", nullable: false),
                    Mesa = table.Column<int>(type: "int", nullable: true),
                    Cerrado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaRegistradora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CajaRegistradora_IdTurno",
                        column: x => x.IdTurno,
                        principalTable: "IdTurno",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubLinea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Linea = table.Column<int>(type: "int", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubLinea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubLinea_Linea",
                        column: x => x.Linea,
                        principalTable: "Linea",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    SubGrupoCuenta = table.Column<int>(type: "int", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuenta_SubGrupoCuenta",
                        column: x => x.SubGrupoCuenta,
                        principalTable: "SubGrupoCuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CajaRegistradoraDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CajaRegistradora = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Venta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImporteVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CajaRegistradoraDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CajaRegistradoraDetalle_CajaRegistradora",
                        column: x => x.CajaRegistradora,
                        principalTable: "CajaRegistradora",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoComprobante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Cuenta = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Debito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Automatico = table.Column<bool>(type: "bit", nullable: false),
                    Posteado = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprobante_Cuenta",
                        column: x => x.Cuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConceptoAjuste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Cuenta = table.Column<int>(type: "int", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptoAjuste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptoAjuste_Cuenta",
                        column: x => x.Cuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoSistema = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Licencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreNegocio = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Web = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CuentaPagar = table.Column<int>(type: "int", nullable: false),
                    CuentaCobrar = table.Column<int>(type: "int", nullable: false),
                    Caducidad = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionCobrar_Cuenta",
                        column: x => x.CuentaCobrar,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConfiguracionPagar_Cuenta",
                        column: x => x.CuentaPagar,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperacionesEncabezado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaccion = table.Column<int>(type: "int", nullable: false),
                    NoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: true),
                    Cliente = table.Column<int>(type: "int", nullable: true),
                    NoPrimario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Referencia = table.Column<int>(type: "int", nullable: true),
                    ConceptoAjuste = table.Column<int>(type: "int", nullable: true),
                    Concepto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efectivo = table.Column<bool>(type: "bit", nullable: false),
                    Contabilizada = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesEncabezado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesEncabezado_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperacionesEncabezado_ConceptoAjuste",
                        column: x => x.ConceptoAjuste,
                        principalTable: "ConceptoAjuste",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperacionesEncabezado_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperacionesEncabezado_Transaccion",
                        column: x => x.Transaccion,
                        principalTable: "Transaccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Establecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Negocio = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establecimiento_Configuracion",
                        column: x => x.Negocio,
                        principalTable: "Configuracion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstadoCuenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Establecimiento = table.Column<int>(type: "int", nullable: false),
                    Cuenta = table.Column<int>(type: "int", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCuenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstadoCuenta_Cuenta",
                        column: x => x.Cuenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EstadoCuenta_Establecimiento",
                        column: x => x.Establecimiento,
                        principalTable: "Establecimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Establecimiento = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Almacen = table.Column<bool>(type: "bit", nullable: false),
                    CuentaInventario = table.Column<int>(type: "int", nullable: false),
                    CuentaCosto = table.Column<int>(type: "int", nullable: false),
                    CuentaVenta = table.Column<int>(type: "int", nullable: false),
                    CuentaDevolucion = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidad_CuentaCosto",
                        column: x => x.CuentaCosto,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Localidad_CuentaDevolucion",
                        column: x => x.CuentaDevolucion,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Localidad_CuentaInventario",
                        column: x => x.CuentaInventario,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Localidad_CuentaVenta",
                        column: x => x.CuentaVenta,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Localidad_Establecimiento",
                        column: x => x.Establecimiento,
                        principalTable: "Establecimiento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Establecimiento = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UnidadMedida = table.Column<int>(type: "int", nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Iva = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValueSql: "((0.00))"),
                    CodigoReferencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StockMinimo = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Servicio = table.Column<bool>(type: "bit", nullable: false),
                    SubLinea = table.Column<int>(type: "int", nullable: false),
                    Imagen = table.Column<byte[]>(type: "image", nullable: true),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Establecimiento",
                        column: x => x.Establecimiento,
                        principalTable: "Establecimiento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_SubLinea",
                        column: x => x.SubLinea,
                        principalTable: "SubLinea",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Producto_UnidadMedida",
                        column: x => x.UnidadMedida,
                        principalTable: "UnidadMedida",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CuentaCobrarPagar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Transaccion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Proveedor = table.Column<int>(type: "int", nullable: true),
                    Cliente = table.Column<int>(type: "int", nullable: true),
                    NoPrimario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CuentaPago = table.Column<int>(type: "int", nullable: true),
                    CuentaCobro = table.Column<int>(type: "int", nullable: true),
                    Localidad = table.Column<int>(type: "int", nullable: true),
                    Contabilizada = table.Column<bool>(type: "bit", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false),
                    CuentaCobroNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCobrarPagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Cliente",
                        column: x => x.Cliente,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Cuenta",
                        column: x => x.CuentaPago,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Cuenta_CuentaCobroNavigationId",
                        column: x => x.CuentaCobroNavigationId,
                        principalTable: "Cuenta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Localidad",
                        column: x => x.Localidad,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Proveedor",
                        column: x => x.Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CuentaCobrarPagar_Transaccion",
                        column: x => x.Transaccion,
                        principalTable: "Transaccion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FichaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FichaProducto_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FichaProducto_Producto1",
                        column: x => x.Codigo,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperacionesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionesEncabezado = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(18,3)", nullable: false, defaultValueSql: "((0.00))"),
                    Costo = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    ImporteCosto = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Venta = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    ImporteVenta = table.Column<decimal>(type: "numeric(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Existencia = table.Column<decimal>(type: "numeric(18,3)", nullable: false, defaultValueSql: "((0.00))"),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesDetalle_Localidad",
                        column: x => x.Localidad,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperacionesDetalle_OperacionesEncabezado",
                        column: x => x.OperacionesEncabezado,
                        principalTable: "OperacionesEncabezado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OperacionesDetalle_Producto",
                        column: x => x.Codigo,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Saldo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Saldo_Localidad",
                        column: x => x.Localidad,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Saldo_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaldoAnterior",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Producto = table.Column<int>(type: "int", nullable: false),
                    PrecioCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValueSql: "((0.00))"),
                    Existencia = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    ImporteCosto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoAnterior", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaldoAnterior_Localidad",
                        column: x => x.Localidad,
                        principalTable: "Localidad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaldoAnterior_Producto",
                        column: x => x.Producto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperacionesServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionesDetalle = table.Column<int>(type: "int", nullable: false),
                    Localidad = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    ImporteCosto = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Cancelado = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaHoraModificado = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperacionesDetalleNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperacionesServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperacionesServicio_OperacionesDetalle_OperacionesDetalleNavigationId",
                        column: x => x.OperacionesDetalleNavigationId,
                        principalTable: "OperacionesDetalle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CajaRegistradora_IdTurno",
                table: "CajaRegistradora",
                column: "IdTurno");

            migrationBuilder.CreateIndex(
                name: "IX_CajaRegistradoraDetalle_CajaRegistradora",
                table: "CajaRegistradoraDetalle",
                column: "CajaRegistradora");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente",
                table: "Cliente",
                columns: new[] { "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_Cuenta",
                table: "Comprobante",
                column: "Cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoAjuste",
                table: "ConceptoAjuste",
                columns: new[] { "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoAjuste_Cuenta",
                table: "ConceptoAjuste",
                column: "Cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_Configuracion_CuentaCobrar",
                table: "Configuracion",
                column: "CuentaCobrar");

            migrationBuilder.CreateIndex(
                name: "IX_Configuracion_CuentaPagar",
                table: "Configuracion",
                column: "CuentaPagar");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta",
                table: "Cuenta",
                columns: new[] { "Codigo", "SubGrupoCuenta", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_SubGrupo",
                table: "Cuenta",
                column: "SubGrupoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Cliente",
                table: "CuentaCobrarPagar",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaCobroNavigationId",
                table: "CuentaCobrarPagar",
                column: "CuentaCobroNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_CuentaPago",
                table: "CuentaCobrarPagar",
                column: "CuentaPago");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Localidad",
                table: "CuentaCobrarPagar",
                column: "Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Proveedor",
                table: "CuentaCobrarPagar",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCobrarPagar_Transaccion",
                table: "CuentaCobrarPagar",
                column: "Transaccion");

            migrationBuilder.CreateIndex(
                name: "IX_Establecimiento",
                table: "Establecimiento",
                columns: new[] { "Negocio", "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Cuenta",
                table: "EstadoCuenta",
                columns: new[] { "Establecimiento", "Cuenta" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_Cuenta1",
                table: "EstadoCuenta",
                column: "Cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_FichaProducto_Codigo",
                table: "FichaProducto",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_FichaProducto_Producto",
                table: "FichaProducto",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoCuenta",
                table: "GrupoCuenta",
                columns: new[] { "Descripcion", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Linea",
                table: "Linea",
                columns: new[] { "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localidad",
                table: "Localidad",
                columns: new[] { "Establecimiento", "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_CuentaCosto",
                table: "Localidad",
                column: "CuentaCosto");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_CuentaDevolucion",
                table: "Localidad",
                column: "CuentaDevolucion");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_CuentaInventario",
                table: "Localidad",
                column: "CuentaInventario");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_CuentaVenta",
                table: "Localidad",
                column: "CuentaVenta");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesDetalle_Codigo",
                table: "OperacionesDetalle",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesDetalle_Localidad",
                table: "OperacionesDetalle",
                column: "Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesDetalle_OperacionesEncabezado",
                table: "OperacionesDetalle",
                column: "OperacionesEncabezado");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado",
                table: "OperacionesEncabezado",
                columns: new[] { "Transaccion", "NoDocumento", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_Cliente",
                table: "OperacionesEncabezado",
                column: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_ConceptoAjuste",
                table: "OperacionesEncabezado",
                column: "ConceptoAjuste");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesEncabezado_Proveedor",
                table: "OperacionesEncabezado",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesServicio_OperacionesDetalle",
                table: "OperacionesServicio",
                column: "OperacionesDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_OperacionesServicio_OperacionesDetalleNavigationId",
                table: "OperacionesServicio",
                column: "OperacionesDetalleNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto",
                table: "Producto",
                columns: new[] { "Establecimiento", "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Proveedor",
                table: "Producto",
                column: "Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_SubLinea",
                table: "Producto",
                column: "SubLinea");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UnidadMedida",
                table: "Producto",
                column: "UnidadMedida");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor",
                table: "Proveedor",
                columns: new[] { "Codigo", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saldo_Localidad",
                table: "Saldo",
                column: "Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_Saldo_Producto",
                table: "Saldo",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoAnterior_Localidad",
                table: "SaldoAnterior",
                column: "Localidad");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoAnterior_Producto",
                table: "SaldoAnterior",
                column: "Producto");

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupoCuenta",
                table: "SubGrupoCuenta",
                columns: new[] { "Codigo", "GrupoCuenta", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubGrupoCuenta_GrupoCuenta",
                table: "SubGrupoCuenta",
                column: "GrupoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_SubLinea",
                table: "SubLinea",
                columns: new[] { "Codigo", "Linea", "Cancelado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubLinea_Linea",
                table: "SubLinea",
                column: "Linea");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadMedida",
                table: "UnidadMedida",
                columns: new[] { "Codigo", "Cancelado" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CajaRegistradoraDetalle");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "ComprobanteTemporal");

            migrationBuilder.DropTable(
                name: "CuentaCobrarPagar");

            migrationBuilder.DropTable(
                name: "EstadoCuenta");

            migrationBuilder.DropTable(
                name: "FichaProducto");

            migrationBuilder.DropTable(
                name: "OperacionesServicio");

            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DropTable(
                name: "SaldoAnterior");

            migrationBuilder.DropTable(
                name: "CajaRegistradora");

            migrationBuilder.DropTable(
                name: "OperacionesDetalle");

            migrationBuilder.DropTable(
                name: "IdTurno");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "OperacionesEncabezado");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ConceptoAjuste");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Establecimiento");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "SubLinea");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "SubGrupoCuenta");

            migrationBuilder.DropTable(
                name: "GrupoCuenta");

            migrationBuilder.DropColumn(
                name: "Acceso_1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Acceso_2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Acceso_3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsernameChangeLimit",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

using GoldBusiness.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIGoldBusiness.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(36000);
        }

        public virtual DbSet<CajaRegistradora> CajaRegistradora { get; set; }
        public virtual DbSet<CajaRegistradoraDetalle> CajaRegistradoraDetalle { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public virtual DbSet<ComprobanteTemporal> ComprobanteTemporal { get; set; }
        public virtual DbSet<ConceptoAjuste> ConceptoAjuste { get; set; }
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Establecimiento> Establecimiento { get; set; }
        public virtual DbSet<EstadoCuenta> EstadoCuenta { get; set; }
        public virtual DbSet<FichaProducto> FichaProducto { get; set; }
        public virtual DbSet<GrupoCuenta> GrupoCuenta { get; set; }
        public virtual DbSet<IdTurno> IdTurno { get; set; }
        public virtual DbSet<Linea> Linea { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<OperacionesDetalle> OperacionesDetalle { get; set; }
        public virtual DbSet<OperacionesEncabezado> OperacionesEncabezado { get; set; }
        public virtual DbSet<OperacionesServicio> OperacionesServicio { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Saldo> Saldo { get; set; }
        public virtual DbSet<SaldoAnterior> SaldoAnterior { get; set; }
        public virtual DbSet<SubGrupoCuenta> SubGrupoCuenta { get; set; }
        public virtual DbSet<SubLinea> SubLinea { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<CuentaCobrarPagar> CuentaCobrarPagar { get; set; }
        public virtual DbSet<ErroresVenta> ErroresVenta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CajaRegistradora>(entity =>
            {
                entity.HasOne(d => d.IdTurnoNavigation)
                    .WithMany(p => p.CajaRegistradora)
                    .HasForeignKey(d => d.IdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaRegistradora_IdTurno");
            });

            modelBuilder.Entity<CajaRegistradoraDetalle>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ImporteVenta).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Venta).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CajaRegistradoraNavigation)
                    .WithMany(p => p.CajaRegistradoraDetalle)
                    .HasForeignKey(d => d.CajaRegistradora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CajaRegistradoraDetalle_CajaRegistradora");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Cliente")
                    .IsUnique();

                entity.Property(e => e.BicoSwift).HasMaxLength(11);

                entity.Property(e => e.CodPostal).HasMaxLength(5);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Direccion).HasMaxLength(256);

                entity.Property(e => e.Email1)
                    .HasColumnName("email1")
                    .HasMaxLength(256);

                entity.Property(e => e.Email2)
                    .HasColumnName("email2")
                    .HasMaxLength(256);

                entity.Property(e => e.Fax1).HasMaxLength(50);

                entity.Property(e => e.Fax2).HasMaxLength(50);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.Iban).HasMaxLength(27);

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(4, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Municipio).HasMaxLength(50);

                entity.Property(e => e.Nif).HasMaxLength(11);

                entity.Property(e => e.Provincia).HasMaxLength(50);

                entity.Property(e => e.Telefono1).HasMaxLength(50);

                entity.Property(e => e.Telefono2).HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(256);
            });

            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NoComprobante)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observaciones).HasMaxLength(256);

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.Comprobante)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comprobante_Establecimiento");
            });

            modelBuilder.Entity<ComprobanteDetalle>(entity =>
            {
                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Credito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Debito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Departamento).HasMaxLength(9);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Nota).HasMaxLength(256);

                entity.Property(e => e.Parcial).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ComprobanteNavigation)
                    .WithMany(p => p.ComprobanteDetalle)
                    .HasForeignKey(d => d.Comprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteDetalle_Comprobante");

                entity.HasOne(d => d.CuentaNavigation)
                    .WithMany(p => p.ComprobanteDetalle)
                    .HasForeignKey(d => d.Cuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteDetalle_Cuenta");
            });

            modelBuilder.Entity<ComprobanteTemporal>(entity =>
            {
                entity.Property(e => e.CodigoTransaccion)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Credito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Debito).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Departamento).HasMaxLength(9);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.NoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Parcial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Transaccion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.ComprobanteTemporal)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComprobanteTemporal_Establecimiento");
            });

            modelBuilder.Entity<ConceptoAjuste>(entity =>
            {
                entity.HasIndex(e => e.Cuenta);

                entity.HasIndex(e => new { e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_ConceptoAjuste")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CuentaNavigation)
                    .WithMany(p => p.ConceptoAjuste)
                    .HasForeignKey(d => d.Cuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConceptoAjuste_Cuenta");
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.HasIndex(e => e.CuentaPagar);
                
                entity.Property(e => e.Caducidad).HasColumnType("date");

                entity.Property(e => e.CodPostal).HasMaxLength(5);

                entity.Property(e => e.CodigoSistema)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(256);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Licencia).IsRequired();

                entity.Property(e => e.Municipio).HasMaxLength(50);

                entity.Property(e => e.NombreNegocio)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Provincia).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
                
                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Web).HasMaxLength(256);

                entity.HasOne(d => d.CuentaCobrarNavigation)
                    .WithMany(p => p.ConfiguracionCuentaCobrarNavigation)
                    .HasForeignKey(d => d.CuentaCobrar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracionCobrar_Cuenta");

                entity.HasOne(d => d.CuentaPagarNavigation)
                    .WithMany(p => p.ConfiguracionCuentaPagarNavigation)
                    .HasForeignKey(d => d.CuentaPagar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracionPagar_Cuenta");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasIndex(e => e.SubGrupoCuenta)
                    .HasDatabaseName("IX_Cuenta_SubGrupo");

                entity.HasIndex(e => new { e.Codigo, e.SubGrupoCuenta, e.Cancelado })
                    .HasDatabaseName("IX_Cuenta")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.SubGrupoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.SubGrupoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_SubGrupoCuenta");
            });

            modelBuilder.Entity<CuentaCobrarPagar>(entity =>
            {
                entity.HasIndex(e => e.Cliente);

                entity.HasIndex(e => e.CobroEfectivoImporte)
                    .HasDatabaseName("IX_CuentaCobrarPagar_Localidad");

                entity.HasIndex(e => e.CuentaPagoEfectivo)
                    .HasDatabaseName("IX_CuentaCobrarPagar_CuentaPago");

                entity.HasIndex(e => e.Proveedor);

                entity.HasIndex(e => e.Transaccion);

                entity.Property(e => e.CobroEfectivoDepartamento).HasMaxLength(9);

                entity.Property(e => e.CobroEfectivoImporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CobroEfectivoParcialMlc)
                    .HasColumnName("CobroEfectivoParcialMLC")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CobroElectronicoDepartamento).HasMaxLength(9);

                entity.Property(e => e.CobroElectronicoImporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CobroElectronicoParcialMlc)
                    .HasColumnName("CobroElectronicoParcialMLC")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NoDocumento).HasMaxLength(50);

                entity.Property(e => e.NoPrimario).HasMaxLength(50);

                entity.Property(e => e.PagoEfectivoDepartamento).HasMaxLength(9);

                entity.Property(e => e.PagoEfectivoImporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PagoEfectivoParcialMlc)
                    .HasColumnName("PagoEfectivoParcialMLC")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PagoElectronicoDepartamento).HasMaxLength(9);

                entity.Property(e => e.PagoElectronicoImporte).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PagoElectronicoParcialMlc)
                    .HasColumnName("PagoElectronicoParcialMLC")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CuentaCobrarPagar)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_CuentaCobrarPagar_Cliente");

                entity.HasOne(d => d.CuentaCobroEfectivoNavigation)
                    .WithMany(p => p.CuentaCobrarPagarCuentaCobroEfectivoNavigation)
                    .HasForeignKey(d => d.CuentaCobroEfectivo)
                    .HasConstraintName("FK_CuentaCobrarEfectivo_Cuenta");

                entity.HasOne(d => d.CuentaCobroElectronicoNavigation)
                    .WithMany(p => p.CuentaCobrarPagarCuentaCobroElectronicoNavigation)
                    .HasForeignKey(d => d.CuentaCobroElectronico)
                    .HasConstraintName("FK_CuentaCobrarElectronico_Cuenta");

                entity.HasOne(d => d.CuentaPagoEfectivoNavigation)
                    .WithMany(p => p.CuentaCobrarPagarCuentaPagoEfectivoNavigation)
                    .HasForeignKey(d => d.CuentaPagoEfectivo)
                    .HasConstraintName("FK_CuentaPagarEfectivo_Cuenta");

                entity.HasOne(d => d.CuentaPagoElectronicoNavigation)
                    .WithMany(p => p.CuentaCobrarPagarCuentaPagoElectronicoNavigation)
                    .HasForeignKey(d => d.CuentaPagoElectronico)
                    .HasConstraintName("FK_CuentaPagarElectronico_Cuenta");

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.CuentaCobrarPagar)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentaCobrarPagar_Establecimiento");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.CuentaCobrarPagar)
                    .HasForeignKey(d => d.Proveedor)
                    .HasConstraintName("FK_CuentaCobrarPagar_Proveedor");

                entity.HasOne(d => d.TransaccionNavigation)
                    .WithMany(p => p.CuentaCobrarPagar)
                    .HasForeignKey(d => d.Transaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentaCobrarPagar_Transaccion");
            });

            modelBuilder.Entity<ErroresVenta>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Costo).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ImporteCosto).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.ErroresVenta)
                    .HasForeignKey(d => d.Codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ErroresVenta_Producto");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.ErroresVenta)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ErroresVenta_Localidad");

                entity.HasOne(d => d.OperacionesDetalleNavigation)
                    .WithMany(p => p.ErroresVenta)
                    .HasForeignKey(d => d.OperacionesDetalle)
                    .HasConstraintName("FK_ErroresVenta_OperacionesDetalle");
            });

            modelBuilder.Entity<Establecimiento>(entity =>
            {
                entity.HasIndex(e => new { e.Negocio, e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Establecimiento")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.NegocioNavigation)
                    .WithMany(p => p.Establecimiento)
                    .HasForeignKey(d => d.Negocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Establecimiento_Configuracion");
            });

            modelBuilder.Entity<EstadoCuenta>(entity =>
            {
                entity.HasIndex(e => new { e.Establecimiento, e.Cuenta, e.Departamento })
                    .HasDatabaseName("IX_EstadoCuenta")
                    .IsUnique();

                entity.Property(e => e.Departamento).HasMaxLength(9);

                entity.Property(e => e.Parcial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CuentaNavigation)
                    .WithMany(p => p.EstadoCuenta)
                    .HasForeignKey(d => d.Cuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstadoCuenta_Cuenta");

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.EstadoCuenta)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstadoCuenta_Establecimiento");
            });

            modelBuilder.Entity<FichaProducto>(entity =>
            {
                entity.HasIndex(e => e.Codigo);

                entity.HasIndex(e => e.Producto);

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.FichaProductoCodigoNavigation)
                    .HasForeignKey(d => d.Codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FichaProducto_Producto1");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.FichaProducto)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FichaProducto_Localidad");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.FichaProductoProductoNavigation)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FichaProducto_Producto");
            });

            modelBuilder.Entity<GrupoCuenta>(entity =>
            {
                entity.HasIndex(e => new { e.Descripcion, e.Cancelado })
                    .HasDatabaseName("IX_GrupoCuenta")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<IdTurno>(entity =>
            {
                entity.Property(e => e.Cajero)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Cierre).HasColumnType("datetime");

                entity.Property(e => e.Extraccion).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Fondo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Inicio).HasColumnType("datetime");
            });

            modelBuilder.Entity<Linea>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Linea")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasIndex(e => new { e.Establecimiento, e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Localidad")
                    .IsUnique();

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.CuentaCostoNavigation)
                    .WithMany(p => p.LocalidadCuentaCostoNavigation)
                    .HasForeignKey(d => d.CuentaCosto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_CuentaCosto");

                entity.HasOne(d => d.CuentaDevolucionNavigation)
                    .WithMany(p => p.LocalidadCuentaDevolucionNavigation)
                    .HasForeignKey(d => d.CuentaDevolucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_CuentaDevolucion");

                entity.HasOne(d => d.CuentaInventarioNavigation)
                    .WithMany(p => p.LocalidadCuentaInventarioNavigation)
                    .HasForeignKey(d => d.CuentaInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_CuentaInventario");

                entity.HasOne(d => d.CuentaVentaNavigation)
                    .WithMany(p => p.LocalidadCuentaVentaNavigation)
                    .HasForeignKey(d => d.CuentaVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_CuentaVenta");

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.Localidad)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Localidad_Establecimiento");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasIndex(e => new { e.Establecimiento, e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Moneda")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.Moneda)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moneda_Establecimiento");
            });

            modelBuilder.Entity<OperacionesDetalle>(entity =>
            {
                entity.HasIndex(e => e.Codigo);

                entity.HasIndex(e => e.Localidad);

                entity.HasIndex(e => e.OperacionesEncabezado);

                entity.Property(e => e.Cantidad)
                    .HasColumnType("numeric(18, 3)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Costo)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Existencia)
                    .HasColumnType("numeric(18, 3)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ImporteCosto)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImporteVenta)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Venta)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.OperacionesDetalle)
                    .HasForeignKey(d => d.Codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesDetalle_Producto");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.OperacionesDetalle)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesDetalle_Localidad");

                entity.HasOne(d => d.OperacionEncabezadoNavigation)
                    .WithMany(p => p.OperacionesDetalle)
                    .HasForeignKey(d => d.OperacionesEncabezado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesDetalle_OperacionesEncabezado");
            });

            modelBuilder.Entity<OperacionesEncabezado>(entity =>
            {
                entity.HasIndex(e => e.Cliente);

                entity.HasIndex(e => e.ConceptoAjuste);

                entity.HasIndex(e => e.Proveedor);

                entity.HasIndex(e => new { e.Establecimiento, e.Transaccion, e.NoDocumento, e.Cancelado })
                    .HasDatabaseName("IX_OperacionesEncabezado")
                    .IsUnique();

                entity.Property(e => e.Concepto).HasMaxLength(50);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NoDocumento)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoPrimario).HasMaxLength(50);

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.OperacionesEncabezado)
                    .HasForeignKey(d => d.Cliente)
                    .HasConstraintName("FK_OperacionesEncabezado_Cliente");

                entity.HasOne(d => d.ConceptoAjusteNavigation)
                    .WithMany(p => p.OperacionesEncabezado)
                    .HasForeignKey(d => d.ConceptoAjuste)
                    .HasConstraintName("FK_OperacionesEncabezado_ConceptoAjuste");

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.OperacionesEncabezado)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesEncabezado_Establecimiento");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.OperacionesEncabezado)
                    .HasForeignKey(d => d.Proveedor)
                    .HasConstraintName("FK_OperacionesEncabezado_Proveedor");

                entity.HasOne(d => d.TransaccionNavigation)
                    .WithMany(p => p.OperacionesEncabezado)
                    .HasForeignKey(d => d.Transaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesEncabezado_Transaccion");
            });

            modelBuilder.Entity<OperacionesServicio>(entity =>
            {
                entity.HasIndex(e => e.OperacionesDetalle);

                entity.Property(e => e.Cantidad).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Costo).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ImporteCosto).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.OperacionesDetalleNavigation)
                    .WithMany(p => p.OperacionesServicio)
                    .HasForeignKey(d => d.OperacionesDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperacionesServicio_OperacionesDetalle");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasIndex(e => e.Proveedor);

                entity.HasIndex(e => e.SubLinea);

                entity.HasIndex(e => e.UnidadMedida);

                entity.HasIndex(e => new { e.Establecimiento, e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Producto")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.CodigoReferencia).HasMaxLength(50);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.PrecioCosto)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PrecioVenta).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockMinimo)
                    .HasColumnType("numeric(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.EstablecimientoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Establecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Establecimiento");

                entity.HasOne(d => d.ProveedorNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.Proveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Proveedor");

                entity.HasOne(d => d.SubLineaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.SubLinea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_SubLinea");

                entity.HasOne(d => d.UnidadMedidaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.UnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_UnidadMedida");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_Proveedor")
                    .IsUnique();

                entity.Property(e => e.BicoSwift).HasMaxLength(11);

                entity.Property(e => e.CodPostal).HasMaxLength(5);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Direccion).HasMaxLength(256);

                entity.Property(e => e.Email1)
                    .HasColumnName("email1")
                    .HasMaxLength(256);

                entity.Property(e => e.Email2)
                    .HasColumnName("email2")
                    .HasMaxLength(256);

                entity.Property(e => e.Fax1).HasMaxLength(50);

                entity.Property(e => e.Fax2).HasMaxLength(50);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.Iban).HasMaxLength(27);

                entity.Property(e => e.Iva)
                    .HasColumnType("decimal(4, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Municipio).HasMaxLength(50);

                entity.Property(e => e.Nif).HasMaxLength(11);

                entity.Property(e => e.Provincia).HasMaxLength(50);

                entity.Property(e => e.Telefono1).HasMaxLength(50);

                entity.Property(e => e.Telefono2).HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(256);
            });

            modelBuilder.Entity<Saldo>(entity =>
            {
                entity.Property(e => e.Existencia).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.Saldo)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Saldo_Localidad");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Saldo)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Saldo_Producto");
            });

            modelBuilder.Entity<SaldoAnterior>(entity =>
            {
                entity.HasIndex(e => e.Localidad);

                entity.HasIndex(e => e.Producto);

                entity.Property(e => e.Existencia).HasColumnType("numeric(18, 3)");

                entity.Property(e => e.ImporteCosto).HasColumnType("decimal(18, 2)");
                
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.PrecioCosto)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.SaldoAnterior)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldoAnterior_Localidad");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.SaldoAnterior)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaldoAnterior_Producto");
            });

            modelBuilder.Entity<SubGrupoCuenta>(entity =>
            {
                entity.HasIndex(e => e.GrupoCuenta);

                entity.HasIndex(e => new { e.Codigo, e.GrupoCuenta, e.Cancelado })
                    .HasDatabaseName("IX_SubGrupoCuenta")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.GrupoCuentaNavigation)
                    .WithMany(p => p.SubGrupoCuenta)
                    .HasForeignKey(d => d.GrupoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubGrupoCuenta_GrupoCuenta");
            });

            modelBuilder.Entity<SubLinea>(entity =>
            {
                entity.HasIndex(e => e.Linea);

                entity.HasIndex(e => new { e.Codigo, e.Linea, e.Cancelado })
                    .HasDatabaseName("IX_SubLinea")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.LineaNavigation)
                    .WithMany(p => p.SubLinea)
                    .HasForeignKey(d => d.Linea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubLinea_Linea");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UnidadMedida>(entity =>
            {
                entity.HasIndex(e => new { e.Codigo, e.Cancelado })
                    .HasDatabaseName("IX_UnidadMedida")
                    .IsUnique();

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FechaHoraCreado).HasColumnType("datetime");

                entity.Property(e => e.FechaHoraModificado).HasColumnType("datetime");

                entity.Property(e => e.ModificadoPor)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}

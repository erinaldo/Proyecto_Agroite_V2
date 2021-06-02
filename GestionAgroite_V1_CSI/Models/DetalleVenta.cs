namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("DetalleVenta")]
    public partial class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdDetalleVenta > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms.model;

namespace Forms.Presentacion
{
    public partial class frmTabla : Form
    {
        public int? id ;
        Productos oTabla = null ; // ----------------------------------------------------------------------------
        public frmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null)
                CargaDatos();

            
        }
        private void CargaDatos()
        {
            using (PruebaEntities db = new PruebaEntities())
            {
                /* oTabla =  db.Productos.Find(id);
                txtProductoId.Text = int.Parse(oTabla.productoId);
                txtNombreProducto.Text = oTabla.nombreProducto;
                txtCantidad.Text = oTabla.cantidad;
                txtCategoria.Text = oTabla.categoria;*/

                int productoId, cantidad, categoria;

                if (int.TryParse(txtProductoId.Text, out productoId) &&
                    int.TryParse(txtCantidad.Text, out cantidad) &&
                    int.TryParse(txtCategoria.Text, out categoria))
                {
                    // Conversiones exitosas
                }
                else
                {
                    // Manejo de error: mostrar un mensaje o tomar alguna acción
                    MessageBox.Show("Por favor, ingrese valores numéricos válidos.");
                    return;
                }


            }
        }
        /* private void button1_Click(object sender, EventArgs e)
        {
            using (PruebaEntities db = new PruebaEntities() )
            {
                if(id== null)
                    oTabla = new Productos();

                Productos productos = new Productos();// esta es la clase q me creo sola entity y se llama como mi tabla Productos
                productos.productoId = int.Parse(txtProductoId.Text);
                productos.nombreProducto = txtNombreProducto.Text;
                productos.cantidad = int.Parse(txtCantidad.Text);
                productos.categoria = int.Parse(txtCategoria.Text);


                if(id==null)
                    db.Productos.Add(oTabla);
                else
                {
                    db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                }

              //  db.SaveChanges();
                db.Productos.Add(productos);// agreagr a la base de dato lo q se guardo
                db.SaveChanges();//esto guarda en la base de datos

                this.Close(); // esto es cunado se guarda todo CIERRRA EL FORMULARIO
            }
        }*/
        private void button1_Click(object sender, EventArgs e)
        {
            using (PruebaEntities db = new PruebaEntities())
            {
                // Verifica si el ID es nulo o no antes de proceder
                if (id != null)
                {
                    // Buscar la entidad existente
                    oTabla = db.Productos.Find(id);

                    // Si la entidad existe, actualiza los valores
                    if (oTabla != null)
                    {
                        oTabla.productoId = int.Parse(txtProductoId.Text);
                        oTabla.nombreProducto = txtNombreProducto.Text;
                        oTabla.cantidad = int.Parse(txtCantidad.Text);
                        oTabla.categoria = int.Parse(txtCategoria.Text);

                        // Marca la entidad como modificada
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("El producto con el ID especificado no fue encontrado.");
                        return;
                    }
                }
                else
                {
                    // Crear una nueva entidad si el ID es nulo
                    Productos productos = new Productos
                    {
   // ------------------------------ productoId = int.Parse(txtProductoId.Text),
                        nombreProducto = txtNombreProducto.Text,
                        cantidad = int.Parse(txtCantidad.Text),
                        categoria = int.Parse(txtCategoria.Text)
                    };

                    // Agregar la nueva entidad a la base de datos
                    db.Productos.Add(productos);
                }

                // Guardar los cambios en la base de datos
                db.SaveChanges();
                MessageBox.Show("Cambios guardados exitosamente.");
                this.Close(); // Cierra el formulario después de guardar
            }
        }


        private void frmTabla_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

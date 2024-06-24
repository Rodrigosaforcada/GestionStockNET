using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Forms.model;
using Forms.Presentacion;
using Microsoft.VisualBasic;
namespace Forms
{
    public partial class Form1 : Form
    {
        private List<ProductoComprado> productosComprados = new List<ProductoComprado>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        #region  HELPER 
        private void Refrescar()
        {
            //seria como un selec
            using (PruebaEntities db = new PruebaEntities()) //nombre de la bd mapeada
            {
                var lst = from d in db.Productos
                          select d;

                dataGridView1.DataSource = lst.ToList();
            }
        }

        private int? GetId() {

            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch {
                return null;
                    }
        
            }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
           Presentacion.frmTabla ofrmTabla = new Presentacion.frmTabla();
            ofrmTabla.ShowDialog();
            Refrescar();
        }

        private void button3_Click(object sender, EventArgs e)// boton editar
        {
            // obtengo la celda del id con el metodo q esta en HELPER 
            int? id = GetId();
            if(id != null)
            {
                Presentacion.frmTabla ofrmtabla = new Presentacion.frmTabla(id);
                ofrmtabla.ShowDialog();
                Refrescar() ;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            int? id = GetId();
            if (id != null)
            {

                using (PruebaEntities db = new PruebaEntities()) // my entitis
                {
                    Productos otabla = db.Productos.Find(id); // se llama como la tabla creada en la base de datos
                    db.Productos.Remove(otabla);    
                    db.SaveChanges();
                }



                    Refrescar();
            }


        }


        //metodo mejorado de comrpar 

        private void btnComprar_Click(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    int idProducto = int.Parse(inputForm.ProductId);
                    int cantidadAComprar = int.Parse(inputForm.Quantity);

                    using (PruebaEntities db = new PruebaEntities())
                    {
                        var producto = db.Productos.Find(idProducto);
                        if (producto != null)
                        {
                            if (producto.cantidad >= cantidadAComprar)
                            {
                                producto.cantidad -= cantidadAComprar;
                                if (producto.cantidad == 0)
                                {
                                    db.Productos.Remove(producto);
                                }
                                db.SaveChanges();
                                MessageBox.Show("Compra realizada con éxito. Cantidad actualizada.");

                                // Agregar producto comprado a la lista
                                productosComprados.Add(new ProductoComprado
                                {
                                    NombreProducto = producto.nombreProducto,
                                    Cantidad = cantidadAComprar,
                                    FechaCompra = DateTime.Now
                                });
                            }
                            else
                            {
                                MessageBox.Show("No hay suficiente cantidad en stock.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto no existe.");
                        }
                    }
                    Refrescar();
                }
            }
        }





        // metodo que funciona de comprar 
        /* private void btnComprar_Click(object sender, EventArgs e)
        {
            using (InputForm inputForm = new InputForm())
            {
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    int idProducto = int.Parse(inputForm.ProductId);
                    int cantidadAComprar = int.Parse(inputForm.Quantity);

                    using (PruebaEntities db = new PruebaEntities())
                    {
                        var producto = db.Productos.Find(idProducto);
                        if (producto != null)
                        {
                            if (producto.cantidad >= cantidadAComprar)
                            {
                                producto.cantidad -= cantidadAComprar;
                                if (producto.cantidad == 0)
                                {
                                    db.Productos.Remove(producto);
                                }
                                db.SaveChanges();
                                MessageBox.Show("Compra realizada con éxito. Cantidad actualizada.");
                            }
                            else
                            {
                                MessageBox.Show("No hay suficiente cantidad en stock.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El producto no existe.");
                        }
                    }
                    Refrescar();
                }
            }
        }*/



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (InputBoxForm inputBox = new InputBoxForm("Ingrese el nombre del producto:"))
            {
                if (inputBox.ShowDialog() == DialogResult.OK)
                {
                    string nombreProducto = inputBox.InputText;

                    using (PruebaEntities db = new PruebaEntities())
                    {
                        var producto = db.Productos.FirstOrDefault(p => p.nombreProducto == nombreProducto);
                        if (producto != null)
                        {
                            MessageBox.Show($"ID: {producto.productoId}\nNombre: {producto.nombreProducto}\nCantidad: {producto.cantidad}", "Producto Encontrado");
                        }
                        else
                        {
                            MessageBox.Show("UPSS!! El producto NO existe.");
                        }
                    }
                }
            }
        }

        private void btnDescarga_Click(object sender, EventArgs e)
        {
            if (productosComprados.Count == 0)
            {
                MessageBox.Show("No hay productos comprados.");
                return;
            }

            string mensaje = "Productos Comprados:\n\n";
            foreach (var producto in productosComprados)
            {
                mensaje += $"Nombre del Producto: {producto.NombreProducto}\n";
                mensaje += $"Cantidad: {producto.Cantidad}\n";
                mensaje += $"Fecha y Hora de Compra: {producto.FechaCompra}\n\n";
            }

            MessageBox.Show(mensaje, "Detalle de Compras");
        }
    



    public class ProductoComprado
        {
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
            public DateTime FechaCompra { get; set; }
        }

    }
}

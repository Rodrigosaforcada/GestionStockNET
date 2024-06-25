// See https://aka.ms/new-console-template for more information
using GestionStock.Core.Business;
using GestionStock.Core.Entities;

var usuarioBusiness = new UsuarioBusiness();
var categoriaBusiness = new CategoriaBusiness();
var productoBusiness = new ProductoBusiness();
var compraBusiness = new CompraBusiness();
var ventaBusiness = new VentaBusiness();

bool volverPrincipal = true;
while (volverPrincipal)
{

    Console.WriteLine("Indique la acción que desea realizar: ");
    Console.WriteLine("1) Ver opciones para Usuarios");
    Console.WriteLine("2) Ver opciones para Categorias");
    Console.WriteLine("3) Ver opciones para Productos");
    Console.WriteLine("4) Ver opciones para Compras");
    Console.WriteLine("5) Ver opciones para Ventas");

    int eleccionPrincipal = Convert.ToInt32(Console.ReadLine());

    switch (eleccionPrincipal)
    {
        case 1:
            //Usuarios
            Console.WriteLine("Indique la acción que desea realizar: ");
            Console.WriteLine("1) Crear un nuevo Usuario");
            Console.WriteLine("2) Ingresar al sistema con un Usuario");
            Console.WriteLine("3) Listar los Usuarios que existen en el sistema");
            Console.WriteLine("4) Buscar un Usuario");
            Console.WriteLine("5) Actualizar el nombre de un Usuario");
            Console.WriteLine("6) Borrar un Usuario");

            int eleccionUsuarios = Convert.ToInt32(Console.ReadLine());


            switch (eleccionUsuarios)
            {
                case 1:
                    //Creacion Usuario
                    try
                    {
                        Console.WriteLine("Ingrese su nombre de usuario para registrarse: ");
                        string nuevoUsuarioNombre = Console.ReadLine();

                        Console.WriteLine("Ingrese su contraseña para registrarse: ");
                        string nuevoUsuarioContrasena = Console.ReadLine();

                        if ((nuevoUsuarioNombre != "" || nuevoUsuarioNombre != null) && (nuevoUsuarioContrasena != "" || nuevoUsuarioContrasena != null))
                        {
                            usuarioBusiness.CreateUsuario(nuevoUsuarioNombre, nuevoUsuarioContrasena);
                            Console.WriteLine($"Bienvenido {nuevoUsuarioNombre}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo crear el nuevo usuario.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 2:
                    //Logueo de Usuario
                    try
                    {
                        Console.WriteLine("Ingrese su id de usuario: ");
                        int usuarioId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese su contraseña: ");
                        string usuarioContrasena = Console.ReadLine();
                        Usuario usuarioBuscado = usuarioBusiness.GetAsync(usuarioId);
                        if (usuarioBuscado.usuarioId == usuarioId)
                        {
                            if (usuarioBusiness.ControlContrasena(usuarioId, usuarioContrasena))
                            {
                                Console.WriteLine($"Bienvenido {usuarioBuscado.ToString()}.");
                            }
                            else
                            {
                                Console.WriteLine("Contraseña incorrecta.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No existe usuario con ese id.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 3:
                    ListUsuarios(usuarioBusiness);
                    Volver();
                    break;
                case 4:
                    Console.WriteLine("Ingrese el Id del usuario para buscarlo: ");
                    int idBusqueda = Convert.ToInt32(Console.ReadLine());
                    Usuario usuarioAbuscar = usuarioBusiness.GetAsync(idBusqueda);
                    Console.WriteLine($"Nombre: {usuarioAbuscar.nombre}");
                    Volver();
                    break;
                case 5:
                    Console.WriteLine("Ingrese el Id del usuario para actualizar: ");
                    int idBusquedaAct = Convert.ToInt32(Console.ReadLine());
                    Usuario usuarioAbuscarAct = usuarioBusiness.GetAsync(idBusquedaAct);
                    Console.WriteLine("Ingrese el nuevo nombre del usuario: ");
                    usuarioAbuscarAct.nombre = Console.ReadLine();
                    usuarioBusiness.UpdateAsync(usuarioAbuscarAct);
                    Console.WriteLine($"Nuevo nombre: {usuarioAbuscarAct.nombre}");
                    Volver();
                    break;
                case 6:
                    Console.WriteLine("Ingrese el Id del usuario para borrar: ");
                    int idBusquedaBorrar = Convert.ToInt32(Console.ReadLine());
                    usuarioBusiness.DeleteAsync(idBusquedaBorrar);
                    Console.WriteLine("Usuario borrado.");
                    Volver();
                    break;
            }
            break;
        case 2:
            //Categorias
            Console.WriteLine("Indique la acción que desea realizar: ");
            Console.WriteLine("1) Crear una nueva Categoria");
            Console.WriteLine("2) Listar las Categorias que existen en el sistema");
            Console.WriteLine("3) Actualizar el nombre de una Categoria que existe en el sistema");
            Console.WriteLine("4) Borrar una Categoria");

            int eleccionCategorias = Convert.ToInt32(Console.ReadLine());

            switch (eleccionCategorias)
            {
                case 1:
                    //Creacion Categoria
                    try
                    {
                        Console.WriteLine("Ingrese el nombre de la nueva Categoria: ");
                        string nuevaCategoriaNombre = Console.ReadLine();
                        if (nuevaCategoriaNombre != "" || nuevaCategoriaNombre != null)
                        {
                            categoriaBusiness.CreateCategoria(nuevaCategoriaNombre);
                            Console.WriteLine($"Nueva categoria: {nuevaCategoriaNombre}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo crear  la nueva Categoria.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 2:
                    var categoriasResult = categoriaBusiness.GetAll();

                    if (categoriasResult.HasError)
                    {
                        Console.WriteLine($"ERROR: {categoriasResult.Message}");
                    }
                    else
                    {
                        foreach (var cat in categoriasResult.Categorias)
                        {
                            Console.WriteLine("Id: " + cat.categoriaId + ", Nombre: " + cat.nombre);
                        }
                    }
                    Volver();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el Id de la Categoria para actualizar: ");
                    int idBusquedaAct = Convert.ToInt32(Console.ReadLine());
                    Categoria categoriaAbuscarAct = categoriaBusiness.GetAsync(idBusquedaAct);
                    Console.WriteLine("Ingrese el nuevo nombre de la Categoria: ");
                    categoriaAbuscarAct.nombre = Console.ReadLine();
                    categoriaBusiness.UpdateAsync(categoriaAbuscarAct);
                    Console.WriteLine($"Nuevo nombre: {categoriaAbuscarAct.nombre}");
                    Volver();
                    break;
                case 4:
                    Console.WriteLine("Ingrese el Id de la Categoria para borrar: ");
                    int idBusquedaBorrar = Convert.ToInt32(Console.ReadLine());
                    categoriaBusiness.DeleteAsync(idBusquedaBorrar);
                    Console.WriteLine("Categoria borrada.");
                    Volver();
                    break;
            }
            break;
        case 3:
            //Productos
            Console.WriteLine("Indique la acción que desea realizar: ");
            Console.WriteLine("1) Crear un nuevo Producto");
            Console.WriteLine("2) Listar los Productos que existen en el sistema");
            Console.WriteLine("3) Actualizar el nombre de un Producto que existe en el sistema");
            Console.WriteLine("4) Borrar un Producto");

            int eleccionProductos = Convert.ToInt32(Console.ReadLine());

            switch (eleccionProductos)
            {
                case 1:
                    //Creacion Producto
                    try
                    {
                        Console.WriteLine("Ingrese el nombre del nuevo Producto: ");
                        string nuevoProductoNombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el id de la Categoria del nuevo Producto: ");
                        int nuevoProductoCatId = Convert.ToInt32(Console.ReadLine());

                        if (nuevoProductoNombre != "" || nuevoProductoNombre != null
                            && nuevoProductoCatId != 0 || nuevoProductoNombre != null)
                        {
                            productoBusiness.CreateProducto(nuevoProductoNombre, nuevoProductoCatId);
                            Console.WriteLine($"Nuevo producto: {nuevoProductoNombre}.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo crear el nuevo Producto.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 2:
                    var productosResult = productoBusiness.GetAll();

                    if (productosResult.HasError)
                    {
                        Console.WriteLine($"ERROR: {productosResult.Message}");
                    }
                    else
                    {
                        foreach (var prod in productosResult.Productos)
                        {
                            Console.WriteLine("Id: " + prod.productoId + ", Nombre: " + prod.nombre);
                        }
                    }
                    Volver();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el Id del Producto para actualizar: ");
                    int idBusquedaAct = Convert.ToInt32(Console.ReadLine());
                    Producto productoAbuscarAct = productoBusiness.GetAsync(idBusquedaAct);
                    Console.WriteLine("Ingrese el nuevo nombre del Producto: ");
                    productoAbuscarAct.nombre = Console.ReadLine();
                    productoBusiness.UpdateAsync(productoAbuscarAct);
                    Console.WriteLine($"Nuevo nombre: {productoAbuscarAct.nombre}");
                    Volver();
                    break;
                case 4:
                    Console.WriteLine("Ingrese el Id del Producto para borrar: ");
                    int idBusquedaBorrar = Convert.ToInt32(Console.ReadLine());
                    productoBusiness.DeleteAsync(idBusquedaBorrar);
                    Console.WriteLine("Producto borrado.");
                    Volver();
                    break;
            }
            break;
        case 4:
            //Compras
            Console.WriteLine("Indique la acción que desea realizar: ");
            Console.WriteLine("1) Crear una nueva Compra");
            Console.WriteLine("2) Listar las Compras que existen en el sistema");
            Console.WriteLine("3) Actualizar la cantidad de una Compra que existe en el sistema");
            Console.WriteLine("4) Borrar una Compra");

            int eleccionCompras = Convert.ToInt32(Console.ReadLine());

            switch (eleccionCompras)
            {
                case 1:
                    //Creacion Compra
                    try
                    {
                        Console.WriteLine("Ingrese el id del Producto correspondiente a la nueva Compra: ");
                        int nuevaCompraProductoId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la cantidad comprada: ");
                        int nuevaCompraCantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Indique el usuario que realizo la Compra: ");
                        int nuevaCompraUsuarioId = Convert.ToInt32(Console.ReadLine());

                        if (nuevaCompraProductoId != 0 || nuevaCompraProductoId != null
                            && nuevaCompraCantidad != 0 || nuevaCompraCantidad != null
                            && nuevaCompraUsuarioId != 0 || nuevaCompraUsuarioId != null)
                        {
                            compraBusiness.CreateCompra(DateTime.Now, nuevaCompraProductoId, nuevaCompraCantidad, nuevaCompraUsuarioId);
                            Console.WriteLine($"Compra agregada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo crear la nueva Compra.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 2:
                    var compraResult = compraBusiness.GetAll();

                    if (compraResult.HasError)
                    {
                        Console.WriteLine($"ERROR: {compraResult.Message}");
                    }
                    else
                    {
                        foreach (var com in compraResult.Compras)
                        {
                            Console.WriteLine("Id: " + com.compraId + ", Cantidad: " + com.cantidad);
                        }
                    }
                    Volver();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el Id de la Compra para actualizar: ");
                    int idBusquedaAct = Convert.ToInt32(Console.ReadLine());
                    Compra compraAbuscarAct = compraBusiness.GetAsync(idBusquedaAct);
                    Console.WriteLine("Ingrese la nueva cantidad comprada de la Compra: ");
                    compraAbuscarAct.cantidad = Convert.ToInt32(Console.ReadLine());
                    compraBusiness.UpdateAsync(compraAbuscarAct);
                    Console.WriteLine($"Nueva cantidad: {compraAbuscarAct.cantidad}");
                    Volver();
                    break;
                case 4:
                    Console.WriteLine("Ingrese el Id de la Compra para borrar: ");
                    int idBusquedaBorrar = Convert.ToInt32(Console.ReadLine());
                    compraBusiness.DeleteAsync(idBusquedaBorrar);
                    Console.WriteLine("Compra borrada.");
                    Volver();
                    break;
            }
            break;

        case 5:
            //Ventas
            Console.WriteLine("Indique la acción que desea realizar: ");
            Console.WriteLine("1) Crear una nueva Venta");
            Console.WriteLine("2) Listar las Ventas que existen en el sistema");
            Console.WriteLine("3) Actualizar la cantidad de una Venta que existe en el sistema");
            Console.WriteLine("4) Borrar una Venta");

            int eleccionVenta = Convert.ToInt32(Console.ReadLine());

            switch (eleccionVenta)
            {
                case 1:
                    //Creacion Venta
                    try
                    {
                        Console.WriteLine("Ingrese el id del Producto correspondiente a la nueva Venta: ");
                        int nuevaVentaProductoId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese la cantidad vendida: ");
                        int nuevaVentaCantidad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Indique el usuario que realizo la Venta: ");
                        int nuevaVentaUsuarioId = Convert.ToInt32(Console.ReadLine());

                        if (nuevaVentaProductoId != 0 || nuevaVentaProductoId != null
                            && nuevaVentaCantidad != 0 || nuevaVentaCantidad != null
                            && nuevaVentaUsuarioId != 0 || nuevaVentaUsuarioId != null)
                        {
                            ventaBusiness.CreateVenta(DateTime.Now, nuevaVentaProductoId, nuevaVentaCantidad, nuevaVentaUsuarioId);
                            Console.WriteLine($"Venta agregada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo crear la nueva Venta.");
                        Console.WriteLine(ex.Message);
                    }
                    Volver();
                    break;
                case 2:
                    var ventaResult = ventaBusiness.GetAll();

                    if (ventaResult.HasError)
                    {
                        Console.WriteLine($"ERROR: {ventaResult.Message}");
                    }
                    else
                    {
                        foreach (var ven in ventaResult.Ventas)
                        {
                            Console.WriteLine("Id: " + ven.ventaId + ", Cantidad: " + ven.cantidad);
                        }
                    }
                    Volver();
                    break;
                case 3:
                    Console.WriteLine("Ingrese el Id de la Venta para actualizar su cantidad: ");
                    int idBusquedaAct = Convert.ToInt32(Console.ReadLine());
                    Venta ventaAbuscarAct = ventaBusiness.GetAsync(idBusquedaAct);
                    Console.WriteLine("Ingrese la nueva cantidad vendida de la Venta: ");
                    ventaAbuscarAct.cantidad = Convert.ToInt32(Console.ReadLine());
                    ventaBusiness.UpdateAsync(ventaAbuscarAct);
                    Console.WriteLine($"Nueva cantidad: {ventaAbuscarAct.cantidad}");
                    Volver();
                    break;
                case 4:
                    Console.WriteLine("Ingrese el Id de la Venta para borrar: ");
                    int idBusquedaBorrar = Convert.ToInt32(Console.ReadLine());
                    ventaBusiness.DeleteAsync(idBusquedaBorrar);
                    Console.WriteLine("Venta borrada.");
                    Volver();
                    break;
            }

            break;
    }
}

Console.WriteLine("End!");

static void ListUsuarios(UsuarioBusiness usuarioBusiness)
{
    var usuariosResult = usuarioBusiness.GetAll();

    if (usuariosResult.HasError)
    {
        Console.WriteLine($"ERROR: {usuariosResult.Message}");
    }
    else
    {
        foreach (var usuar in usuariosResult.Usuarios)
        {
            Console.WriteLine("Id: " + usuar.usuarioId + ", Nombre: " + usuar.ToString());
        }
    }
}
void Volver()
{
    Console.WriteLine("¿Desea volver al menú principal?");
    Console.WriteLine("Si; ingrese 1");
    Console.WriteLine("No; ingrese 2");
    int eleccionVolver = Convert.ToInt32(Console.ReadLine());
    if (eleccionVolver == 2)
    {
        volverPrincipal = false;
    }
}

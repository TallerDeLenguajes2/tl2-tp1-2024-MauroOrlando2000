using System.Reflection;
using cadeteria;

Cadeteria cadeteria = new Cadeteria();
Pedido? PedidoSeleccionado = null;

bool anda = false;
string stringNum;
int num = 0, numeroPedido=0;

while(!anda || num < 1 || num > 2)
{
    Console.WriteLine("Desea cargar los datos por archivo CSV o JSON? (1=CSV, 2=JSON)");
    stringNum = Console.ReadLine();
    anda = int.TryParse(stringNum, out num);
    if(!anda || num < 1 || num > 2)
    {
        Console.WriteLine("Numero invalido");
    }
}
if(num == 1)
{
    AccesoADatos Acceso = new AccesoCSV();
    Acceso.cargarDatos(cadeteria);
}
else
{
    AccesoADatos Acceso = new AccesoJSON();
    Acceso.cargarDatos(cadeteria);
}

anda = false;
while(!anda)
{
    Console.WriteLine("Que desea hacer?\n1.Seleccionar un pedido\n2.Crear un pedido\n3.Re/Asignar pedido a cadete\n4.Cambiar el estado del pedido seleccionado\nOtro.Finalizar jornada");
    stringNum = Console.ReadLine();
    anda = int.TryParse(stringNum, out num);
    if(!anda)
    {
        Console.WriteLine("Numero invalido");
    }

    switch(num)
    {
        case 1: if(cadeteria.MostrarListaPedidos().Count == 0)
        {
            Console.WriteLine("No hay pedidos que seleccionar\n");
            anda = false;
        }
        else
        {
            anda = false;
            foreach(Pedido seleccionado in cadeteria.MostrarListaPedidos())
            {
                seleccionado.VerPedido();
                seleccionado.VerDireccionCliente();
                if(seleccionado.DarIdCadete() > -1)
                {
                    Console.WriteLine("Pedido ya asignado a cadete ID: " + PedidoSeleccionado.DarIdCadete());
                }
                Console.WriteLine("\n");
            }
            while(!anda)
            {
                Console.WriteLine("Elija el pedido (Escriba el numero del pedido)");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 0 || num > (cadeteria.MostrarListaPedidos().Count-1))
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            foreach(Pedido pedido in cadeteria.MostrarListaPedidos())
            {
                if(pedido.DarIDPedido() == num)
                {
                    PedidoSeleccionado = pedido;
                    break;
                }
            }
        }
        anda = false;
        break;

        case 2: if(cadeteria.MostrarListaPedidos().Count == 0)
        {
            cadeteria.CrearPedido(null, numeroPedido++);
        }
        else
        {
            anda = false;
            while(!anda)
            {
                Console.WriteLine("Ingrese que desea pedir");
                stringNum = Console.ReadLine();
                if(stringNum != null)
                {
                    anda = true;
                }
            }
            cadeteria.CrearPedido(stringNum, numeroPedido++);
        }
        anda = false;
        break;
        
        case 3: if(PedidoSeleccionado == null)
        {
            Console.WriteLine("No hay pedido seleccionado. Seleccione un pedido\n");
        }
        else
        {
            if(PedidoSeleccionado.DarEstadoDelPedido() != 'E')
            {
                anda = false;
                while(!anda)
                {
                    PedidoSeleccionado.VerPedido();
                    foreach(Cadete cadete in cadeteria.MostrarListaCadetes())
                    {
                        cadete.MostrarCadete();
                    }
                    if(PedidoSeleccionado.DarIdCadete() > -1)
                    {
                        Console.WriteLine("Pedido ya asignado a cadete ID: " + PedidoSeleccionado.DarIdCadete());
                    }
                    Console.WriteLine("A que cadete quiere asignarle este pedido (Ingrese el ID)");
                    stringNum = Console.ReadLine();
                    anda = int.TryParse(stringNum, out num);
                    if(!anda || num < 0 || num > 4)
                    {
                        Console.WriteLine("Numero invalido");
                    }
                }
                cadeteria.AsignarCadeteAPedido(num, PedidoSeleccionado.DarIDPedido());
            }
            else
            {
                Console.WriteLine("Pedido seleccionado ya entregado.\n");
            }
        }
        anda = false;
        break;
        
        case 4: if(PedidoSeleccionado == null)
        {
            Console.WriteLine("No hay pedido seleccionado. Seleccione un pedido\n");
        }
        else
        {
            char charEstado;
            switch(PedidoSeleccionado.DarEstadoDelPedido())
            {
                case 'P': charEstado = 'P';
                while (charEstado != 'E' && charEstado != 'C')
                {
                    Console.WriteLine("A que Estado desea cambiar? ('C' = en camino, 'E' = entregado)");
                    charEstado = Console.ReadKey().KeyChar;
                    if(charEstado == null || (charEstado != 'E' && charEstado != 'C'))
                    {
                        Console.WriteLine("Valor inválido");
                    }
                }
                PedidoSeleccionado.CambiarEstado(charEstado);
                break;

                case 'C': charEstado = 'C';
                while (charEstado != 'P' && charEstado != 'E')
                {
                    Console.WriteLine("A que Estado desea cambiar? ('P' = en proceso, 'E' = entregado)");
                    charEstado = Console.ReadKey().KeyChar;
                    if(charEstado == null || (charEstado != 'P' && charEstado != 'E'))
                    {
                        Console.WriteLine("Valor inválido");
                    }
                }
                PedidoSeleccionado.CambiarEstado(charEstado);
                break;

                default: Console.WriteLine("Pedido ya entregado. No se puede cambiar su estado.\n");
                break;
            }
        }
        anda = false;
        break;

        default: cadeteria.GenerarInforme();
        anda = true;
        break;
    }
}
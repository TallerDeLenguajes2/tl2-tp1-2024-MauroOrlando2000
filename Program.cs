using cadeteria;

Cadeteria cadeteria = new Cadeteria();
Pedido? PedidoSeleccionado = null;

bool anda = false;
string stringNum;
int num = 0, numeroPedido=0;
while(!anda)
{
    Console.WriteLine("Que desea hacer?\n1.Seleccionar un pedido\n2.Crear un pedido\n3.Re/Asignar pedido a cadete\n4.Cambiar pedido de estado\nOtro.Finalizar jornada");
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
        anda = false;
        break;
        
        case 4: if(PedidoSeleccionado == null)
        {
            Console.WriteLine("No hay pedido seleccionado");
        }
        else
        {
            PedidoSeleccionado.CambiarEstado();
        }
        anda = false;
        break;

        default: cadeteria.GenerarInforme();
        anda = true;
        break;
    }
}
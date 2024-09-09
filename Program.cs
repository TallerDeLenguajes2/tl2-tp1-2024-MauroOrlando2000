using cadeteria;

Cadeteria cadeteria = new Cadeteria();

bool anda = false;
string stringNum;
int num = 0;
while(!anda)
{
    Console.WriteLine("Que desea hacer?\n1.Seleccionar un pedido\n2.Crear un pedido\n3.Asignar pedido a cadete\n4.Cambiar pedido de estado\n5.Reasignar pedido a otro cadete\nOtro.Finalizar jornada");
    stringNum = Console.ReadLine();
    anda = int.TryParse(stringNum, out num);
    if(!anda)
    {
        Console.WriteLine("Numero invalido");
    }

    switch(num)
    {
        case 1: if((cadeteria.MostrarListaPedidos()).Count() == 0)
        {
            Console.WriteLine("No hay pedidos que seleccionar");
            anda = false;
        }
        else
        {
            anda = false;
            int i=0;
            foreach(Pedido seleccionado in cadeteria.MostrarListaPedidos())
            {
                Console.WriteLine("Pedido " + ++i);
                seleccionado.VerPedido();
                seleccionado.VerDireccionCliente();
                Console.WriteLine("\n");
            }
            while(!anda)
            {
                Console.WriteLine("Elija el pedido");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 0 || num > i)
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            pedido = list[num-1];
        }
        anda = false;
        break;

        case 2: Pedido nuevo;
        if((cadeteria.MostrarListaPedidos()).Count() == 0)
        {
            nuevo = new Pedido();
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
            Pedido nuevo = new Pedido(stringNum);
            cadeteria.CrearPedido(nuevo);
        }
        break;
        
        case 3: if(pedido == null)
        {
            Console.WriteLine("No hay pedido que asignar. Seleccione un pedido");
        }
        else
        {
            anda = false;
            while(!anda)
            {
                pedido.VerDireccionCliente();
                cadeteria.MostrarListaCadetes();
                Console.WriteLine("A que cadete quiere asignarle este pedido (Ingrese el ID)");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 0 || num > 4)
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            cadeteria.AsignarPedido(pedido, num);
        }
        anda = false;
        break;
        
        case 4: if(pedido == null)
        {
            Console.WriteLine("No hay pedido seleccionado");
        }
        else
        {
            pedido.CambiarEstado();
        }
        anda = false;
        break;

        case 5: if(pedido == null)
        {
            Console.WriteLine("No hay pedido que re-asignar. Seleccione un pedido");
        }
        else
        {
            anda = false;
            while(!anda)
            {
                pedido.VerDireccionCliente();
                cadeteria.MostrarListaCadetes();
                Console.WriteLine("A que cadete quiere re-asignarle este pedido (Ingrese el ID)");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 0 || num > 4)
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            int IDNuevo = cadeteria.Pertenece(pedido);
            if(IDNuevo >= 0)
            {
                cadeteria.Reasignar(pedido, num, IDNuevo);
            }
        }
        anda = false;
        break;

        default: cadeteria.GenerarInforme();
        anda = true;
        break;
    }
}
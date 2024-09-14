using System.Reflection;
using cadeteria;

Cadeteria cadeteria = new Cadeteria();
Pedido? PedidoSeleccionado = null;

bool anda = false;
string stringNum;
int num = 0, numeroPedido=1;

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
                Console.WriteLine(seleccionado.VerPedido());
                Console.WriteLine(seleccionado.VerDireccionCliente());
                if(seleccionado.DarIdCadete() > -1)
                {
                    Console.WriteLine($"Pedido ya asignado a cadete ID: {PedidoSeleccionado.DarIdCadete()}");
                }
                Console.WriteLine("\n");
            }
            while(!anda)
            {
                Console.WriteLine("Elija el pedido (Escriba el numero del pedido)");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 1 || num > (cadeteria.MostrarListaPedidos().Count))
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

        case 2: anda = false;
        string obs = "";
        while(obs == "")
        {
            Console.WriteLine("Ingrese que desea pedir");
            obs = Console.ReadLine();
            if(obs == "")
            {
                Console.WriteLine("Debe ingresar algo para pedir\n");
            }
        }
        anda = false;
        string nombre = "", direccion = "", referencia = "";
        double telefono = 0;

        while(nombre == "")
        {
            Console.WriteLine("Ingrese el nombre del cliente");
            nombre = Console.ReadLine();
            if(nombre == "")
            {
                Console.WriteLine("Debe ingresar un nombre\n");
            }
        }
        while(direccion == "")
        {
            Console.WriteLine("Ingrese la direccion del cliente");
            direccion = Console.ReadLine();
            if(direccion == "")
            {
                Console.WriteLine("Debe ingresar una direccion\n");
            }
        }
        while(!anda || telefono < 999999999 || telefono > 10000000000)
        {
            Console.WriteLine("Ingrese el telefono del cliente");
            stringNum = Console.ReadLine();
            anda = double.TryParse(stringNum, out telefono);
            if(!anda || telefono < 999999999 || telefono > 10000000000)
            {
                Console.WriteLine("Valor inválido");
            }
        }
        Console.WriteLine("Alguna referencia para ubicar la direccion dada?");
        referencia = Console.ReadLine();
        if(referencia == "")
        {
            referencia = "Ninguna";
        }
        if(cadeteria.CrearPedido(numeroPedido++, obs, nombre, direccion, telefono, referencia))
        {
            Console.WriteLine("Pedido satisfactoriamente creado\n");
        }
        else
        {
            Console.WriteLine("Pedido no creado\n");
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
                Console.WriteLine(PedidoSeleccionado.VerPedido());
                foreach(Cadete cadete in cadeteria.MostrarListaCadetes())
                {
                    Console.WriteLine(cadete.MostrarCadete());
                }
                if(PedidoSeleccionado.DarIdCadete() > -1)
                {
                    Console.WriteLine($"Pedido ya asignado a cadete ID: {PedidoSeleccionado.DarIdCadete()}");
                }
                Console.WriteLine("A que cadete quiere asignarle este pedido (Ingrese el ID)");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out num);
                if(!anda || num < 0 || num > 4)
                {
                    Console.WriteLine("Numero invalido");
                }
            }
            if(cadeteria.AsignarCadeteAPedido(num, PedidoSeleccionado.DarIDPedido()))
            {
                Console.WriteLine("Pedido asignado satisfactoriamente\n");
            }
            else
            {
                Console.WriteLine("Pedido fallo en asignar\n");
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
                Console.WriteLine(PedidoSeleccionado.CambiarEstado(charEstado));
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
                Console.WriteLine(PedidoSeleccionado.CambiarEstado(charEstado));
                break;

                default: Console.WriteLine("Pedido ya entregado. No se puede cambiar su estado.\n");
                break;
            }
        }
        anda = false;
        break;

        default: Console.WriteLine(cadeteria.GenerarInforme());
        anda = true;
        break;
    }
}
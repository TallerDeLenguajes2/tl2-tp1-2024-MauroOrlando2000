namespace cadeteria;

public class Pedido{
    private int numero; //Se asigna automaticamente comenzando por el 0 y subiendo 1 por cada pedido nuevo
    private string observacion;
    private char estado; //P = en proceso, C = En camino, E = Entregado
    private Cliente cliente;
    private int IDCadete; //-1 si no tiene cadete. >=0 si tiene cadete

    public Pedido(int num)
    {
        numero = num;
        observacion = "Pizza";
        estado = 'P';
        cliente = new Cliente();
        IDCadete = -1;
    }

    public Pedido(int num, string obs)
    {
        numero = num;
        observacion = obs;
        estado = 'P';
        cliente = new Cliente(true);
        IDCadete = -1;
    }

    public void VerDireccionCliente()
    {
        cliente.MostrarDireccion();
    }

    public void VerDatosCliente()
    {
        cliente.MostrarDatos();
    }

    public void VerPedido()
    {
        Console.WriteLine("Pedido: " + numero);
        if(observacion == null)
        {
            Console.WriteLine("Ninguna");
        }
        else
        {
            Console.WriteLine("Observacion: " + observacion + "\n");
        }
        
    }

    public char DarEstadoDelPedido()
    {
        return estado;
    }

    public void CambiarEstado(char charEstado)
    {
        estado = charEstado;
        if(estado == 'P')
        {
            Console.WriteLine($"\nPedido {numero} en proceso\n");
        }
        else if(estado == 'C')
        {
            Console.WriteLine($"\nPedido {numero} en camino\n");
        }
        else
        {
            Console.WriteLine($"\nPedido {numero} entregado\n");
        }
    }

    public int DarIDPedido()
    {
        return numero;
    }

    public void AsginarCadete(int IDAsignar)
    {
        if(estado != 'E')
        {
            IDCadete = IDAsignar;
        }
        else
        {
            Console.WriteLine("Pedido entregado. No hay porque asignarlo a un nuevo cadete\n");
        }
    }

    public int DarIdCadete()
    {
        return IDCadete;
    }
}

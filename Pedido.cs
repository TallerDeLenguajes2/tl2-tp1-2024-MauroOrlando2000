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
        Console.WriteLine("Observacion: " + observacion);
    }

    public char DarEstadoDelPedido()
    {
        return estado;
    }

    public void CambiarEstado()
    {
        if(estado == 'P')
        {
            estado = 'C';
            Console.WriteLine("Pedido en camino\n");
        }
        else if(estado == 'C')
        {
            estado = 'E';
            Console.WriteLine("Pedido entregado\n");
        }
    }

    public int DarIDPedido()
    {
        return numero;
    }

    public void AsginarCadete(int IDAsignar)
    {
        IDCadete = IDAsignar;
    }

    public int DarIdCadete()
    {
        return IDCadete;
    }
}

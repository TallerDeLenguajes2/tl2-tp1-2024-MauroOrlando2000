namespace cadeteria;

public class Pedido{
    private int numero;
    private string? observacion;
    private char estado; //P = en proceso, C = En camino, E = Entregado
    private Cliente cliente;
    private int IDCadete;
    int i=0;

    public Pedido()
    {
        numero = ++i;
        observacion = null;
        estado = 'P';
        cliente = new Cliente();
        IDCadete = -1;
    }

    public Pedido(string? obs)
    {
        numero = ++i;
        observacion = obs;
        estado = 'P';
        cliente = new Cliente(true);
        IDCadete = -1
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
        Console.WriteLine("Observacion: " + observacion);
    }

    public char VerEstadoDelPedido()
    {
        return estado;
    }

    public void CambiarEstado()
    {
        if(estado == 'P')
        {
            estado = 'C';
        }
        else if(estado == 'C')
        {
            estado = 'E';
        }
    }
}

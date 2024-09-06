namespace cadeteria;

public class Pedido{
    private int numero;
    private string? observacion;
    private char estado; //P = en proceso, C = En camino, E = Entregado
    private Cliente cliente;
    int i=0;
    public Pedido()
    {
        numero = ++i;
        observacion = null;
        estado = 'P';
        cliente = new Cliente();
    }
    public Pedido(string? obs)
    {
        numero = ++i;
        observacion = obs;
        estado = 'P';
        cliente = new Cliente(true);
    }
    public void VerDireccionCliente()
    {
        cliente.MostrarDireccion();
    }
    public void VerDatosCliente()
    {
        cliente.MostrarDatos();
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

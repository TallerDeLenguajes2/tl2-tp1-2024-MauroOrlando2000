namespace cadeteria;

public class Pedido{
    enum EstadosPedidos {EnProceso, EnCamino, Entregado}
    private int numero;
    private string? observacion;
    private EstadosPedidos estado;
    private Cliente cliente;
    int i=0;
    public Pedido()
    {
        numero = ++i;
        observacion = null;
        estado = EstadosPedidos.EnProceso;
        cliente = new Cliente();
    }
    public Pedido(string obs)
    {
        numero = ++i;
        observacion = obs;
        estado = EstadosPedidos.EnProceso;
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
    public void VerEstadoDelPedido()
    {
        if(estado == EstadosPedidos.EnProceso)
        {
            Console.WriteLine("Pedido en proceso");
        }
        else if(estado == EstadosPedidos.EnCamino)
        {
            Console.WriteLine("Pedido en camino");
        }
        else
        {
            Console.WriteLine("Pedido entregado");
        }
    }
}

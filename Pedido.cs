namespace cadeteria;

public class Pedido{
    enum EstadosPedidos {EnProceso, EnCamino, Entregado}
    private int numero;
    private string? observacion;
    private EstadosPedidos estado;
    private Cliente cliente = new Cliente();
    public void VerDireccionCliente(){}
    public void VerDatosCliente(){}
}

namespace cadeteria;

public class Pedido{
    private int numero; //Se asigna automaticamente comenzando por el 0 y subiendo 1 por cada pedido nuevo
    private string observacion;
    private char estado; //P = en proceso, C = En camino, E = Entregado
    private Cliente cliente;
    private int IDCadete; //-1 si no tiene cadete. >=0 si tiene cadete

    public Pedido(int num, string obs, string name, string address, double phone, string? reference)
    {
        numero = num;
        observacion = obs;
        estado = 'P';
        cliente = new Cliente(name, address, phone, reference);
        IDCadete = -1;
    }

    public string VerDireccionCliente()
    {
        return cliente.MostrarDireccion();
    }

    public string VerDatosCliente()
    {
        return cliente.MostrarDatos();
    }

    public string VerPedido()
    {
        string stringPedido = "Pedido " + numero + "\n" + "Observacion: " + observacion + "\n";
        return stringPedido;
    }

    public char DarEstadoDelPedido()
    {
        return estado;
    }

    public string CambiarEstado(char charEstado)
    {
        if(estado == 'E')
        {
            return "\nPedido ya entregado\n";
        }
        else
        {
            estado = charEstado;
            if(estado == charEstado)
            {
                return "Pedido cambiado de estado satisfactoriamente";
            }
            else
            {
                return "Pedido fallo al cambiar de estado";
            }
        }
    }

    public int DarIDPedido()
    {
        return numero;
    }

    public bool AsginarCadete(int IDAsignar)
    {
        if(estado != 'E')
        {
            IDCadete = IDAsignar;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int DarIdCadete()
    {
        return IDCadete;
    }
}

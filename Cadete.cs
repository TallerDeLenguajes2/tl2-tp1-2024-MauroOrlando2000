using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private long telefono;
    private List<Pedido> listadoPedidos;
    public Cadete(int NuevoId, string NuevoNombre, string NuevoDireccion, long NuevoTelefono)
    {
        id = NuevoId;
        nombre = NuevoNombre;
        direccion = NuevoDireccion;
        telefono = NuevoTelefono;
        listadoPedidos = new List<Pedido>();
    }
    public void JornalACobrar(){}
}

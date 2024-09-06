using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public void JornalACobrar()
    {
        int Jornal, contador;
        contador = listadoPedidos.Count();
        Jornal = contador * 500;
        Console.WriteLine("Jornal a cobrar: $" + Jornal);
    }
}

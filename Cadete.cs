using System.Collections;
using System.Collections.Generic;

namespace cadeteria;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private Double telefono;

    public Cadete(int NuevoId, string NuevoNombre, string NuevoDireccion, Double NuevoTelefono)
    {
        id = NuevoId;
        nombre = NuevoNombre;
        direccion = NuevoDireccion;
        telefono = NuevoTelefono;
        listadoPedidos = new List<Pedido>();
    }

    public int JornalACobrar()
    {
        int Jornal=0;
        foreach(Pedido pedido in listadoPedidos)
        {
            if(pedido.VerEstadoDelPedido() == 'E')
            {
                Jornal += 500;
            }
        }
        return Jornal;
    }

    public void MostrarCadete()
    {
        Console.WriteLine($"ID: {id}\nNombre: {nombre}\nDireccion: {direccion}\nTelefono: {telefono}\n");
    }

    public void AsignarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
    }

    public int DarID()
    {
        return id;
    }

    public void BorrarPedido(Pedido pedido)
    {
        listadoPedidos.Remove(pedido);
    }
    
    public bool Pertenece(Pedido pedido)
    {
        bool anda = false;
        foreach(Pedido pedidoAux in listadoPedidos)
        {
            if(pedidoAux == pedido)
            {
                anda = true;
            }
        }
        return anda;
    }
}

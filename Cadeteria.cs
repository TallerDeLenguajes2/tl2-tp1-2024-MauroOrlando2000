using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private Double telefono;
    private List<Pedido> listadoPedidos = new List<Pedido>();
    private List<Cadete> listadoCadetes = new List<Cadete>();

    public Cadeteria()
    {
        cargaCsv cargar = new cargaCsv();
        string ruta = "cadeteria.csv";
        using(StreamReader FileRead = new StreamReader(ruta))
        {
            while(!FileRead.EndOfStream)
            {
                var line = FileRead.ReadLine();
                var valores = line.Split(',');
                nombre = Convert.ToString(valores[0]);
                telefono = Convert.ToDouble(valores[1]);
            }  
        }
        listadoCadetes = cargar.cargaCadetes();
    }

    public List<Pedido> MostrarListaPedidos()
    {
        return listadoPedidos;
    }

    public List<Cadete> MostrarListaCadetes()
    {
        return listadoCadetes;
    }

    public void CrearPedido(string? observacion, int IDPedido)
    {
        Pedido nuevo;
        if(observacion == null)
        {
            nuevo = new Pedido(IDPedido);
        }
        else
        {
            nuevo = new Pedido(IDPedido, observacion);
        }
        listadoPedidos.Add(nuevo);
    }

    public void AsignarCadeteAPedido(int IDCadete, int IDPedido)
    {
        foreach(Pedido pedido in listadoPedidos)
        {
            if(pedido.DarIDPedido() == IDPedido)
            {
                pedido.AsginarCadete(IDCadete);
            }
        }
    }

    public int JornalACobrar(int IDCadete)
    {
        int Jornal=0;
        foreach(Pedido pedido in listadoPedidos)
        {
            if(pedido.DarIdCadete() == IDCadete && pedido.DarEstadoDelPedido() == 'E')
            {
                Jornal += 500;
            }
        }
        return Jornal;
    }

    public void GenerarInforme()
    {
        int Total=0;
        float contador=0, divisor=0, promedio;
        foreach(Cadete cadete in listadoCadetes)
        {
            int TotalCadete = JornalACobrar(cadete.DarID());
            Total += TotalCadete;
            Console.WriteLine($"Cantidad de pedidos entregados: {TotalCadete/500}\nTotal cadete {cadete.DarID()}: {TotalCadete}\n");
            contador = contador + (TotalCadete / 500);
            divisor++;
        }
        promedio = contador / divisor;
        Console.WriteLine("Total recaudado: " + Total);
        Console.WriteLine("Promedio de envios por cliente: " + promedio);
    }
}
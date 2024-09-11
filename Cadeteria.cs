using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json.Nodes;
using System.Text.Json;
namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private Double telefono;
    private List<Pedido> listadoPedidos;
    private List<Cadete> listadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

    public Cadeteria(int num)
    {
        ListadoPedidos = new List<Pedido>();
        ListadoCadetes = new List<Cadete>();

        if(num == 1)
        {
            string ruta = "cadeteria.csv";
            using(StreamReader FileRead = new StreamReader(ruta))
            {
                while(!FileRead.EndOfStream)
                {
                    var line = FileRead.ReadLine();
                    var valores = line.Split(',');
                    Nombre = Convert.ToString(valores[0]);
                    Telefono = Convert.ToDouble(valores[1]);
                }  
            }
            AccesoCSV CSV = new AccesoCSV();
            ListadoCadetes = CSV.cargaCadetes();
        }
        else
        {
            string ruta = "cadeteria.json";
            var FileRead = new StreamReader(ruta);
            var Json = FileRead.ReadToEnd();
            Cadeteria cadeteria1 = JsonSerializer.Deserialize<Cadeteria>(Json);
            nombre = cadeteria1.Nombre;
            telefono = cadeteria1.Telefono;
            AccesoJSON JSONCadetes = new AccesoJSON();
            listadoCadetes = JSONCadetes.cargarCadetes();
        }
    }

    public List<Pedido> MostrarListaPedidos()
    {
        return ListadoPedidos;
    }

    public List<Cadete> MostrarListaCadetes()
    {
        return ListadoCadetes;
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
        ListadoPedidos.Add(nuevo);
    }

    public void AsignarCadeteAPedido(int IDCadete, int IDPedido)
    {
        foreach(Pedido pedido in ListadoPedidos)
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
        foreach(Pedido pedido in ListadoPedidos)
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
        foreach(Cadete cadete in ListadoCadetes)
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
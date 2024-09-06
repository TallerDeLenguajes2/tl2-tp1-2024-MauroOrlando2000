using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private Double telefono;
    private List<Cadete> listadoCadetes;
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
    public List<Cadete> MostrarListaCadetes()
    {
        return listadoCadetes;
    }
    public void AsignarPedido(Pedido pedido, int ID)
    {
        foreach(Cadete cadete in listadoCadetes)
        {
            if(cadete.DarID() == ID)
            {
                cadete.AsignarPedido(pedido);
                break;
            }
        }
    }
    public void Reasignar(Pedido pedido, int IDIngreso, int IDBorrar)
    {
        foreach(Cadete cadete in listadoCadetes)
        {
            if(cadete.DarID() == IDIngreso)
            {
                cadete.AsignarPedido(pedido);
            }
            else
            {
                if(cadete.DarID() == IDBorrar)
                {
                    cadete.BorrarPedido(pedido);
                }
            }
        }
    }
    public int Pertenece(Pedido pedido)
    {
        foreach(Cadete cadete in listadoCadetes)
        {
            if(cadete.Pertenece(pedido))
            {
                return cadete.DarID();
            }
        }
        return -1;
    }
    public void GenerarInforme()
    {
        int Total=0;
        float contador=0, divisor=0, promedio;
        foreach(Cadete cadete in listadoCadetes)
        {
            int TotalCadete = cadete.JornalACobrar();
            Total += TotalCadete;
            Console.WriteLine($"Total cadete {cadete.DarID()}: {TotalCadete}");
            contador = contador + (TotalCadete / 500);
            divisor++;
        }
        promedio = contador / divisor;
        Console.WriteLine("Total recaudado: " + Total);
        Console.WriteLine("Promedio de envios por cliente: " + promedio);
    }
}
using System.Collections;
using System.Collections.Generic;

namespace cadeteria;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private double telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }

    public Cadete()
    {
        Id = 0;
        Nombre = "a";
        Direccion = "San Pedro";
        Telefono = 0;
    }

    public Cadete(int NuevoId, string NuevoNombre, string NuevoDireccion, double NuevoTelefono)
    {
        Id = NuevoId;
        Nombre = NuevoNombre;
        Direccion = NuevoDireccion;
        Telefono = NuevoTelefono;
    }

    public string MostrarCadete()
    {
        string aux = $"ID: {Id}\nNombre: {Nombre}\nDireccion: {Direccion}\nTelefono: {Telefono}\n";
        return aux;
    }

    public int DarID()
    {
        return Id;
    }
}

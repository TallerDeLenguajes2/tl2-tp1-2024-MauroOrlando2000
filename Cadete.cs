using System.Collections;
using System.Collections.Generic;

namespace cadeteria;

public class Cadete{
    private int id;
    private string nombre;
    private string direccion;
    private Double telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }

    public Cadete(int NuevoId, string NuevoNombre, string NuevoDireccion, Double NuevoTelefono)
    {
        Id = NuevoId;
        Nombre = NuevoNombre;
        Direccion = NuevoDireccion;
        Telefono = NuevoTelefono;
    }

    public void MostrarCadete()
    {
        Console.WriteLine($"ID: {Id}\nNombre: {Nombre}\nDireccion: {Direccion}\nTelefono: {Telefono}\n");
    }

    public int DarID()
    {
        return Id;
    }
}

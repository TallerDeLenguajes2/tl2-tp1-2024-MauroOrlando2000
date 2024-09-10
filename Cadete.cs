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
    }

    public void MostrarCadete()
    {
        Console.WriteLine($"ID: {id}\nNombre: {nombre}\nDireccion: {direccion}\nTelefono: {telefono}\n");
    }

    public int DarID()
    {
        return id;
    }
}

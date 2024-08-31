using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private long telefono;
    private List<Cadete> listadoCadetes;
    public Cadeteria(string NuevoNombre, long NuevoTelefono)
    {
        nombre = NuevoNombre;
        telefono = NuevoTelefono;
        listadoCadetes = new List<Cadete>();
    }
}
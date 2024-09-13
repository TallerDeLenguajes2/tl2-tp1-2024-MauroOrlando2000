using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace cadeteria;

public abstract class AccesoADatos{
    public abstract void cargarDatos(Cadeteria parametro);
    public abstract void cargarCadetes(Cadeteria parametro);
}

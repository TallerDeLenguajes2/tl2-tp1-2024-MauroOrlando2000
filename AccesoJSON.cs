using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
namespace cadeteria;

public class AccesoJSON : AccesoADatos{

    public override void cargarDatos(Cadeteria parametro)
    {
        string ruta = "cadeteria.json";
        using(var FileRead = new StreamReader(ruta))
        {
            var Json = FileRead.ReadToEnd();
            var nuevo = JsonSerializer.Deserialize<Cadeteria>(Json);
            parametro.Nombre = nuevo.Nombre;
            parametro.Telefono = nuevo.Telefono;
        }
        cargarCadetes(parametro);
    }

    public override void cargarCadetes(Cadeteria parametro)
    {
        string ruta = "cadetes.json";
        using(var FileRead = new StreamReader(ruta))
        {
            var Json = FileRead.ReadToEnd();
            var lista = JsonSerializer.Deserialize<List<Cadete>>(Json);
            parametro.ListadoCadetes.AddRange(lista);
        }
    }
}

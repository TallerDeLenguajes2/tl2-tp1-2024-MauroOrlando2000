using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cadeteria;

public class AccesoCSV : AccesoADatos{

    public override void cargarDatos(Cadeteria parametro)
    {
        string ruta = "cadeteria.csv";
        using(StreamReader FileRead = new StreamReader(ruta))
        {
            while(!FileRead.EndOfStream)
            {
                var line = FileRead.ReadLine();
                var valores = line.Split(',');
                parametro.Nombre = Convert.ToString(valores[0]);
                parametro.Telefono = Convert.ToDouble(valores[1]);
            }  
        }
        cargarCadetes(parametro);
    }
    
    public override void cargarCadetes(Cadeteria parametro)
    {
        string ruta = "cadetes.csv";
        using(var FileRead = new StreamReader(ruta))
        {
            while(!FileRead.EndOfStream)
            {
                var line = FileRead.ReadLine();
                var valores = line.Split(',');
                int id = Convert.ToInt16(valores[0]);
                string nombre = Convert.ToString(valores[1]);
                string direccion = Convert.ToString(valores[2]);
                Double telefono = Convert.ToDouble(valores[3]);
                Cadete nuevo = new Cadete(id, nombre, direccion, telefono);
                parametro.ListadoCadetes.Add(nuevo);
            }  
        }
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace cadeteria;

public class AccesoADatos{}

public class AccesoCSV : AccesoADatos{
    public List<Cadete> cargaCadetes()
    {
        List<Cadete> listaCadetes = new List<Cadete>();
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
                listaCadetes.Add(nuevo);
            }  
        }
        return listaCadetes;
    }
}

public class AccesoJSON : AccesoADatos{

    public List<Cadete> cargarCadetes()
    {
        string ruta = "cadetes.json";
        var FileRead = new StreamReader(ruta);
        var Json = FileRead.ReadToEnd();
        List<Cadete> lista = JsonSerializer.Deserialize<List<Cadete>>(Json);
        return lista;
    }
}

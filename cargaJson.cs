using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class cargaJson{
    
    public List<Cadete> cargarCadetes(string archivo)
    {
        var lista = new List<Cadete>();
        var json = File.ReadAllText(archivo);
        lista = JsonSerializer.Deserialize<List<Cadete>>(json);
        return lista;
    }
}
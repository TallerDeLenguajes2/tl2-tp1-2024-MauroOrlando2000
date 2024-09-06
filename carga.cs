using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class cargaCsv {
    public List<Cadete> cargaCadetes()
    {
        string ruta = "cadetes.csv";
        List<Cadete> listaCadetes = new List<Cadete>();
        using(var FileRead = new StreamReader(ruta))
        {
            while(!FileRead.EndOfStream)
            {
                var line = FileRead.ReadLine();
                var valores = line.Split(',');
                int id = Convert.ToInt16(valores[0]);
                string nombre = Convert.ToString(valores[1]);
                string direccion = Convert.ToString(valores[2]);
                long telefono = Convert.ToInt32(valores[3]);
                Cadete nuevo = new Cadete(id, nombre, direccion, telefono);
                listaCadetes.Add(nuevo);
            }  
        }
        return listaCadetes;
    }
}
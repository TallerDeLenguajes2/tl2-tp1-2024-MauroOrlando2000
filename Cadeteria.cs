using System.Collections;
using System.Collections.Generic;
namespace cadeteria;

public class Cadeteria{
    private string nombre;
    private long telefono;
    private List<Cadete> listadoCadetes;
    public Cadeteria()
    {
        cargaCsv cargar = new cargaCsv();
        string ruta = "cadeteria.csv";
        using(var FileRead = new StreamReader(ruta))
        {
            while(!FileRead.EndOfStream)
            {
                var line = FileRead.ReadLine();
                var valores = line.Split(',');
                nombre = Convert.ToString(valores[0]);
                telefono = Convert.ToInt32(valores[1]);
            }  
        }
        listadoCadetes = cargar.cargaCadetes();
    }

    public void Reasignar(Pedido pedido){}
}
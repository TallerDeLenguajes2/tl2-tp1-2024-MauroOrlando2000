namespace cadeteria;

public class Cliente{
    private string? nombre;
    private string direccion;
    private long telefono;
    private string? datosReferenciaDireccion;

    public Cliente()
    {
        nombre = "Javier Milei";
        direccion = "Quinta de Olivos";
        telefono = 3816258135;
        datosReferenciaDireccion = null;
    }

    public Cliente(bool num)
    {
        bool anda = false;
        string stringNum = null;

        Console.WriteLine("Ingrese el nombre del cliente");
        nombre = Console.ReadLine();
        while(!anda)
        {
            Console.WriteLine("Ingrese la direccion del cliente");
            direccion = Console.ReadLine();
            if(direccion != null)
            {
                anda = true;
            }
        }
        anda = false;
        while(!anda || telefono < 999999999 || telefono > 10000000000)
        {
            Console.WriteLine("Ingrese el telefono del cliente");
            stringNum = Console.ReadLine();
            anda = long.TryParse(stringNum, out telefono);
            if(!anda || telefono < 999999999 || telefono > 10000000000)
            {
                Console.WriteLine("Valor inválido");
            }
        }
        Console.WriteLine("Alguna referencia para ubicar la direccion dada?");
        datosReferenciaDireccion = Console.ReadLine();
        if(datosReferenciaDireccion == null)
        {
            datosReferenciaDireccion = "Ninguna";
        }
    }

    public void MostrarDireccion()
    {
        Console.WriteLine("Direccion del cliente: " + direccion);
        if(datosReferenciaDireccion == null)
        {
            Console.WriteLine("Observacion adicional: Ninguna");
        }
        else
        {
            Console.WriteLine("Observacion adicional: " + datosReferenciaDireccion);
        }
    }
    
    public void MostrarDatos()
    {
        Console.WriteLine("Nombre del cliente: " + nombre);
        Console.WriteLine("Telefonod del cliente: " + telefono);
    }
}
namespace cadeteria;

public class Cliente{
    private string nombre;
    private string direccion;
    private double telefono;
    private string? datosReferenciaDireccion;

    public Cliente()
    {
        nombre = "Javier Milei";
        direccion = "Quinta de Olivos";
        telefono = 3816258135;
        datosReferenciaDireccion = null;
    }

    public Cliente(string name, string address, double phone, string? reference)
    {
        nombre = name;
        direccion = address;
        telefono = phone;
        datosReferenciaDireccion = reference;
    }

    public string MostrarDireccion()
    {
        string aux = $"Direccion del cliente: {direccion}\nObservacion adicional: ";
        if(datosReferenciaDireccion == null)
        {
            aux += "Ninguna\n";
        }
        else
        {
            aux += datosReferenciaDireccion + "\n";
        }
        return aux;
    }
    
    public string MostrarDatos()
    {
        string aux = $"Nombre del cliente: {nombre}\nTelefono del cliente: {telefono}\n";
        return aux;
    }
}
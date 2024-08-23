# Taller de Lenguajes 2
### Nombre: Orlando, Mauro Valentín
### Carrera: Ing. en informática
### DNI: 42797700

> ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
El cliente forma parte del pedido, por lo tanto esta es una relación de composición. Si desaparece el pedido, desaparece el cliente. En cambio, los pedidos y cadetes, tienen una relación de agregación. El pedido puede cambiar de cadete, pero este último no desaparece, sino que existe de manera independiente. Lo mismo con los cadetes y la cadeteria, si el cadete desaparece, la cadeteria sigue existiendo como una entidad independiente.

> ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
La clase Cadete deberia tener el método "ObtenerPedido" que agregue los pedidos que debe entregar a una lista.
La clase Cadetería deberia tener el método "GenerarPedido" que cree un nuevo pedido para darle a un cadete.

> Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados

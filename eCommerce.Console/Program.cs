using eCommerce.Console.Database;

var db = new ECommerceContext();

foreach(var usuario in db.Usuarios)
{
    Console.WriteLine(usuario.Nome);
}



Console.WriteLine("Hello, World!");

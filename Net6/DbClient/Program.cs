

using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

using var context = new MyDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

var product = new Product();

context.Add(product);

context.SaveChanges();

context.ChangeTracker.Clear();

product = context.Set<Product>().First();
context.ChangeTracker.Clear();

Task.Delay(5000).Wait();

product.Name = "Kawa";
product.Price = 16;
context.Update(product);

context.SaveChanges();
context.ChangeTracker.Clear();


var products = context.Set<Product>()
    .TemporalBetween(DateTime.UtcNow.AddSeconds(-4), DateTime.UtcNow.AddSeconds(-2))
    .Select(x => new { item = x, from = EF.Property<DateTime>(x, "From"), to = EF.Property<DateTime>(x, "To") })

    .ToList();

foreach (var item in products)
{
    Console.WriteLine($"{item.item.Name}: {item.from} {item.to}");
}

context.ChangeTracker.Clear();

product = context.Set<Product>().TemporalAsOf(DateTime.UtcNow.AddSeconds(-3)).First();

context.Update(product);
context.SaveChanges();



Console.WriteLine();
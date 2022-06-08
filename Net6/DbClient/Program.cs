

using DAL;

using var context = new MyDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
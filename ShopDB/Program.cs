

using ShopDB.Context;
using ShopDB.Models;

ShopDBContext shopDBContext = new ShopDBContext();

void GetAll()
{
    List<Categories> categories = shopDBContext.Categories.ToList();
    int count = 0;
    foreach (Categories category in categories)
    {
        if (!category.IsDeleted)
        {
            count++;
            Console.WriteLine($"{count}.{category.Name}");
        }
    }
}

void GetById()
{
    Console.WriteLine("Add Id");
    int id = int.Parse(Console.ReadLine());
    Categories? category = shopDBContext.Categories.Where(s => s.Id == id).FirstOrDefault();
    if (category != null)
    {
        Console.WriteLine(category.Name);
    }
    else
    {
        Console.WriteLine("Category Not Found!");
    }
}

void Create()
{
    Categories? category = new Categories();
    Console.WriteLine("Add Category Name");
    category.Name = Console.ReadLine();
    category.IsDeleted = false;
    category.CreatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    shopDBContext.Categories.Add(category);
   shopDBContext.SaveChanges();
}

void Update()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Categories category = shopDBContext.Categories.Where(s=> s.Id == id).FirstOrDefault();
    if(category != null)
    {
        Console.WriteLine("Add Category Name");
        category.Name = Console.ReadLine();
        category.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    }
    else
    {
        Console.WriteLine("Category Not Found!");
    }
    shopDBContext.SaveChanges();
}

void Delete()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Categories category = shopDBContext.Categories.Where(s=> s.Id == id).FirstOrDefault();
    category.IsDeleted = true;
    category.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    if(category != null)
    {
        shopDBContext.SaveChanges();
    }
    else
    {
        Console.WriteLine("Category Not Found!");
    }
}

void ShowCategoryMenu()
{
    Console.WriteLine("1.Get All Categories");
    Console.WriteLine("2.Get Category By Id");
    Console.WriteLine("3.Create New Category");
    Console.WriteLine("4.Update Category");
    Console.WriteLine("5.Delete Category");
    Console.WriteLine("0.Close");
}

ShowCategoryMenu();
while (true)
{
    int request = int.Parse(Console.ReadLine());
    switch (request)
    {
        case 1:
            GetAll();
            break;
        case 2:
            GetById();
            break;
        case 3:
            Create();
            break;
        case 4:
            Update();
            break;
        case 5:
            Delete();
            break;
        case 6:
            break;
    }
    ShowCategoryMenu();
}
﻿

using Microsoft.EntityFrameworkCore;
using ShopDB.Context;
using ShopDB.Models;
using System.Collections.Generic;

ShopDBContext shopDBContext = new ShopDBContext();

void GetAllCategories()
{
    IQueryable<Categories> queries = shopDBContext.Categories.Where(x => !x.IsDeleted).AsNoTracking();

    List<Categories> categories = queries.Select(c => new Categories { Name = c.Name }).ToList();
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

void GetCategoryById()
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

void CreateCategory()
{
    Categories? category = new Categories();
    Console.WriteLine("Add Category Name");
    category.Name = Console.ReadLine();
    category.IsDeleted = false;
    category.CreatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    shopDBContext.Categories.Add(category);
    shopDBContext.SaveChanges();
}

void UpdateCategory()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Categories category = shopDBContext.Categories.Where(s => s.Id == id).FirstOrDefault();
    if (category != null)
    {
        Console.WriteLine("Change Category Name");
        category.Name = Console.ReadLine();
        category.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    }
    else
    {
        Console.WriteLine("Category Not Found!");
    }
    shopDBContext.SaveChanges();
}

void DeleteCategory()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Categories category = shopDBContext.Categories.Where(s => s.Id == id).FirstOrDefault();
    category.IsDeleted = true;
    category.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    if (category != null)
    {
        shopDBContext.SaveChanges();
    }
    else
    {
        Console.WriteLine("Category Not Found!");
    }
}


#region JustForMe
//void GetAllProducts()
//{
//    List<Products> products = shopDBContext.Products.ToList();
//    List<Categories> categories = shopDBContext.Categories.ToList();
//    foreach (Categories category in categories)
//    {
//        foreach (Products product in products)
//        {
//            if (!product.IsDeleted)
//            {
//                if (product.CategoryId == category.Id)
//                {
//                    string categoryName = category.Name;
//                    Console.WriteLine($"Product Category:{categoryName}  Product Name:{product.Name}  Price:{product.Price}");
//                }
//            }
//        }
//    }
//}
#endregion

void GetAllProducts()
{
    IQueryable<Products> query = shopDBContext.Products
        .Where(x => !x.IsDeleted)
        .Include(x => x.Category).AsNoTracking();
    IEnumerable<Products> products = query
        .Select(x => new Products
        {
            Category = new Categories {Name = x.Category.Name},
            Name = x.Name,
            Price = x.Price
        })
        .ToList();

    foreach (Products product in products)
    {
                    Console.WriteLine($"Product Category:{product.Category.Name}  Product Name:{product.Name}  Price:{product.Price}");
    }
}

void GetProductById()
{
    Console.WriteLine("Add Id");
    int id = int.Parse(Console.ReadLine());
    Products? product = shopDBContext.Products.Where(p => p.Id == id).FirstOrDefault();
    if (product != null)
    {
        Console.WriteLine($"Product Name:{product.Name}  Price:{product.Price}");
    }
    else
    {
        Console.WriteLine("Product Not Found!");
    }
}

void CreateProduct()
{
    Products? product = new Products();
    List<Categories> categories = shopDBContext.Categories.ToList();
    Console.WriteLine("Add Product Category");
    product.CategoryId = int.Parse(Console.ReadLine());
    bool match = false;

    foreach (Categories category in categories)
    {
        if (product.CategoryId == category.Id)
        {
            match = true;
            Console.WriteLine("Add Product Name");
            product.Name = Console.ReadLine();
            Console.WriteLine("Add Product Price");
            product.Price = int.Parse(Console.ReadLine());
            product.IsDeleted = false;
            product.CreatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
            shopDBContext.Products.Add(product);
            Console.WriteLine($"Category Name:{category.Name}  Product Name:{product.Name}  Product Price:{product.Price}");
            shopDBContext.SaveChanges();
        }
    }

    if (!match)
    {
        Console.WriteLine("Invalid Category");
    }
}

void UpdateProduct()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Products product = shopDBContext.Products.Where(p => p.Id == id).FirstOrDefault();
    if (product != null)
    {
        Console.WriteLine("Change Product's Category Id");
        product.CategoryId = int.Parse(Console.ReadLine());
        Console.WriteLine("Change Product Name");
        product.Name = Console.ReadLine();
        Console.WriteLine("Change Product Price");
        product.Price = int.Parse(Console.ReadLine());
        product.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    }
    else
    {
        Console.WriteLine("Product Not Found!");
    }
    shopDBContext.SaveChanges();
}

void DeleteProduct()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);
    Products product = shopDBContext.Products.Where(p => p.Id == id).FirstOrDefault();
    product.IsDeleted = true;
    product.UpdatedAt = DateTime.UtcNow.AddHours(4).ToString("dd-MM-yyyy HH:mm");
    if (product != null)
    {
        shopDBContext.SaveChanges();
    }
    else
    {
        Console.WriteLine("Product Not Found!");
    }
}

void ShowMenu()
{
    Console.WriteLine("1.Get All Categories");
    Console.WriteLine("2.Get Category By Id");
    Console.WriteLine("3.Create New Category");
    Console.WriteLine("4.Update Category");
    Console.WriteLine("5.Delete Category");
    Console.WriteLine("6.Get All Products");
    Console.WriteLine("7.Get Product By Id");
    Console.WriteLine("8.Create Product");
    Console.WriteLine("9.Update Product");
    Console.WriteLine("10.Delete Product");
    Console.WriteLine("0.Close");
}

    ShowMenu();
    int request = int.Parse(Console.ReadLine());
    while (request != 0)
    {
        switch (request)
        {
            case 1:
                GetAllCategories();
                break;
            case 2:
                GetCategoryById();
                break;
            case 3:
                CreateCategory();
                break;
            case 4:
                UpdateCategory();
                break;
            case 5:
                DeleteCategory();
                break;
            case 6:
                GetAllProducts();
                break;
            case 7:
                GetProductById();
                break;
            case 8:
                CreateProduct();
                break;
            case 9:
                UpdateProduct();
                break;
            case 10:
                DeleteProduct();
                break;
            default:
                Console.WriteLine("Please Add Valid Option");
                break;
        }
    ShowMenu();
        request = int.Parse(Console.ReadLine());
    }

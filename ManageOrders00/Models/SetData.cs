using ManageOrders00.Data;
using ManageOrders00.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcMovie.Models;

public   class SetData
{

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ManageOrders00Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<ManageOrders00Context>>()))
        {

           
            if (context.Customer.Any())
            {
                return;   
            }
                context.Customer.AddRange(
                new Customer
                {                  
                    CustomerName = "Сергій",
                    CustomerSurName = "Сергійко"
                },
                new Customer
                {                   
                    CustomerName = "Андрій",
                    CustomerSurName = "Андрійко"
                },
                new Customer
                {                 
                    CustomerName = "Василь",
                    CustomerSurName = "Василько"
                },
                new Customer
                {                  
                    CustomerName = "Максим",
                    CustomerSurName = "Максимко"
                },
                new Customer
                {            
                    CustomerName = "Олег",
                    CustomerSurName = "Олежко"
                },
                new Customer
                {           
                    CustomerName = "Іван",
                    CustomerSurName = "Іванко"
                }
            );
            context.SaveChanges();
            context.Product.AddRange(
                new Product
                {
                    ProductName = "Пральний порошок \"Ariel\" Відбілюючий",
                    ProductDescription = "Відбілюючий",
                    Price = 120
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Ariel\"",
                    ProductDescription = "Для кольорових тканин",
                    Price = 135.5
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Tide\" Відбілюючий",
                    ProductDescription = "Відбілюючий",
                    Price = 122
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Tide\"",
                    ProductDescription = "Для кольорових тканин",
                    Price = 130.6
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Persil\" Відбілюючий",
                    ProductDescription = "Відбілюючий",
                    Price = 110.8
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Persil\"",
                    ProductDescription = "Для кольорових тканин",
                    Price = 134.2
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Gala\" Відбілюючий",
                    ProductDescription = "Відбілюючий",
                    Price = 85
                },
                new Product
                {
                    ProductName = "Пральний порошок \"Gala\"",
                    ProductDescription = "Для кольорових тканин",
                    Price = 94.5
                }
                );
            context.SaveChanges();
            context.Order.AddRange(
                new Order
                {
                    CustomerId = 5,
                    OrderReleaseDate = new DateTime(2022, 02, 02),
                },
                new Order
                {
                    CustomerId = 3,
                    OrderReleaseDate = new DateTime(2022, 02, 02),
                },
                new Order
                {
                    CustomerId = 1,
                    OrderReleaseDate = new DateTime(2022, 02, 02),
                },
                new Order
                {
                    CustomerId = 5,
                    OrderReleaseDate = new DateTime(2022, 02, 08),
                },
                new Order
                {
                    CustomerId = 4,
                    OrderReleaseDate = new DateTime(2022, 02, 09),
                },
                new Order
                {
                    CustomerId = 5,
                    OrderReleaseDate = new DateTime(2022, 02, 10),
                },
                new Order
                {
                    CustomerId = 2,
                    OrderReleaseDate = new DateTime(2022, 02, 10),
                },
                new Order
                {
                    CustomerId = 4,
                    OrderReleaseDate = new DateTime(2022, 02, 10),
                },
                new Order
                {
                    CustomerId = 5,
                    OrderReleaseDate = new DateTime(2022, 02, 10),
                },
                new Order
                {
                    CustomerId = 5,
                    OrderReleaseDate = new DateTime(2022, 03, 03),
                },
                new Order
                {
                    CustomerId = 3,
                    OrderReleaseDate = new DateTime(2022, 03, 03),
                },
                new Order
                {
                    CustomerId = 1,
                    OrderReleaseDate = new DateTime(2022, 03, 04),
                },
                new Order
                {
                    CustomerId = 2,
                    OrderReleaseDate = new DateTime(2022, 03, 04),
                },
                new Order
                {
                    CustomerId = 2,
                    OrderReleaseDate = new DateTime(2022, 03, 07),
                }
                );
            context.SaveChanges();
            context.Position.AddRange(
                new Position
                {
                    OrderId = 1,
                    ProductId = 1,
                    ProductCount = 2
                },
                new Position
                {
                    OrderId = 2,
                    ProductId = 1,
                    ProductCount = 2
                },
                new Position
                {
                    OrderId = 3,
                    ProductId = 1,
                    ProductCount = 2
                },
                new Position
                {
                    OrderId = 4,
                    ProductId = 1,
                    ProductCount = 2
                },
                new Position
                {
                    OrderId = 5,
                    ProductId = 1,
                    ProductCount = 2
                }
                );

            context.SaveChanges();

        }
    }
}

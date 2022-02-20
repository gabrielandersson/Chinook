using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using Chinook.Data;
using Chinook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Chinook
{
    internal class Program
    {
        private static ChinookContext _context = new ChinookContext();
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            //ShowCustomersPerCountry();
            //ShowHighestSpenders();
            ShowCustomerMostPopularGenre(1);
        }

        private static void ShowCustomerMostPopularGenre(int id)
        {

            var sql = _context.Genres.FromSqlInterpolated(
                $"SELECT TOP 1 WITH TIES genre.Name, genre.GenreId ,COUNT(*) AS NumInEachGenre\r\nFROM Genre\r\nJOIN Track ON genre.GenreId = Track.GenreId\r\nJOIN InvoiceLine ON Track.TrackId = InvoiceLine.InvoiceLineId\r\nJOIN Invoice ON InvoiceLine.InvoiceId = Invoice.InvoiceId\r\nJOIN Customer ON Invoice.CustomerId = Customer.CustomerId\r\nWHERE Customer.CustomerId = {id}\r\nGROUP BY genre.GenreId, Genre.Name\r\nORDER BY NumInEachGenre DESC")
                .Include(g => g.Tracks).ThenInclude(t => t.InvoiceLines)
                .ThenInclude(il => il.Invoice).ThenInclude(i => i.Customer)
                .ThenInclude(c => c.Invoices);
            //var mostPopularGenre = _context.Genres.Include(g => g.Tracks)
            //    .ThenInclude(t => t.InvoiceLines).ThenInclude(iL => iL.Invoice)
            //    .ThenInclude(i => i.Customer).ThenInclude(c => c).Where(c => c.).GroupBy(g => g.Name);

            //var mostPopularGenreForCustomer = _context.Customers.Include(c => c.Invoices.Where(i => i.CustomerId == id))
            //    .ThenInclude(i => i.InvoiceLines).ThenInclude(il => il.Track)
            //    .ThenInclude(tr => tr.Genre).ThenInclude(g => g.Tracks).OrderByDescending(g => g);

            //var test = _context.Genres.Include(c => c.Tracks).ThenInclude(t => t.InvoiceLines)
            //    .ThenInclude(il => il.Invoice).ThenInclude(i => i.Customer).Select(s => new {name = s.Name}).ToList();
            
            //var test = _context.Genres.Select(g => new { Name = g.Name, TotalTracks = g.Tracks.Count}).ToList().OrderByDescending(g => g.TotalTracks);

            foreach (var t in sql)
            {
                Console.WriteLine($" {t.Name}");   
            }

        }
        private static void ShowHighestSpenders()
        {
            var highestSpenders = _context.Invoices
                .Select(i => new
                {
                    Total = i.Total,
                    customer = i.Customer
                }).OrderByDescending(i => i.Total);
            foreach (var customer in highestSpenders)
            {
                Console.WriteLine($"{customer.customer.FirstName} {customer.Total}");
            }
        }
        private static void ShowCustomersPerCountry()
        {
            var customers = _context.Customers.GroupBy(c => c.Country).Select(c =>
                new { Country = c.Key, Total = c.Count() }).OrderByDescending(c => c.Total);
            foreach (var item in customers)
            {
                Console.WriteLine($"{item.Country} {item.Total}");
            }
        }
        private static void AddCustomer(string firstName, string lastName, string country, string email)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Country = country,
                Email = email
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public static void UpdateCustomerById(int id, string firstName, string lastName, string postalCode,
                                                                string phone, string email, string country)
        {
            var customer = _context.Customers.Find(id);
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.PostalCode = postalCode;
            customer.Phone = phone;
            customer.Email = email;
            customer.Country = country;
            _context.SaveChanges();
        }
        private static List<Customer> ReturnPage(int offset, int limit)
        {
            var customers = _context.Customers.Skip(offset).Take(limit).ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($" {customer.CustomerId} {customer.FirstName} {customer.LastName} " +
                                  $" {customer.Country} {customer.PostalCode} {customer.Phone} " +
                                  $" {customer.Email}");
            }
            return customers;
        }
        private static void AddCustomer(string firstName, string lastName, string postalCode, string phone
                                        , string email, string country)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Email = email
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        //maybe use firstorDefault instead and check for null instead of checking for exceptions
        private static void DisplayCustomerToConsoleByFirstNameWithLike(string customerName)
        {
            var customer = _context.Customers.TagWith("consoleApp.Program.GetCustomerByName")
                .Where(customer => EF.Functions.Like(customer.FirstName, $"%{customerName}%")).ToList();

            if (customer[0] is null || customer.Count == 0)
            {
                Console.WriteLine("No customer with that name was found");
            }

            Console.WriteLine($" {customer[0].CustomerId} {customer[0].FirstName} {customer[0].LastName} " +
                              $" {customer[0].Country} {customer[0].PostalCode} {customer[0].Phone} " +
                              $" {customer[0].Email}");
        }
        private static void DisplayCustomerToConsoleById(int customerId)
        {
            var customer = _context.Customers.Find(customerId);

            if (customer is null)
            {
                Console.WriteLine("No customer with that name was found");
            }
            else
            {
                Console.WriteLine($" {customer.CustomerId} {customer.FirstName} {customer.LastName} " +
                                  $" {customer.Country} {customer.PostalCode} {customer.Phone} " +
                                  $" {customer.Email}");
            }
        }
        private static void DisplayCustomersToConsole()
        {
            var customers = _context.Customers.TagWith("consoleApp.Program.GetCustomers").ToList();
            if (customers.Count == 0 || customers[0] is null)
            {
                Console.WriteLine("No customers were found");
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($" {customer.CustomerId} {customer.FirstName} {customer.LastName} " +
                                  $" {customer.Country} {customer.PostalCode} {customer.Phone} " +
                                  $" {customer.Email}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Chinook.Data;
using Chinook.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Chinook
{
    internal class Program
    {
        private static ChinookContext _context = new ChinookContext();
        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            DisplayCustomerToConsoleByFirstNameWithLike("L");
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

        public static void UpdateCustomerById(int id, )
        {
 
        }
        private static List<Customer> ReturnPage(int limit, int offset)
        {

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
        //maybe use first instead and use try-catch block 
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
            var customer = _context.Customers.TagWith("consoleApp.Program.GetCustomerById")
                .Where(customer => customer.CustomerId == customerId).ToList();

            if (customer[0] is null || customer.Count == 0)
            {
                Console.WriteLine("No customer with that name was found");
            }

            Console.WriteLine($" {customer[0].CustomerId} {customer[0].FirstName} {customer[0].LastName} " +
                              $" {customer[0].Country} {customer[0].PostalCode} {customer[0].Phone} " +
                              $" {customer[0].Email}");
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

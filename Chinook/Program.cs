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
        static void Main(string[] args)
        {
            //Just uncomment to try the methods out ^^ 

            IAssignmentRepository repo = new CustomerRepository();

            // repo.DisplayCustomersToConsole();                    //1

            // repo.DisplayCustomerToConsoleById(5);                //2

            // repo.DisplayCustomerToConsoleByFirstName("He");       //3 A 

            // repo.DisplayCustomersToConsoleByFirstName("a");      //3 B

            // repo.ReturnPage(3, 4);                               //4 

            // repo.AddCustomer("Gabriel", "Mr.Anderson", "6666", "0000", "at@Awesome.com", "Sweden");   //5

            // repo.ShowCustomersPerCountry();                      //6

            // repo.ShowHighestSpenders();                          //7

            // repo.ShowCustomerMostPopularGenre(1);                //8A

            // repo.ShowCustomerMostPopularGenre(2);                //8B
        }

    }
}

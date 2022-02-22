using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chinook.Domain.Models;

namespace Chinook.Data
{
    public interface IAssignmentRepository
    {
        void DisplayCustomersToConsole();
        void DisplayCustomerToConsoleById(int customerId);
        void DisplayCustomersToConsoleByFirstName(string customerFirstName);
        void DisplayCustomerToConsoleByFirstName(string customerFirstName);
        List<Customer> ReturnPage(int offset, int limit);
        void AddCustomer(string firstName, string lastName, string postalCode, string phone
            , string email, string country);
        void UpdateCustomerById(int id, string firstName, string lastName, string postalCode,
            string phone, string email, string country);
        void ShowCustomersPerCountry();
        void ShowHighestSpenders();
        List<Genre> ShowCustomerMostPopularGenre(int id);
    }
}

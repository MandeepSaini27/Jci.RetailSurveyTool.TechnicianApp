using JCI.RetailSurveyTool.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jci.RetailSurveyTool.TechnicianApp.Services
{
    public interface ICustomerDataService
    {
        List<Customer> GetAllCustomers();

        //void AddCustomer(Customer customer);

        //void UpdateCustomer(Customer customer);

    }
}

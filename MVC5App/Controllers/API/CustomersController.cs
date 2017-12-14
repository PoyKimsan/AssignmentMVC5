using AutoMapper;
using MVC5App.DTOs;
using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5App.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get Customer
        public IEnumerable<CustomerDTO> GetCustomers() {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }
        //Get Customer/1
        public CustomerDTO GetCustomer(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }
        //Post Customer
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDTO) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.Id = customer.Id;
            return customerDTO;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto) {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDB);
            _context.SaveChanges();
        } 

        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}

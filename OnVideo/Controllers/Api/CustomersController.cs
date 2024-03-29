﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using OnVideo.Models;
using System.Data.Entity;
using Vidly.Dtos;

namespace OnVideo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/api/customers
        public IHttpActionResult GetCustomer(string query = null)
        {
            var customerQuery = _context.Customers
                .Include(m => m.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(x => x.Name.Contains(query));


            var customerDtos = customerQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }


        //GET/api/Customers/1
            public IHttpActionResult GetCustomer(int id)
            {
                var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

                if (customer == null)
                    return NotFound();

                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }

            //POST/api/customers
            [HttpPost]
            public IHttpActionResult CreateCustomer(CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cusstomer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(cusstomer);
                _context.SaveChanges();

                customerDto.Id = cusstomer.Id;

                return Created(new Uri(Request.RequestUri + "/" + cusstomer.Id), customerDto);
            }

            //PUT/API/Customers/1
            [HttpPut]
            public void UpdateCustomer(int id, CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            
                var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                Mapper.Map(customerDto, customerInDb);

                customerInDb.Name = customerDto.Name;
                customerInDb.Birthdate = customerDto.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

                _context.SaveChanges();
            
            }

            //Delete/api/Customers/1
            [HttpDelete]
            public void DeleteCustomer(int id)
            {
                var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

                if (customerInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();

            }
    }
}

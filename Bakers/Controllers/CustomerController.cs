﻿using Bakers.Model;
using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bakers.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {





        private readonly ICustomerService _ccustomer;

        public CustomerController(ICustomerService ccustomer)
        {
            _ccustomer = ccustomer;


        }



        [HttpGet]
        [Route("api/[controller]")]


        public IActionResult GetAllCustomer()
        {
            try
            {

                return Ok(_ccustomer.GetAllCustomer());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

            }


        }
        [HttpPost]
        [Route("api/[controller]")]


        public async Task<IActionResult> AddCustomer(AddCustomer request)
        {


            Show response = new Show();

            try
            {

                response = await _ccustomer.AddCustomer(request);

            }

            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);

        }







        [HttpGet("{id:int}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var resultId = _ccustomer.GetCustomer(id);
                if (resultId == null)
                {
                    return NotFound();
                }
                return Ok(resultId);
            }
            catch (Exception ee)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ee);

            }

        }

        [HttpDelete]
        [Route("delete/Id")]
        public IActionResult DeleteCustomer(int Id)
        {
            try


            {
                var removeCustomer = _ccustomer.GetCustomer(Id);
                if (removeCustomer == null)
                {



                    return NotFound($"Customer With Id:{Id}  was not found");
                }

                {

                    _ccustomer.DeleteCustomer(Id);
                    return Ok(removeCustomer);

                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }


        [HttpPut]
        [Route("Edit/Id")]
        public IActionResult EditCustomer(int id, Customer customer)

        {


            try
            {
                var existingCustomer = _ccustomer.GetCustomer(id);

                if (existingCustomer != null)
                {
                    _ccustomer.EditCustomer(id, customer);
                    return Ok(customer);
                }

                return StatusCode(StatusCodes.Status400BadRequest, $"Customer Id {id} not found");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);


            }


        }



        }
}

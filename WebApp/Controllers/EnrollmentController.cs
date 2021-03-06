﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.DPOs.Requests;
using WebApp.Services;


namespace WebApp.Controllers
{
    [Route("api/Enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private IStudentDbService _service;

        public EnrollmentController(IStudentDbService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
           
            string result = _service.EnrollStudent(request);
            if (result.Contains("Failed:"))
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("{promotions}")]
        public IActionResult PromoteStudents(PromoteStudentRequest request)
        {
            string result = _service.PromoteStudents(request);
            if(result.Contains("Failed:"))
                return BadRequest(result);
            return Ok(result);

        }
        [HttpGet]
        public IActionResult GetEnrollments()
        {   
            return Ok("Welcome to enrolling.");

        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MtechSystemTest.Models;

namespace MtechSystemTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        public List<Employee> listEmployees = new List<Employee>()
            {
                new Employee { ID = 1, Name = "Juan", LastName = "Pérez", RFC = "PEJU123456", BornDate = new DateTime(1980, 1, 1), Status = EmployeeStatus.Active },
                new Employee { ID = 2, Name = "María", LastName = "Martínez", RFC = "MAMA123456", BornDate = new DateTime(1990, 2, 15), Status = EmployeeStatus.Inactive },
                new Employee { ID = 3, Name = "Pedro", LastName = "García", RFC = "PEGA123456", BornDate = new DateTime(1985, 5, 10), Status = EmployeeStatus.NotSet }
            };

        [HttpGet]
        public IActionResult Index()
        {
            // Simulate getting the list of employees from some service or database
            // Convert the list of employees to JSON
            string employeesJson = JsonConvert.SerializeObject(listEmployees);

            // send data to the view
            ViewData["Employees"] = employeesJson;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost("Create")]
        public IActionResult Create([FromForm] Employee employee)
        {
            Console.WriteLine(employee.Name);

            if (ModelState.IsValid)
            {
                Console.WriteLine('y');
                // Generate a new ID for the employee
                int newId = listEmployees.Max(e => e.ID) + 1;

                // Create a new Employee object with the provided data
                Employee newEmployee = new Employee
                {
                    ID = newId,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    RFC = employee.RFC,
                    BornDate = employee.BornDate,
                    Status = employee.Status
                };

                // Add the new employee to the list
                listEmployees.Add(newEmployee);


                string json = JsonConvert.SerializeObject(listEmployees, Formatting.Indented);
                Console.WriteLine(json);

                // Redirect to the Index action
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine('n');
            }

            // If the model state is not valid, redirect to the Index action
            return RedirectToAction("Index");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            var existingEmployee = listEmployees.FirstOrDefault(e => e.ID == id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.RFC = employee.RFC;
                existingEmployee.BornDate = employee.BornDate;
                existingEmployee.Status = employee.Status;
                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var employee = listEmployees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                listEmployees.Remove(employee);
                return View("Table", listEmployees); // Return the Table view with the updated list of employees
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            // Here you can add validations and business logic before adding the employee

            // Convert the JSON from localStorage to a list of employees
            var employees = JsonConvert.DeserializeObject<List<Employee>>(Request.Form["employees"]);

            // Add the new employee to the list
            employees.Add(employee);

            // Convert the list of employees to JSON
            string employeesJson = JsonConvert.SerializeObject(employees);

            // Update the list of employees in localStorage
            ViewData["Employees"] = employeesJson;

            return Ok();
        }

        [HttpGet("Table")]
        public IActionResult Table()
        {
            // Simulates retrieving an employee from a database

            // Returns the view with the employee data
            return View(listEmployees);
        }

    }
}

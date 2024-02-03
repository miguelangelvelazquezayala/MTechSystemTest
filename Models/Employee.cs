using System.ComponentModel.DataAnnotations;

namespace MtechSystemTest.Models
{
    /// Represents an employee in the system.
    public class Employee
    {
        /// Gets or sets the ID of the employee.
        public int ID { get; set; }

        /// Gets or sets the name of the employee.
        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Name { get; set; }

        /// Gets or sets the last name of the employee.
        [Required(ErrorMessage = "El campo Apellido es requerido.")]
        public string LastName { get; set; }

        /// Gets or sets the RFC (Registro Federal de Contribuyentes) of the employee.
        [Required(ErrorMessage = "El campo RFC es requerido.")]
        [RegularExpression(@"^[A-Z]{4}\d{6}[A-Z0-9]{3}$", ErrorMessage = "El formato del RFC es inválido.")]
        public string RFC { get; set; }

        /// Gets or sets the date of birth of the employee.
        public DateTime? BornDate { get; set; }

        /// Gets or sets the status of the employee.
        public EmployeeStatus? Status { get; set; }
    }

    /// Represents the status of an employee.
    public enum EmployeeStatus
    {
        NotSet,
        Active,
        Inactive,
    }
}
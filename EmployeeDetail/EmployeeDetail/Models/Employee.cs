using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeDetail.Models
{
    public class Employee
    {
        //This is entity framework
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        [DisplayName("EmployeeId")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(12, ErrorMessage = "Maximum 3 characters only.")]
        public string EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string EmployeeName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("role")]
        [Required(ErrorMessage = "This field is required.")]
        public string role { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("Number")]
        [Required(ErrorMessage = "This field is required.")]
        [MaxLength(11, ErrorMessage = "Maximum 10 characters only.")]
        public string number { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int salary { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime Date { get; set; }
    }
}

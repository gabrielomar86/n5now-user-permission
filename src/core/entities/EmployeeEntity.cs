using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPermission.core.entities
{
    public class UserPermissionEntity : EntidadBase<int>
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmployeeForename { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmployeeSurname { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int PermissionType { get; set; }

        [Required]
        public Date PermissionDate { get; set; }

    }
}
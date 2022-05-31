using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPermission.core.entities
{
    [Table("Permission")]
    public class PermissionEntity : BaseEntity<int>
    {
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmployeeForename { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmployeeSurname { get; set; }

        [Required]
        public int PermissionTypeId { get; set; }
        public virtual PermissionTypeEntity PermissionType { get; set; }

        [Required]
        public DateTime PermissionDate { get; set; }

    }
}
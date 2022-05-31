using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPermission.core.entities
{
    [Table("PermissionType")]
    public class PermissionTypeEntity : BaseEntity<int>
    {
        public PermissionTypeEntity()
        {
            Permissions = new HashSet<PermissionEntity>();
        }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        [ForeignKey("PermissionTypeId")]
        public virtual ICollection<PermissionEntity> Permissions { get; set; }

    }
}
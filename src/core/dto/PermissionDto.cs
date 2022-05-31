using System;

namespace UserPermission.core.dto
{
    public class PermissionDto
    {

        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public int PermissionTypeId { get; set; }
        public DateTime PermissionDate { get; set; }

    }
}
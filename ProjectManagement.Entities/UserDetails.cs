﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjecManagement.EntityLayer
{
    [Table("Users")]
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual ProjectDetails Project { get; set; }
        public int? ProjectId { get; set; }
        
        [ForeignKey("TaskId")]
        public virtual ProjectTaskDetails ProjectTask { get; set; }
        public int? TaskId { get; set; }
    }
}

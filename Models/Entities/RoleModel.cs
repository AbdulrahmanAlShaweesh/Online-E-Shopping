using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class RoleModel
    {
        [Key] 
        public int RoleId {get; set;} 
        [Required] 
        [StringLength(100, ErrorMessage = "Name Must be less than 100 charachters")]
        public string RoleName {get; set;} = string.Empty;
    }
}
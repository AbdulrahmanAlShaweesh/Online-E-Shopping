using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onlineEShopping.Models.Entities
{
    public class ContactModel
    {
        [Key]
        public int ContactId {get; set;}
        
        [StringLength(50, ErrorMessage = "Name Must Be Less than 50 Letters")]
        public string ContactName {get; set;} = string.Empty; 

        public string ContactEmail {get; set;} = string.Empty; 

        public string Subject {get; set;} = string.Empty; 

        public string Messages {get; set;} = string.Empty;

        [Required]
        public DateTime CreatedDate {get; set;} 
    }
}
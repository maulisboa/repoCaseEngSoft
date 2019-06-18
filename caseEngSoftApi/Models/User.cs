using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace caseEngSoftApi.Models
{
    [Table("t_user")]
    public class User
    {
        [Key]
        public int id_user { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string user_name { get; set; }
        
    }
}

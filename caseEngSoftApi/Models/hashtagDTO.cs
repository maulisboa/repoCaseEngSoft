using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caseEngSoftApi.Models
{
    public class hashtagDTO
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long id_hashtag { get; set; }
        public string hashtag_name { get; set; }
    }
}

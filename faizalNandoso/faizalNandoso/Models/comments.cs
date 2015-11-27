using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace faizalNandoso.Models
{
    public class comments
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public virtual ICollection<String> Comments { get; set; }
    }
}
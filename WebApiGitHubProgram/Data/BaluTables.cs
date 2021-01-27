using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGitHubProgram.Data
{
    public class BaluTables
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StdId { get; set; }

        [Required, StringLength(50), MinLength(3)]
        public string StdName { get; set; }

        public decimal Fee { get; set; }

        public DateTime DOB { get; set; }




    }
}

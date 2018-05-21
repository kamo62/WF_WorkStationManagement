using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_WorkStationManagement
{

        [Table("Users")]
        public class AliveModel
        {
            [Key]
            public string hostname { get; set; }
            public string ipAddress { get; set; }
            public string datetime { get; set; }
            public string processName { get; set; }
            public string port { get; set; }
            [ReadOnly(true)]
            public DateTime CreatedDate { get; set; }
        }

    }


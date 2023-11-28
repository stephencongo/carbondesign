using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.services.Data.Entities
{
    public partial class UserLoginAttempt
    {
        public string IpAddress { get; set; } = null!;
        public int LoginAttempts { get; set; }

    }
}

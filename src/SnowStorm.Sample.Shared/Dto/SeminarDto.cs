using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowStormSample.Shared.Dto
{
    public class SeminarDto : BaseDto
    {
        public string? Subject { get; set; }
        public DateTime EventDate { get; set; }

    }
}

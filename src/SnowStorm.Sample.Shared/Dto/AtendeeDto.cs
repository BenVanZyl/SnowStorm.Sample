using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowStormSample.Shared.Dto
{
    public class AtendeeDto : BaseDto
    {
        public long SeminarId { get; set; }
        public string? AttendeeName { get; set; }
    }
}

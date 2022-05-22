﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class MembershipResultDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MonthlyFee { get; set; }
        public string Description { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCO.PaymentService.Application.DTOs
{
    public class PaymentResultDto
    {
        public Guid PaymentId { get; set; }
        public int Status { get; set; }
    }
}

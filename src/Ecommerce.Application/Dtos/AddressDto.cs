﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    public class AddressDto
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
    }
}

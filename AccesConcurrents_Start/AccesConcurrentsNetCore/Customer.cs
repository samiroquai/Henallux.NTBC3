﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AccesConcurrentsNetCore
{
    public class Customer
    {
        public double AccountBalance { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string EMail { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string Remark { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

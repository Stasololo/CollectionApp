﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectionApp.Models
{
    public class Currency : GenericClass
    {
        public string Name { get; set; }
        public string CurrCode { get; set; }

        public float SellRate { get; set; }

        public bool? Locked { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Utility
{
    public class ServiceResponse<T>
    {

        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

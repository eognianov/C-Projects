﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chuska.ViewModels.Products
{
    public class CreateModelInputViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }
    }
}

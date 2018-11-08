﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels.Packages
{
    public class PackageDetailsViewModel
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public string EstimatedDeliveryDate { get; set; }

        public double Weight { get; set; }

        public string Recipient { get; set; }

        public string Description { get; set; }

    }
}

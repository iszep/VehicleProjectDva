﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Cars.Service.Interfaces;

namespace Cars.Service.Models
{
    public class VehicleMake : IVehicleMake
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}

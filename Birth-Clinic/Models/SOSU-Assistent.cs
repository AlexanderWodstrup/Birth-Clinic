﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Models
{
    public class SOSU_Assistent : Clinician
    {
        public override void SetAvailability(bool state)
        {
            Availability = state;
        }
    }
}

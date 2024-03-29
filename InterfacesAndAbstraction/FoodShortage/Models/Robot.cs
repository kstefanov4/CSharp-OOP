﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Robot : IIdentityable
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }

        public string Model { get; private set; }
        public string ID { get; private set; }
    }
}

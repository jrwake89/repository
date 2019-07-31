﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Model
{
    public class Make
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public int ModelId { get; set; }
        public DateTime DateAdded { get; set; }
        public string DateAddedString { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Column
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string project_url { get; set; }
        public string cards_url { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}

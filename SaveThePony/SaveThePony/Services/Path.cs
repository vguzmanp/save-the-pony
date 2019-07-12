﻿using SaveThePony.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveThePony.Services
{
    public class Path
    {
        public Guid MazeId { get; set; }
        public Point Source { get; set; }
        public Point Destination { get; set; }
        public IEnumerable<Point> Steps { get; set; }
        public int Length => Steps.Count();
    }
}
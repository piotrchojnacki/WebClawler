﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCrawler.Models;

namespace WebCrawler.Savers.Interfaces
{
    public interface ISaver
    {
        void Save(Weather weather);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class AgedItemQualityCalculator : QualityCalculator
    {
        public override void Calculate(Item item)
        {
            AgeWell(item);
        }
    }
}

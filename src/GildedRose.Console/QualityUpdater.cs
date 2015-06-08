//-----------------------------------------------------------------------
// <copyright file="QualityUpdater.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GildedRose.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    [System.Runtime.InteropServices.GuidAttribute("5C4A59D9-4E06-4663-9520-D79BE87F6531")]
    public class QualityUpdater
    {
        private const short MAX_QUALITY = 50;
        private const short MIN_QUALITY = 0;
        private const short MIN_SELL_IN = 0;
        private const short EVENT_SOON = 11;
        private const short EVENT_VERY_SOON = 6;

        public IList<Item> Items { get; set; }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                new QualityCalculator().Calculate(item);

                CalculateSellIn(item);
            }
        }

        private static void CalculateSellIn(Item item)
        {
            if (!IsLegendary(item))
            {
                item.SellIn -= 1;
            }
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}

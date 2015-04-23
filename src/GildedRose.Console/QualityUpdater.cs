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

    public class QualityUpdater
    {
        private const short MAX_QUALITY = 50;
        private const short MIN_QUALITY = 0;
        private const short MIN_SELL_IN = 0;
    
        public IList<Item> Items { get; set; }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (!IsAged(item) && !IsEvent(item))
                {
                    if (item.Quality > MIN_QUALITY)
                    {
                        if (!IsLegendary(item))
                        {
                           item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MAX_QUALITY)
                    {
                        item.Quality = item.Quality + 1;

                        if (IsEvent(item))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                            
                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MAX_QUALITY)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsLegendary(item))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < MIN_SELL_IN)
                {
                    if (!IsAged(item))
                    {
                        if (!IsEvent(item))
                        {
                            if (item.Quality > MIN_QUALITY)
                            {
                                if (!IsLegendary(item))
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (QualityNotYetMax(item))
                        {
                            NormalIncrease(item);
                        }
                    }
                }
            }
        }

        private static bool IsAged(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsEvent(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool QualityNotYetMax(Item item)
        {
            return item.Quality < MAX_QUALITY;
        }

        private static void NormalIncrease(Item item)
        {
            item.Quality = item.Quality + 1;
        }
    }
}

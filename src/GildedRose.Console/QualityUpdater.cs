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
                CalculateQuality(item);

                CalculateSellIn(item);
            }
        }

        private static void CalculateQuality(Item item)
        {
            if (DoesntAgeWell(item))
            {
                AgeBadly(item);
            }
            else
            {
                AgeWell(item);
            }

            if (IsLastDayToSell(item) && IsEvent(item))
            {
                item.Quality = MIN_QUALITY;
            };

            if (IsLastDayToSell(item) && !IsLegendary(item))
            {
                AgeBadly(item);
            }
        }

        private static bool IsLastDayToSell(Item item)
        {
            return item.SellIn == MIN_SELL_IN;
        }

        private static void AgeBadly(Item item)
        {
            if (QualityIsReducable(item))
            {
                item.Quality -= 1;
            }
        }

        private static bool QualityIsReducable(Item item)
        {
            return StillHasQuality(item) && !IsLegendary(item);
        }

        private static bool DoesntAgeWell(Item item)
        {
            return !AgesWell(item) && !IsEvent(item);
        }

        private static void CalculateSellIn(Item item)
        {
            if (!IsLegendary(item))
            {
                item.SellIn -= 1;
            }
        }

        private static bool StillHasQuality(Item item)
        {
            return item.Quality > MIN_QUALITY;
        }

        private static bool QualityNotYetMax(Item item)
        {
            return item.Quality < MAX_QUALITY;
        }

        private static bool AgesWell(Item item)
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

        private static void AgeWell(Item item)
        {
            if (QualityNotYetMax(item))
            {
                item.Quality += 1;

                if (IsEvent(item))
                {
                    if (item.SellIn < 11)
                    {
                        item.Quality += 1;
                    }

                    if (item.SellIn < 6)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}

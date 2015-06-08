using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class QualityCalculator
    {
        private const short MAX_QUALITY = 50;
        private const short MIN_QUALITY = 0;
        private const short MIN_SELL_IN = 0;
        private const short EVENT_SOON = 11;
        private const short EVENT_VERY_SOON = 6;

        public virtual void Calculate(Item item)
        {
            if (DoesntAgeWell(item) && !IsLegendary(item))
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
        }

        private static void AgeBadly(Item item)
        {
            if (QualityIsReducable(item))
            {
                if (item.SellIn > 0)
                {
                    item.Quality -= 1;
                }
                else
                {
                    item.Quality -= 2;
                }
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

        private static bool AgesWell(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool StillHasQuality(Item item)
        {
            return item.Quality > MIN_QUALITY;
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        protected static void AgeWell(Item item)
        {
            if (QualityNotYetMax(item))
            {
                item.Quality += 1;

                AgeEventWell(item);
            }
        }

        private static bool QualityNotYetMax(Item item)
        {
            return item.Quality < MAX_QUALITY;
        }

        private static bool IsLastDayToSell(Item item)
        {
            return item.SellIn == MIN_SELL_IN;
        }

        private static void AgeEventWell(Item item)
        {
            if (IsEvent(item))
            {
                if (EventIsSoon(item))
                {
                    item.Quality += 1;
                }

                if (EventIsVerySoon(item))
                {
                    item.Quality += 1;
                }
            }
        }

        private static bool IsEvent(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool EventIsSoon(Item item)
        {
            return item.SellIn < EVENT_SOON;
        }

        private static bool EventIsVerySoon(Item item)
        {
            return item.SellIn < EVENT_VERY_SOON;
        }
    }
}

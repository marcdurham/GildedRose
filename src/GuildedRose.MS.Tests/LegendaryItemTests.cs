using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GildedRose.Console;
using System.Collections.Generic;

namespace GuildedRose.MS.Tests
{
    [TestClass]
    public class LegendaryItemTests
    {
        [TestMethod]
        public void Sulfuras_Quality_RemainsSame()
        {
            var updater = new ItemUpdater();

            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };

            updater.Items = new List<Item> { sulfuras };

            updater.Update();

            Assert.AreEqual(80, sulfuras.Quality);
        }

        [TestMethod]
        public void Sulfuras_SellIn_RemainsSame()
        {
            var updater = new ItemUpdater();

            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };

            updater.Items = new List<Item> { sulfuras };

            updater.Update();

            Assert.AreEqual(1, sulfuras.SellIn);
        }
    }
}

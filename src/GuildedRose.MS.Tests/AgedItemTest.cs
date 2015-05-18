//-----------------------------------------------------------------------
// <copyright file="AgedItemTest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GildedRose.MS.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using GildedRose.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AgedItemTest
    {
        [TestMethod]
        public void Sulfuras_Quality_RemainsSame()
        {
            var updater = new QualityUpdater();

            var sulfuras = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};

            updater.Items = new List<Item> { sulfuras };

            updater.UpdateQuality();

            Assert.AreEqual(80, sulfuras.Quality);
        }

        [TestMethod]
        public void Sulfuras_SellIn_RemainsSame()
        {
            var updater = new QualityUpdater();

            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 1, Quality = 80 };

            updater.Items = new List<Item> { sulfuras };

            updater.UpdateQuality();

            Assert.AreEqual(1, sulfuras.SellIn);
        }

        [TestMethod]
        public void Brie_Quality_Increases_1()
        {
            var updater = new QualityUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            updater.Items = new List<Item> { brie };

            updater.UpdateQuality();

            Assert.AreEqual(1, brie.Quality);
        }

        [TestMethod]
        public void Brie_SellIn_Decreases_1()
        {
            var updater = new QualityUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            updater.Items = new List<Item> { brie };

            updater.UpdateQuality();

            Assert.AreEqual(1, brie.SellIn);
        }

        [TestMethod]
        public void Brie_Quality_NeverGoesOver_50()
        {
            var updater = new QualityUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };

            updater.Items = new List<Item> { brie };

            updater.UpdateQuality();

            Assert.AreEqual(50, brie.Quality);
        }

        [TestMethod]
        public void Brie_Quality_49_To_50()
        {
            var updater = new QualityUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 49 };

            updater.Items = new List<Item> { brie };

            updater.UpdateQuality();

            Assert.AreEqual(50, brie.Quality);
        }

        [TestMethod]
        public void Vest_Quality_DecreasesBy_1()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(19, item.Quality);
        }

        [TestMethod]
        public void Vest_SellIn_DecreasesBy_1()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(9, item.SellIn);
        }

        [TestMethod]
        public void Vest_Quality_Never_Negative()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_11_Days_Quality_Increases_1()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 0 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(1, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_10_Days_Quality_Increases_2()
        {
             var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 0 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_5_Days_Quality_Increases_3()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(3, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_6_Days_Quality_Increases_2()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 0 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_LessThan_0_Days_Quality_Is_0()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void BackstagePasses_50_DoesntGoOver_50()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
        }
    }
}

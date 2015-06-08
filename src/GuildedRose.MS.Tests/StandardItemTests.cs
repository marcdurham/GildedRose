﻿//-----------------------------------------------------------------------
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
    public class StandardItemTests
    {
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
        public void Vest_Quality_DecreasesBy_2_AfterSellInZero()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(18, item.Quality);
        }

        [TestMethod]
        public void Vest_Quality_DecreasesBy_2_AfterSellInNegative()
        {
            var updater = new QualityUpdater();

            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 18 };

            updater.Items = new List<Item> { item };

            updater.UpdateQuality();

            Assert.AreEqual(16, item.Quality);
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
    }
}

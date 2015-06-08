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
        public void Brie_Quality_Increases_1()
        {
            var updater = new ItemUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            updater.Items = new List<Item> { brie };

            updater.Update();

            Assert.AreEqual(1, brie.Quality);
        }

        [TestMethod]
        public void Brie_SellIn_Decreases_1()
        {
            var updater = new ItemUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            updater.Items = new List<Item> { brie };

            updater.Update();

            Assert.AreEqual(1, brie.SellIn);
        }

        [TestMethod]
        public void Brie_Quality_NeverGoesOver_50()
        {
            var updater = new ItemUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };

            updater.Items = new List<Item> { brie };

            updater.Update();

            Assert.AreEqual(50, brie.Quality);
        }

        [TestMethod]
        public void Brie_Quality_49_To_50()
        {
            var updater = new ItemUpdater();

            var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 49 };

            updater.Items = new List<Item> { brie };

            updater.Update();

            Assert.AreEqual(50, brie.Quality);
        }
    }
}

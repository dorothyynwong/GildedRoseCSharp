using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;
//     it('Brie increase in value by 2 if quality<50 & sellin < 0', () => {
//       const gildedRose = new GildedRose([new Item('Aged Brie', -1, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(42)
//     });

//     it('Backstage passes to a TAFKAL80ETC concert Quality drops to 0 once sellin < 0', () => {
//       const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', -1, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(0)
//     });

//     it('quality can never exceed 50 (for non Sulfuras items)', () =>{
//       const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 10, 50)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(50)
//     })

//     it('quality of Sulfuras is always 80', () =>{
//       const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 10, 80)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(80)
//     })


//     it('Backstages passes increase in value by 1 if quality<50 & sellin > 10', () => {
//       const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 11, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(41)
//     });

//     it('SellIn of Sulfuras doesnt change', () => {
//       const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', -5, 80)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].sellIn).to.equal(-5)
//     });

//     it('Conjured Mana Cake quality decreases by 2 each day', () => {
//       const gildedRose = new GildedRose([new Item('Conjured Mana Cake', 10, 30)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(28)
//     }); 

//     it('Conjured Mana Cake quality decreases by 4 each day after sellIn <0', () => {
//       const gildedRose = new GildedRose([new Item('Conjured Mana Cake', -1, 30)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(26)
//     }); 

//   });
// })



public class GildedRoseTest
{
    [Test]
    public void All_Items_Has_Name_SellIn_Quality() {
        var itemName = "genericItem";
        var items = new List<Item> { new Item { Name = itemName, SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo(itemName));
        Assert.That(items[0].Quality, Is.Not.Null);
        Assert.That(items[0].SellIn, Is.Not.Null);
    }
    [Test]
    public void All_Items_SellIn_Quality_should_lowered_() {
        var itemName = "genericItem";
        var sellIn = 15;
        var quality = 10;
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.LessThan(quality));
        Assert.That(items[0].SellIn, Is.LessThan(sellIn));
    }
    [Test]
    public void All_Items_SellIn_should_lowered_() {
        var itemName = "genericItem";
        var sellIn = 5;
        var quality = 40;
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality-1));
    }
    [Test]
    public void All_Items_Quality_should_lowered_by_2_when_sellin_less_than_0() {
        var itemName = "genericItem";
        var sellIn = -1;
        var quality = 40;
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality-2));
    }
    [Test]
    public void All_Items_Quality_never_less_than_0() {
        var itemName = "genericItem";
        var sellIn = -1;
        var quality = 0;
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    [Test]
    public void Brie_Quality_Increases_1_with_Quality_Less_Than_50_SellIn_Less_Than_11() {
        var itemName = "Aged Brie";
        var sellIn = 10;
        var quality = 40;
        var items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality+1));
    }
    [Test]
    public void Backstages_Quality_Increases_2_with__SellIn_Less_Between_6_and_10() {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var firstItemSellIn = 10;
        var secondItemSellIn = 6;
        var quality = 25;
        var items = new List<Item> { 
            new Item { Name = itemName, SellIn = firstItemSellIn, Quality = quality },
            new Item { Name = itemName, SellIn = secondItemSellIn, Quality = quality }, };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality+2));
        Assert.That(items[1].Quality, Is.EqualTo(quality+2));
    }
    [Test]
    public void Backstages_Quality_Increases_3_with__SellIn_Less_Between_1_and_5() {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var firstItemSellIn = 1;
        var secondItemSellIn = 5;
        var quality = 25;
        var items = new List<Item> { 
            new Item { Name = itemName, SellIn = firstItemSellIn, Quality = quality },
            new Item { Name = itemName, SellIn = secondItemSellIn, Quality = quality }, };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality+3));
        Assert.That(items[1].Quality, Is.EqualTo(quality+3));
    }
    [Test]
    public void Backstages_Quality_Increases_3_with__Quality_Than_50_SellIn_Less_Than_6() {
        var itemName = "Backstage passes to a TAFKAL80ETC concert";
        var itemSellIn = 5;
        var quality = 40;
        var items = new List<Item> { 
            new Item { Name = itemName, SellIn = itemSellIn, Quality = quality },
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality+3));
    }
    [Test]
    public void Sulfuras_SellIn_Not_Decrease() {
        var itemName = "Sulfuras, Hand of Ragnaros";
        var itemSellIn = 5;
        var quality = 80;
        var items = new List<Item> { 
            new Item { Name = itemName, SellIn = itemSellIn, Quality = quality },
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(itemSellIn));
    }
    [Test]
    public void Sulfuras_Quality_Not_Decrease() {
        var itemName = "Sulfuras, Hand of Ragnaros";
        var itemSellIn = 5;
        var quality = 80;
        var items = new List<Item> { 
            new Item { Name = itemName, SellIn = itemSellIn, Quality = quality },
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(quality));
    }
    [Test]
    public void GenericItemQualityNotReachSellIn() //not Aged Brie, not Backstage, Not Sulfuras
    {
        var items = new List<Item> { new Item { Name = "Generic Item", SellIn = 10, Quality = 5 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(4));
    }
    [Test]
    public void AgedBrieQualityLessThan50() // Aged Brie Quality < 50
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 5 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }
    [Test]
    public void BackstageQualityLessThan50SellInLessThan11() // Backstage Quality < 50, SellIn<11
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(7));
    }
    [Test]
    public void BackstageQualityLessThan50SellInLessThan6() // Backstage Quality < 50, SellIn<6
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
    [Test]
    public void BackstageQualityLessThan50SellInGreaterEqual11() // Backstage Quality < 50, SellIn >= 11
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(6));
    }
}
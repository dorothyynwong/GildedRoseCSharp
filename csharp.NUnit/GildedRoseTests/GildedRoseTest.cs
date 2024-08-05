using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

// describe('Gilded Rose', () => {
//   it('All items should have a name, SellIn and Quality' , () =>{
//     const itemName = 'genericItem'
//     const gildedRose = new GildedRose([new Item(itemName, 0, 0)])
//     const items = gildedRose.updateQuality()
//     expect(items[0].name).to.equal(itemName)
//     expect(items[0].quality).not.to.be.null
//     expect(items[0].sellIn).not.to.be.null
//   })

//   it('SellIn and Quality of items should be lowered after .updateQuality', () => {
//     const itemName = 'genericItem'
//     const itemSellIn = 15;
//     const itemQuality = 10;
//     const gildedRose = new GildedRose([new Item(itemName, itemSellIn, itemQuality)]);
//     const items = gildedRose.updateQuality();
//     expect(items[0].sellIn).to.be.lessThan(itemSellIn);
//     expect(items[0].quality).to.be.lessThan(itemQuality);
//   });

//   describe('Default objects', () => {

//     it('SellIn decreases by 1', () => {
//       const itemName = 'genericItem'
//       const gildedRose = new GildedRose([new Item(itemName, 5, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].sellIn).to.equal(4)
//     });

//     it('Quality decreases by 2 when sellIn < 0', () => {
//       const itemName = 'genericItem'
//       const gildedRose = new GildedRose([new Item(itemName, -1, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(38)
//     });

//     it('Quality never < 0', () => {
//       const itemName = 'genericItem'
//       const gildedRose = new GildedRose([new Item(itemName, -1, 0)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(0)
//     });
//   });

//   describe ('Special objects', () => {
//     it('Brie increase in value by 1 if quality<50 & sellin <= 10', () => {
//       const gildedRose = new GildedRose([new Item('Aged Brie', 10, 40)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(41)
//     });

//     it('Backstages passes increase in value by 2 if sellIn between 6-10', () => {
//       const firstItemSellIn = 10
//       const secondItemSellIn = 6
//       const itemQuality = 25
//       const expectedItemQuality = 27
//       const firstItem = new Item('Backstage passes to a TAFKAL80ETC concert', firstItemSellIn, itemQuality)
//       const secondItem = new Item('Backstage passes to a TAFKAL80ETC concert', secondItemSellIn, itemQuality)
//       const gildedRose = new GildedRose([firstItem,secondItem])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(expectedItemQuality)
//       expect(items[1].quality).to.equal(expectedItemQuality)
//     });

//     it('Backstages passes increase in value by 3 if sellin between 0-5', () => {
//       const firstItemSellIn = 0
//       const secondItemSellIn = 5
//       const itemQuality = 25
//       const expectedItemQuality = 28
//       const firstItem = new Item('Backstage passes to a TAFKAL80ETC concert', firstItemSellIn, itemQuality)
//       const secondItem = new Item('Backstage passes to a TAFKAL80ETC concert', secondItemSellIn, itemQuality)
//       const gildedRose = new GildedRose([firstItem,secondItem])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(expectedItemQuality)
//       expect(items[1].quality).to.equal(expectedItemQuality)
//     });

//   // it('Backstages passes increase in value by 3 if quality<50 & sellin <= 5', () => {
//   //   const gildedRose = new GildedRose([new Item('Backstage passes to a TAFKAL80ETC concert', 0, 40)])
//   //   const items = gildedRose.updateQuality()
//   //   expect(items[0].quality).to.equal(43)
//   // });

//     it('Sulfuras, Hand of Ragnaros sellIn does not decrease', () => {
//       const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 5, 80)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].sellIn).to.equal(5)
//     });

//     it('Sulfuras, Hand of Ragnaros quality does not decrease', () => {
//       const gildedRose = new GildedRose([new Item('Sulfuras, Hand of Ragnaros', 5, 80)])
//       const items = gildedRose.updateQuality()
//       expect(items[0].quality).to.equal(80)
//     });



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
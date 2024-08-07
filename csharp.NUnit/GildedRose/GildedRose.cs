using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            switch (Items[i].Name) {
                case "Aged Brie":
                    Items[i].SellIn--;
                    if (Items[i].Quality < 50) {
                        if(Items[i].SellIn < 0)
                            Items[i].Quality+=2;
                        else
                            Items[i].Quality++;
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (Items[i].Quality < 50) Items[i].Quality = Items[i].Quality + 1;
                    if (Items[i].SellIn < 11 && Items[i].Quality < 50) Items[i].Quality = Items[i].Quality + 1;
                    if (Items[i].SellIn < 6 && Items[i].Quality < 50) Items[i].Quality = Items[i].Quality + 1;
                    Items[i].SellIn = Items[i].SellIn - 1;
                    if (Items[i].SellIn < 0) Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    if (Items[i].Quality > 0) Items[i].Quality--;
                    Items[i].SellIn = Items[i].SellIn - 1;
                     if (Items[i].SellIn < 0 && Items[i].Quality > 0 )Items[i].Quality = Items[i].Quality - 1;
                    break;
            }
        }
    }
}
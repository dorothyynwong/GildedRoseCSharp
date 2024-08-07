using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    private int CalculateNewQualityFromSellIn(int sellIn, int quality)
    {
        switch (sellIn)
        {
            case <= 0:
                quality = 0;
                break;
            case < 6:
                quality = Math.Min(50,quality+3);
                break;
            case < 11:
                quality = Math.Min(50,quality+2);
                break;
            default:
                quality = Math.Min(50,quality+1);
                break;
        }
        return quality;
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
                    if (Items[i].Quality < 50) {
                        Items[i].Quality = CalculateNewQualityFromSellIn(Items[i].SellIn, Items[i].Quality);
                    }
                    Items[i].SellIn--;
                    if (Items[i].SellIn < 0) Items[i].Quality = 0;
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
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheLordsWill.Content.Items;
public class AmmoModificationsGlobalItem : GlobalItem
{
    public override void SetDefaults(Item item)
    {
        // We type "item" here instead of "Item" because this item is a parameter named "item".
        if (item.type == ItemID.Cannonball)
        {
            item.ammo = ItemID.Cannonball;
        }
    }
}
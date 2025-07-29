using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLordsWill.Items;

public class WalkingStick : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Walking Stick");
        Tooltip.SetDefault("A sturdy walking stick.");
    }

    public override void SetDefaults()
    {
        item.width = 10;
        item.height = 30;
        item.rare = ItemRarityID.Common;
        item.value = Item.buyPrice(silver: 5);
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLordsWill.Content.Items.Weapons;

public class Squire_Sword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Squire's Sword"); //Sets Item name
        Tooltip.SetDefault("Once belonged to a great warrior. \nRight click to parry incoming projectiles."); //Sets tooltip when hovering in inventory
    }
    public override void SetDefaults()
    {
        Item.damage = 25;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 37;
        Item.useTime = 15;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 7;
        Item.value = Item.buyPrice(gold: 1);
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override bool AltFunctionUse(Player player) //You use this to allow the Item to be right clicked
    {
        return true;
    }

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2) //Sets what happens on right click (special ability)
        {

            Item.useStyle = ItemUseStyleId.Shoot;

            foreach (Entity entity in IEntitySource)
                if (IsInRangeOfMeOrMyOwner())
                {
                        
                }

        }
        else //Sets what happens on left click (normal use)
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 37;
            Item.useTime = 15;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    return true;
    }
}

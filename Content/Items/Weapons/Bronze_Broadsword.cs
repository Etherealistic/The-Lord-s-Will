using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLordsWill.Content.Items.Weapons;

public class Bronze_Bronzesword : ModItem
{
    // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.FUCKYOUDUCKYOUFUCKYOU.hjson' file.
	public override void SetDefaults()
	{
        Item.damage = 13;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 18;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6.5;
        Item.value = Item.buyPrice(silver: 16);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Bronze_Bar, 8);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}

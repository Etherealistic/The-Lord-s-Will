using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLordsWill.Content.Tiles;

namespace TheLordsWill.Content.Items.Tools;

public class Bronze_Pickaxe : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 6;
        Item.DamageType = DamageClass.Melee;
        Item.width = 32;
        Item.height = 32;
        Item.useTime = 17;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 2;
        Item.value = Item.buyPrice(silver: 15);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.pick = 52;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient<Placeables.Bronze_Bar>(10);
        recipe.AddIngredient(RecipeGroupID.Wood, 4);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheLordsWill.Content.Tiles;

namespace TheLordsWill.Content.Items.Tools;

public class Bronze_Axe : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 7;
        Item.DamageType = DamageClass.Melee;
        Item.width = 50;
        Item.height = 40;
        Item.useTime = 18;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4.5f;
        Item.value = Item.buyPrice(silver: 15);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.axe = 13;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<Bronze_Bar>, 8);
        recipe.AddIngredient(RecipeGroupID.Wood, 4);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}

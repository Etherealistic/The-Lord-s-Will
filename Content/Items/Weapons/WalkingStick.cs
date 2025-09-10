using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheLordsWill.Content.Items.Weapons;

public class WalkingStick : ModItem
{
    // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.FUCKYOUDUCKYOUFUCKYOU.hjson' file.
	public override void SetDefaults()
	{
        Item.damage = 5;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 37;
        Item.useTime = 13;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 7;
        Item.value = Item.buyPrice(silver: 2);
        Item.rare = ItemRarityID.White;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
    {
        // Separate item display in inventory
        Texture2D texture = ModContent.Request<Texture2D>("TheLordsWill/Content/Items/Weapons/WalkingStickInventory").Value;
        spriteBatch.Draw(texture, position, null, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
        return false;  //Stops default drawing
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.DirtBlock, 10);
        recipe.AddTile(TileID.WorkBenches);
        recipe.Register();
    }
}

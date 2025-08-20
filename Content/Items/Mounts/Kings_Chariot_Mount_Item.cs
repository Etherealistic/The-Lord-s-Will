using TheLordsWill.Content.Mounts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheLordsWill.Content.Items.Mounts
{
	public class Kings_Chariot_Mount_Item : ModItem
	{
		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing; // how the player's arm moves when using the item
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item79; // What sound should play when using the item
			Item.noMelee = true; // this item doesn't do any melee damage
			Item.mountType = ModContent.MountType<Kings_Chariot_Mount>();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(RecipeGroupID.Wood, 4)
				.AddTile<Tiles.Anvils>()
				.Register();
		}
	}
}


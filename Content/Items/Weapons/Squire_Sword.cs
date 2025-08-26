using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace TheLordsWill.Content.Items.Weapons;

public class Squire_Sword : ModItem
{
    public override void SetDefaults()
    {
        Item.damage = 25;
        Item.DamageType = DamageClass.Melee;
        Item.width = 32;
        Item.height = 32;
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

            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 0;
            Item.noMelee = true;

        }
        else //Sets what happens on left click (normal use)
        {
            Item.damage = 25;
            Item.noMelee = false;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        return true;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        if (player.altFunctionUse == 2) // Right click (parry)
        {
            // Define parry hitbox
            Rectangle parryHitbox = new Rectangle(
                (int)(player.position.X + (player.direction == 1 ? 0 : -40)),
                (int)(player.position.Y - 20),
                40,
                40
            );

            // Check for projectiles in the parry hitbox
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && !projectile.friendly && projectile.hostile)
                {
                    Rectangle projectileHitbox = new Rectangle(
                        (int)projectile.position.X,
                        (int)projectile.position.Y,
                        projectile.width,
                        projectile.height
                    );

                    if (parryHitbox.Intersects(projectileHitbox))
                    {
                        // Destroy the projectile
                        projectile.Kill();

                        // Give player brief defense buff (5 seconds)
                        player.AddBuff(ModContent.BuffType<Buffs.Riposte>(), 300);

                        // Visual and audio feedback
                        for (int d = 0; d < 10; d++)
                        {
                            Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Iron);
                        }
                        SoundEngine.PlaySound(SoundID.Item37, player.position);
                    }
                }
            }
        }
    }
}
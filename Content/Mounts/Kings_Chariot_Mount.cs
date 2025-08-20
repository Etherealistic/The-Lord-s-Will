using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TheLordsWill.Content.Mounts
{
    public class Kings_Chariot_Mount : ModMount
    {
        public override void SetStaticDefaults()
        {
            // Movement
            MountData.jumpHeight = 5; // How high the mount can jump.
            MountData.acceleration = 0.19f; // The rate at which the mount speeds up.
            MountData.jumpSpeed = 4f; // The rate at which the player and mount ascend towards (negative y velocity) the jump height when the jump button is pressed.
            MountData.blockExtraJumps = false; // Determines whether or not you can use a double jump (like cloud in a bottle) while in the mount.
            MountData.constantJump = true; // Allows you to hold the jump button down.
            MountData.heightBoost = 20; // Height between the mount and the ground
            MountData.fallDamage = 0.5f; // Fall damage multiplier.
            MountData.runSpeed = 11f; // The speed of the mount
            MountData.dashSpeed = 8f; // The speed the mount moves when in the state of dashing.
            MountData.flightTimeMax = 0; // The amount of time in frames a mount can be in the state of flying.

            // Misc
            MountData.fatigueMax = 0;
            MountData.buff = ModContent.BuffType<Buffs.Kings_Chariot_Buff>(); // The ID number of the buff assigned to the mount.

            // Frame data and player offsets
            MountData.playerYOffsets = new int[] { 21, 20 }; // where is the players Y position on the mount for each frame of animation
            MountData.totalFrames = 2; // Amount of animation frames for the mount

            MountData.runningFrameCount = 2;
            MountData.runningFrameDelay = 60;

            MountData.xOffset = -20;
            MountData.yOffset = 0;
            MountData.playerHeadOffset = 12;
            MountData.bodyFrame = 3;

            if (!Main.dedServ)
            {
                MountData.textureWidth = 194;
                MountData.textureHeight = 132;
            }

        }
        
        // trying to spawn invisible projectile that acts as the crash -- UNSOLVED
        // private int _delay = 0;
        // public override void UpdateEffects(Player player)
        // {
        //     _delay++;
        //     if (_delay >= 30)
        //     {
        //         _delay = 0;
        //         if (Main.netMode != 1)
        //         {
        //             Projectile.NewProjectile(0, 0, 0, ModContent.ProjectileType<Projectiles.InvisibleProjectile>, 50, 3f, Main.myPlayer);
        //         }
        //     }
        // }
    }
}
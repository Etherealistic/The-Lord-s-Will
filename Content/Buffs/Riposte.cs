using Terraria;
using Terraria.ModLoader;

namespace TheLordsWill.Content.Buffs
{
	public class Riposte : ModBuff
	{
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
            Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) *= 2;
            player.moveSpeed += 10;
        }
	}
}
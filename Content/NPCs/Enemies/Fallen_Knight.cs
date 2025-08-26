using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader.Utilities;
using TheLordsWill.Content.Items.Weapons;

namespace TheLordsWill.Content.NPCs.Enemies
{
    internal class Fallen_Knight : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Zombie];

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.PossessedArmor);
            NPC.damage = 20;
            NPC.defense = 12;
            NPC.lifeMax = 80;
            NPC.value = 600f;
            NPC.knockBackResist = 0.5f;

            AIType = NPCID.PossessedArmor;
            

            Banner = Item.NPCtoBanner(NPCID.PossessedArmor);
            BannerItem = Item.BannerToItem(Banner);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var possessedArmorDropRule = Main.ItemDropsDB.GetRulesForNPCID(NPCID.PossessedArmor, false);
            foreach(var rule in possessedArmorDropRule)
            {
                npcLoot.Add(rule);
            }

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Squire_Sword>(), 2, 0, 1));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance - 0.65f;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                new FlavorTextBestiaryInfoElement("A knight which has lost his soul.")
            });
        }
    }
}
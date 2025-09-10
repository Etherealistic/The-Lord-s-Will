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
            Main.npcFrameCount[Type] = 9;

            NPCID.Sets.ShimmerTransformToNPC[NPC.type] = NPCID.Skeleton;

            NPCID.Sets.NPCBestiaryDrawModifiers value = new()
            {
                Velocity = 1f
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        private const int State_Jump = 1;
		private const int State_Walk = 0;
        private const int AI_State_Slot = 0;
        public float AI_State
        {
            get => NPC.ai[AI_State_Slot];
            set => NPC.ai[AI_State_Slot] = value;
        }

        public override void SetDefaults()
        {
            NPC.CloneDefaults(NPCID.PossessedArmor);
            NPC.damage = 20;
            NPC.defense = 12;
            NPC.lifeMax = 80;
            NPC.value = 600f;
            NPC.knockBackResist = 0.7f;

            AIType = NPCID.PossessedArmor;

            Banner = Item.NPCtoBanner(NPCID.PossessedArmor);
            BannerItem = Item.BannerToItem(Banner);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var possessedArmorDropRule = Main.ItemDropsDB.GetRulesForNPCID(NPCID.PossessedArmor, false);
            foreach (var rule in possessedArmorDropRule)
            {
                npcLoot.Add(rule);
            }

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Squire_Sword>(), 2, 0, 1));
        }

        

        public override void FindFrame(int frameHeight) {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            NPC.spriteDirection = NPC.direction;

            // For the most part, our animation matches up with our states.
            if (AI_State == State_Jump) {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                NPC.frame.Y = 0;
            }
            else {
                // I hate this with all my heart
                NPC.frameCounter++;
                for (int i = 10; i <= 80; i += 10)
                {
                    if (NPC.frameCounter < i)
                    {
                        NPC.frame.Y = i / 10 * frameHeight;
                        break;
                    }

                if (NPC.frameCounter >= 80)
                {
                    NPC.frameCounter = 0;
                }
                }
            }
        }




        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNight.Chance - 0.65f;
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
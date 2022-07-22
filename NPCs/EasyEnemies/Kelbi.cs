using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using NimblesThrowingStuff;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class Kelbi : ModNPC
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kelbi");
            Main.npcFrameCount[NPC.type] = 9;
		}

		public override void SetDefaults()
		{
			NPC.width = 60;
			NPC.height = 60;
			NPC.aiStyle = -1;
			NPC.damage = 8;
			NPC.defense = 2;
			NPC.lifeMax = 20;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
            // AIType = 174;
            // animationType = 174;
            Banner = NPC.type;
			BannerItem = Mod.Find<ModItem>("KelbiBannerItem").Type;
        }
        public override void AI()
        {
            NPC.ai[1]++;
            if (NPC.life == NPC.lifeMax)
            {
                if (NPC.ai[1] == 300)
                {
                    if (Main.rand.NextBool(2))
                    {
                        NPC.ai[1] += 60 + Main.rand.Next(181);
                    }
                    else 
                    {
                        NPC.ai[1] += 360 + Main.rand.Next(181);
                    }
                }
                if (NPC.ai[1] >= 360 && NPC.ai[1] <= 600)
                {
                    if (NPC.velocity.X <= 0)
                    {
                    NPC.velocity.X = 1;
                        }
                    NPC.direction = 1;
                }
                if (NPC.ai[1] >= 600 && NPC.ai[1] <= 660)
                {
                    NPC.ai[1] = 0 + Main.rand.Next(151);
                }
                if (NPC.ai[1] >= 660 && NPC.ai[1] <= 900)
                {
                    if (NPC.velocity.X >= 0)
                    {
                        NPC.velocity.X = -1;
                    }
                    NPC.direction = -1;
                }
                if (NPC.ai[1] >= 900 && NPC.ai[1] <= 960)
                {
                    NPC.ai[1] = 0 + Main.rand.Next(151);
                }
                else
                {
                    if (NPC.ai[1] <= 300)
                    {
                        NPC.velocity.X *= 0.95f;
                    }
                }
            }
            else if (NPC.life < NPC.lifeMax)
            {
                if (NPC.ai[1] == 330)
                {
                    if (Main.rand.NextBool(2))
                    {
                        NPC.velocity.X = 6 + Main.rand.Next(3);
                        NPC.direction = 1;
                    }
                    else
                    {
                        NPC.velocity.X = -6 - Main.rand.Next(3);
                        NPC.direction = -1;
                    }
                    NPC.velocity.Y = -8 + Main.rand.Next(4);
                }
                NPC.velocity.X *= 0.9875f;
                // npc.velocity.Y += 0.05f;
                if (NPC.velocity.Y == 0 && NPC.life < NPC.lifeMax && NPC.ai[1] >= 331)
                {
                    NPC.velocity.X *= 0.95f;
                    NPC.ai[1] = 300 + Main.rand.Next(-11, 31);
                }
            }
            else
            {
                NPC.velocity.Y -= 0.25f;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {

                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KelbiHead").Type, 1f);
                for (int index = 0; index < 4; index++)
                {
                    Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KelbiLeg").Type, 1f);
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.spriteDirection = NPC.direction;
            NPC.frameCounter++;
            if (NPC.ai[1] >= 300 && NPC.ai[1] <= 960 && NPC.life == NPC.lifeMax)
            {
                if (NPC.frameCounter < 15)
                {
                    NPC.frame.Y = 1 * frameHeight;
                }
                else if (NPC.frameCounter < 30)
                {
                    NPC.frame.Y = 2 * frameHeight;
                }
                else if (NPC.frameCounter < 45)
                {
                    NPC.frame.Y = 3 * frameHeight;
                }
                else if (NPC.frameCounter < 60)
                {
                    NPC.frame.Y = 4 * frameHeight;
                }
                else
                {
                    NPC.frameCounter = 0;
                }

            }
            else if (NPC.ai[1] >= 300 && NPC.life != NPC.lifeMax && NPC.velocity.Y != 0)
            {
                if (NPC.frameCounter < 15)
                {
                    NPC.frame.Y = 6 * frameHeight;
                }
                else if (NPC.frameCounter < 30)
                {
                    NPC.frame.Y = 7 * frameHeight;
                }
                else 
                {
                    NPC.frame.Y = 8 * frameHeight;
                }
            }
            else if (NPC.ai[1] >= 300 && NPC.ai[1] <= 330 && NPC.life < NPC.lifeMax)
            {
                NPC.frame.Y = 5 * frameHeight;
                NPC.frameCounter = 0;
            }
            else
            {
                NPC.frame.Y = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
        }
		public override void OnKill()
		{
            //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiHead"), 1f);
            //for (int index = 0; index < 4; index++)
            //{
                //int Kelbileg = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiLeg"), 1f);
            //}
            //Item.NewItem(NPC.GetSource_FromThis(), NPC.getRect(), Mod.Find<ModItem>("BeastBone").Type, Main.rand.Next(3));
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("BeastBone").Type, 3));
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("These deer-like herbivores fall prey to all sorts of species, including humans.")
            });
        }
    }
}
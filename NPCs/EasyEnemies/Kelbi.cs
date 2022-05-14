using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using NimblesThrowingStuff;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class Kelbi : ModNPC
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kelbi");
            Main.npcFrameCount[npc.type] = 9;
		}

		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 60;
			npc.aiStyle = -1;
			npc.damage = 8;
			npc.defense = 2;
			npc.lifeMax = 20;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
            // aiType = 174;
            // animationType = 174;
            banner = npc.type;
			bannerItem = mod.ItemType("KelbiBannerItem");
        }
        public override void AI()
        {
            npc.ai[1]++;
            if (npc.life == npc.lifeMax)
            {
                if (npc.ai[1] == 300)
                {
                    if (Main.rand.NextBool(2))
                    {
                        npc.ai[1] += 60 + Main.rand.Next(181);
                    }
                    else 
                    {
                        npc.ai[1] += 360 + Main.rand.Next(181);
                    }
                }
                if (npc.ai[1] >= 360 && npc.ai[1] <= 600)
                {
                    npc.velocity.X = 1;
                    npc.direction = 1;
                }
                if (npc.ai[1] >= 600 && npc.ai[1] <= 660)
                {
                    npc.ai[1] = 0 + Main.rand.Next(151);
                }
                if (npc.ai[1] >= 660 && npc.ai[1] <= 900)
                {
                    npc.velocity.X = -1;
                    npc.direction = -1;
                }
                if (npc.ai[1] >= 900 && npc.ai[1] <= 960)
                {
                    npc.ai[1] = 0 + Main.rand.Next(151);
                }
                else
                {
                    npc.velocity.X *= 0.95f;
                }
            }
            else if (npc.life < npc.lifeMax)
            {
                if (npc.ai[1] == 330)
                {
                    if (Main.rand.NextBool(2))
                    {
                        npc.velocity.X = 6 + Main.rand.Next(3);
                        npc.direction = 1;
                    }
                    else
                    {
                        npc.velocity.X = -6 - Main.rand.Next(3);
                        npc.direction = -1;
                    }
                    npc.velocity.Y = -8 + Main.rand.Next(4);
                }
                npc.velocity.X *= 0.9875f;
                // npc.velocity.Y += 0.05f;
                if (npc.velocity.Y == 0 && npc.life < npc.lifeMax && npc.ai[1] >= 331)
                {
                    npc.velocity.X *= 0.95f;
                    npc.ai[1] = 300 + Main.rand.Next(-11, 31);
                }
            }
            else
            {
                npc.velocity.Y -= 0.25f;
            }
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiHead"), 1f);
                for (int index = 0; index < 4; index++)
                {
                    Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiLeg"), 1f);
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter++;
            if (npc.ai[1] >= 300 && npc.ai[1] <= 960 && npc.life == npc.lifeMax)
            {
                if (npc.frameCounter < 15)
                {
                    npc.frame.Y = 1 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = 2 * frameHeight;
                }
                else if (npc.frameCounter < 45)
                {
                    npc.frame.Y = 3 * frameHeight;
                }
                else if (npc.frameCounter < 60)
                {
                    npc.frame.Y = 4 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }

            }
            else if (npc.ai[1] >= 300 && npc.life != npc.lifeMax && npc.velocity.Y != 0)
            {
                if (npc.frameCounter < 15)
                {
                    npc.frame.Y = 6 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = 7 * frameHeight;
                }
                else 
                {
                    npc.frame.Y = 8 * frameHeight;
                }
            }
            else if (npc.ai[1] >= 300 && npc.ai[1] <= 330 && npc.life < npc.lifeMax)
            {
                npc.frame.Y = 5 * frameHeight;
                npc.frameCounter = 0;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.25f;
        }
		public override void NPCLoot()
		{
            //Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiHead"), 1f);
            //for (int index = 0; index < 4; index++)
            //{
                //int Kelbileg = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiLeg"), 1f);
            //}
            Item.NewItem(npc.getRect(), mod.ItemType("BeastBone"), Main.rand.Next(3));
        }
	}
}
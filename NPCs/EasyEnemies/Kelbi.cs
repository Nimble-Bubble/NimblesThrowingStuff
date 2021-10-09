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
            Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 72;
			npc.aiStyle = 41;
			npc.damage = 10;
			npc.defense = 2;
			npc.lifeMax = 35;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
            // aiType = 174;
            animationType = 174;
            banner = npc.type;
			bannerItem = mod.ItemType("KelbiBannerItem");
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
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.75f;
        }
		public override void NPCLoot()
		{
            int Kelbihead = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiHead"), 1f);
            for (int index = 0; index < 4; index++)
            {
                int Kelbileg = Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/KelbiLeg"), 1f);
            }
        }
	}
}
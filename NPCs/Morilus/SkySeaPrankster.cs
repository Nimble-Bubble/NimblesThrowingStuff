using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.NPCs.Morilus
{
    public class SkySeaPrankster : ModNPC
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prankster of the Sky Sea");
            Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 26;
			npc.aiStyle = 44;
			npc.damage = 120;
			npc.defense = 70;
			npc.lifeMax = 625;
			npc.HitSound = SoundID.NPCHit3;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.knockBackResist = 0.5f;
        }
        public override void AI()
        {
			npc.rotation = npc.velocity.X * 0.05f;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (NPC.downedMoonlord && spawnInfo.player.ZoneSkyHeight)
			{
				return 0.35f;
			}
			return 0f;
		}
		public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;

                if (npc.frameCounter < 10) {
					npc.frame.Y = 0 * frameHeight;
				}
				else if (npc.frameCounter < 20) {
					npc.frame.Y = 1 * frameHeight;
				}
				else if (npc.frameCounter < 30) {
					npc.frame.Y = 2 * frameHeight;
				}
                else if (npc.frameCounter < 40) {
					npc.frame.Y = 3 * frameHeight;
				}
				else {
					npc.frameCounter = 0;
				} 
        }
	}
}
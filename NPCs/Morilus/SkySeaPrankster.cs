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
            Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 26;
			NPC.height = 26;
			NPC.aiStyle = 44;
			NPC.damage = 120;
			NPC.defense = 70;
			NPC.lifeMax = 625;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.knockBackResist = 0.5f;
        }
        public override void AI()
        {
			NPC.rotation = NPC.velocity.X * 0.05f;
		}
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (NPC.downedMoonlord && spawnInfo.Player.ZoneSkyHeight)
			{
				return 0.35f;
			}
			return 0f;
		}
		public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;

                if (NPC.frameCounter < 10) {
					NPC.frame.Y = 0 * frameHeight;
				}
				else if (NPC.frameCounter < 20) {
					NPC.frame.Y = 1 * frameHeight;
				}
				else if (NPC.frameCounter < 30) {
					NPC.frame.Y = 2 * frameHeight;
				}
                else if (NPC.frameCounter < 40) {
					NPC.frame.Y = 3 * frameHeight;
				}
				else {
					NPC.frameCounter = 0;
				} 
        }
		public override void OnKill()
		{
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity.RotatedBy(MathHelper.ToRadians(90f)), Mod.Find<ModGore>("SkySeaPranksterGore2").Type, 1f);
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SkySeaPranksterGore1").Type, 1f);
			Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity * new Vector2(-1, -1), Mod.Find<ModGore>("SkySeaPranksterGore1").Type, 1f);
		}
	}
}
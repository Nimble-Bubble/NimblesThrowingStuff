using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class Mimiclam : ModNPC
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clam");
            Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.width = 26;
			npc.height = 26;
			npc.aiStyle = 25;
			npc.damage = 25;
			npc.defense = 12;
			npc.lifeMax = 120;
			npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.knockBackResist = 0.1f;
            animationType = 341;
            banner = npc.type;
			bannerItem = mod.ItemType("MimiclamBannerItem");
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OceanMonster.Chance * 0.75f;
        }
		public override void NPCLoot()
		{
            Item.NewItem(npc.getRect(), 2625, 1);
            for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 194,
                            npc.velocity.X * 0.1f, npc.velocity.Y * 0.1f, 0, new Color(), 0.75f);
			
        }
	}
}
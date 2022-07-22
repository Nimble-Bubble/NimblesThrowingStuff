using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace NimblesThrowingStuff.NPCs.EasyEnemies
{
    public class Mimiclam : ModNPC
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Clam");
            Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 26;
			NPC.height = 26;
			NPC.aiStyle = 25;
			NPC.damage = 25;
			NPC.defense = 12;
			NPC.lifeMax = 70;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.knockBackResist = 0.1f;
            AnimationType = 341;
            Banner = NPC.type;
			BannerItem = Mod.Find<ModItem>("MimiclamBannerItem").Type;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OceanMonster.Chance * 0.75f;
        }
		public override void OnKill()
		{
            Item.NewItem(NPC.GetSource_FromThis(), NPC.getRect(), 2625, 1);
            for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 194,
                            NPC.velocity.X * 0.1f, NPC.velocity.Y * 0.1f, 0, new Color(), 0.75f);
			
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean,
                new FlavorTextBestiaryInfoElement("This particular species of bivalve is rather feisty.")
            });
        }
    }
}
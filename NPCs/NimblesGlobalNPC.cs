using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Melee;
using NimblesThrowingStuff.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.NPCs
{
    public class NimblesGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool greek;
		public bool compromise;
        public override void ResetEffects(NPC npc)
        {
            greek = false;
			compromise = false;
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
            if (greek)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 100; //That's even worse!
			}
			if (npc.HasBuff(BuffID.Bleeding))
            {
				if (npc.lifeRegen > 0)
                {
					npc.lifeRegen = 0;
                }
				npc.lifeRegen -= 10;
            }
			if (compromise)
            {
				if (npc.boss)
                {
					// Do nothing
                }
				else
                {
					npc.knockBackResist += 0.25f;
                }
            }
            
        }
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.player[Main.myPlayer];
            switch (type)
            {
            case 19:
                    if (NPC.downedBoss2 && !Main.dayTime || Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<HealingArrow>());
                        nextSlot++;
                    }
                    break;
            case 209:
                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<NanoMissile>());
                        nextSlot++;
                    }
                    break;
			case 368:
					if (NPC.downedMoonlord && Main.moonPhase % 2 == 0)
                    {
						shop.item[nextSlot].SetDefaults(ItemType<Superfast>());
						nextSlot++;
                    }
					break;

            }
        }

		public override void OnKill(NPC npc)
		{
			if (Main.hardMode && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.value > 0f && Main.rand.NextBool(Main.expertMode ? 2 : 1, 5))
			{
				if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight)
				{
					Item.NewItem(npc.getRect(), ItemType<SoulOfTrite>(), 1);
				}
			}
			if (npc.type == 222 && Main.rand.NextBool(4) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<Beemerang>(), 1);
			}
            if (npc.type == NPCID.WallofFlesh && Main.rand.NextBool(7) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ThrowerEmblem>(), 1);
			}
            if (npc.type == 262 && Main.rand.NextBool(4) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ThornyGlove>(), 1);
			}
            if (npc.type == 245 && Main.rand.NextBool(4) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<GolemGlove>(), 1);
			}
            if (npc.type == NPCID.DukeFishron && Main.rand.NextBool(5) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<PoseironTrident>(), 1);
			}
            if (npc.type == NPCID.DukeFishron && Main.rand.NextBool(5) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<PoseironTrident>(), 1);
			}
            if (npc.type == 398 && Main.rand.NextBool(5) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<CosmosCrasher>(), 1);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SatelliteSpear>(), 1);
			}
            if (npc.type == 392 && Main.rand.NextBool(5))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<MartianMiracle>(), 1);
			}
            if (npc.type == NPCID.BigMimicHallow && Main.rand.NextBool(4))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SacredWristband>(), 1);
			}
            if (npc.type == 43 && Main.rand.NextBool(15))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<HealthEater>(), 1); //??? 
			}
            if (npc.type == 49 || npc.type == 93)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BatFlesh>(), 1);
            }
            if (npc.type == 48 && NPC.downedBoss3 && Main.rand.NextBool(25))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<CumulusCrasher>(), 1);
			}
            if (npc.type == 62 && NPC.downedBoss3)
			{
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ShadowJavelin>(), Main.rand.Next(10, 21));
            if (Main.rand.NextBool(20))
                {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<DemonClaw>(), 1);
                }
			}
            if (npc.type == 471)
			{
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ShadowflameSpikeBall>(), Main.rand.Next(125, 251));
            }
            if (npc.type >= 338 && npc.type <= 340 && Main.rand.NextBool(2) || npc.type >= 347 && npc.type <= 350 && Main.rand.NextBool(2))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<FestiveCloth>(), 1);
			}
            if (npc.type >= 269 && npc.type <= 272)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<RustyBonesAxe>(), Main.rand.Next(10, 21));
			}
            if (npc.type >= 273 && npc.type <= 276)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BrokeBonesAxe>(), Main.rand.Next(10, 21));
			}
            if (npc.type >= 277 && npc.type <= 280)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<HellBonesAxe>(), Main.rand.Next(10, 21));
			}
            if (npc.type == NPCID.SantaNK1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<FestiveCloth>(), Main.rand.Next(7, 13));
			}
            if (npc.type == 345 && Main.rand.NextBool(10))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SnowflakeShuriken>(), 1);
			}
            if (npc.type == 325 && Main.rand.NextBool(20))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SpookySpines>(), 1);
			}
            if (npc.type == 327 && Main.rand.NextBool(10))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<UnholyHandGrenade>(), 1);
			}
            if (npc.type == 158 && Main.rand.NextBool(25) || npc.type == 159 && Main.rand.NextBool(25))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<BloodyPike>(), 1);
			}
		}
    }
}
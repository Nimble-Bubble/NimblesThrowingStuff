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
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.NPCs
{
	public class NimblesGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool greek;
		public bool compromise;
		public bool drowndebuff;
		public override void ResetEffects(NPC npc)
		{
			greek = false;
			compromise = false;
			drowndebuff = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (npc.HasBuff(BuffID.Wet))
			{
				if (npc.HasBuff(BuffID.OnFire3))
                {
					npc.lifeRegen += 10;
                }
				npc.buffImmune[BuffID.OnFire] = true;
			}
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
			if (npc.HasBuff(BuffID.Electrified))
            {
				if (npc.HasBuff(BuffID.Wet))
                {
					npc.lifeRegen *= 2;
                }
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				if (npc.velocity.X != 0)
                {
					npc.lifeRegen -= 24;
				}
				npc.lifeRegen -= 8;
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
			if (drowndebuff)
            {
				if (npc.lifeRegen > 0)
                {
					npc.lifeRegen = 0;
                }
				npc.lifeRegen -= 14;
            }

		}
		public override void ModifyShop(NPCShop shop)
		{
				Player player = Main.player[Main.myPlayer];
				switch (shop.NpcType)
				{
					case 17:
						shop.Add<GreenQurupecoFeather>(Condition.MoonPhases04, Condition.DownedEyeOfCthulhu);
						break;
					case 19:
						shop.Add<HealingArrow>(Condition.DownedEowOrBoc, Condition.TimeNight);
						break;
					case 209:
						shop.Add<NanoMissile>();
						break;
					case 368:
						shop.Add<Superfast>(Condition.DownedMoonLord, Condition.MoonPhasesOdd);
						break;
				}
		}
		public override void OnKill(NPC npc)
		{
			if (NPC.downedMoonlord && !npc.boss && npc.lifeMax > 1 && npc.damage > 0 && !npc.friendly && npc.value > 0f && Main.rand.NextBool(Main.expertMode ? 2 : 1, 5))
			{
				if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt || Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson || Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHallow)
				{
					Item.NewItem(npc.GetSource_FromThis(), npc.getRect(), ItemType<EssenceOfBalance>(), 1);
				}
				if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSkyHeight)
				{
					Item.NewItem(npc.GetSource_FromThis(), npc.getRect(), ItemType<SoulOfTrite>(), 1);
				}
			}
		}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
			//Now, a lot of this could theoretically be done through switch instead, but I'll settle with this for now
			if (npc.type == 158 || npc.type == 159)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<BloodyPike>(), 25));
			}
			if (npc.type == 327)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<UnholyHandGrenade>(), 10));
			}
			if (npc.type == 325)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<SpookySpines>(), 10));
			}
			if (npc.type == 345)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<SnowflakeShuriken>(), 10));
			}
			if (npc.type == NPCID.SantaNK1)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<FestiveCloth>(), 1, 7, 12));
			}
			if (npc.type >= 277 && npc.type <= 280)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<HellBonesAxe>(), 3, 10, 20));
			}
			if (npc.type >= 273 && npc.type <= 276)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<BrokeBonesAxe>(), 3, 10, 20));
			}
			if (npc.type >= 269 && npc.type <= 272)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<RustyBonesAxe>(), 3, 10, 20));
			}
			if (npc.type >= 338 && npc.type <= 340 || npc.type >= 347 && npc.type <= 350)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<FestiveCloth>(), 2));
			}
			if (npc.type == 471)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<ShadowflameSpikeBall>(), 1, 125, 250));
			}
			if (npc.type == 62 && NPC.downedBoss3)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<ShadowJavelin>(), 3, 20, 30));
				npcLoot.Add(ItemDropRule.Common(ItemType<DemonClaw>(), 25));
			}
			if (npc.type == 48 && NPC.downedBoss3)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<CumulusCrasher>(), 20));
			}
			if (npc.type == 49 || npc.type == 93)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<BatFlesh>(), 3, 1, 3));
			}
			if (npc.type == NPCID.BigMimicHallow)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<SacredWristband>(), 4));
			}
			if (npc.type == 392)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<MartianMiracle>(), 5));
			}
			if (npc.type == 398)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<CosmosCrasher>(), 10));
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<SatelliteSpear>(), 10));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == NPCID.DukeFishron)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<PoseironTrident>(), 5));
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<RoyalFin>(), 1, 7, 10));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == 245)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<GolemGlove>(), 4));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == 262)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ThornyGlove>(), 4));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == NPCID.WallofFlesh)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ThrowerEmblem>(), 7));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == 222)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<Beemerang>(), 4));
				npcLoot.Add(notExpertRule);
			}
			if (npc.type == NPCID.KingSlime)
            {
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ScavengedKunai>(), 5));
				npcLoot.Add(notExpertRule);
            }
			if (npc.type == NPCID.Crab)
            {
				npcLoot.Add(ItemDropRule.Common(ItemType<HermitaurShell>(), 2));
            }
		}
	}
}
using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Ranged.Ammo;
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
                if (npc.HasBuff(BuffID.OnFire))
                {
                    npc.lifeRegen += 8;
                }
                if (npc.HasBuff(BuffID.OnFire3))
                {
					npc.lifeRegen += 10;
                }
				if (npc.HasBuff(BuffID.Frostburn) || npc.HasBuff(BuffID.Frostburn2))
				{
					npc.lifeRegen *= 2;
				}
            }
			if (npc.HasBuff(BuffID.Slimed))
			{
                if (npc.HasBuff(BuffID.OnFire))
                {
                    npc.lifeRegen -= 8;
                }
                if (npc.HasBuff(BuffID.OnFire3))
                {
                    npc.lifeRegen -= 24;
                }
                if (npc.HasBuff(BuffID.CursedInferno))
                {
                    npc.lifeRegen -= 16;
                }
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
			if (compromise && !npc.boss)
			{
                npc.knockBackResist += 0.25f;
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
						shop.Add<HealingArrow>(Condition.PreHardmode, Condition.DownedEowOrBoc, Condition.TimeNight);
                        shop.Add<HealingArrow>(Condition.Hardmode);
                        break;
                    //In earlier versions of Terraria, the Explosive Bunny was sold by the Pirate
                    //In fact, in earlier builds, the Explosive Bunny was given back to the Pirate
                    //However, I have decided to give the Explosive Bunny to the Demolitionist instead
                    //This is mostly to make that shop seem less empty
                    case 38:
                        shop.Add(new Item(ItemID.ExplosiveBunny));
                        shop.Add(new Item(ItemID.Detonator));
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
			if (NPC.downedMoonlord && !npc.boss && npc.lifeMax > 5 && npc.damage > 0 && !npc.friendly && npc.value > 0f && Main.rand.NextBool(Main.expertMode ? 2 : 1, 5))
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
            LeadingConditionRule CrimsonRule = new LeadingConditionRule(new Conditions.IsCrimsonAndNotExpert());
            //Now, a lot of this could theoretically be done through switch instead, but I'll settle with this for now
            if (npc.type == NPCID.Crab)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<HermitaurShell>(), 2));
            }
            if (npc.type == NPCID.Demon || npc.type == NPCID.VoodooDemon)
            {
				if (NPC.downedBoss3)
				{
					npcLoot.Add(ItemDropRule.Common(ItemType<ShadowJavelin>(), 3, 20, 30));
				}
                npcLoot.Add(ItemDropRule.Common(ItemType<DemonClaw>(), 25));
            }
            if (npc.type == NPCID.Harpy && NPC.downedBoss3 || npc.type == NPCID.WyvernBody)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<CumulusCrasher>(), 20));
            }
            if (npc.type == NPCID.CaveBat || npc.type == NPCID.GiantBat)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<BatFlesh>(), 3, 1, 3));
			}
            if (npc.type == NPCID.Vampire || npc.type == NPCID.VampireBat)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<BloodyPike>(), 25));
            }
            if (npc.type >= NPCID.HellArmoredBones && npc.type <= NPCID.HellArmoredBonesSword)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<HellBonesAxe>(), 3, 10, 20));
            }
            if (npc.type >= NPCID.BlueArmoredBones && npc.type <= NPCID.BlueArmoredBonesSword)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<BrokeBonesAxe>(), 3, 10, 20));
            }
            if (npc.type >= NPCID.RustyArmoredBonesAxe && npc.type <= NPCID.RustyArmoredBonesSwordNoArmor)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<RustyBonesAxe>(), 3, 10, 20));
            }
            if (npc.type >= NPCID.ZombieElf && npc.type <= NPCID.PresentMimic || npc.type >= NPCID.ElfCopter && npc.type <= NPCID.Krampus)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<FestiveCloth>(), 3));
            }
            if (npc.type == NPCID.GoblinSummoner)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<ShadowflameSpikeBall>(), 1, 125, 250));
            }
            if (npc.type == NPCID.BigMimicHallow)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<SacredWristband>(), 4));
			}
            if (npc.type == NPCID.MourningWood)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<SpookySpines>(), 10));
            }
            if (npc.type == NPCID.Pumpking)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<UnholyHandGrenade>(), 10));
            }
            if (npc.type == NPCID.SantaNK1)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<FestiveCloth>(), 1, 7, 12));
            }
            if (npc.type == NPCID.IceQueen)
            {
                npcLoot.Add(ItemDropRule.Common(ItemType<SnowflakeShuriken>(), 10));
            }
            if (npc.type == NPCID.MartianSaucer)
			{
				npcLoot.Add(ItemDropRule.Common(ItemType<MartianMiracle>(), 5));
			}
            if (npc.type == NPCID.KingSlime)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ScavengedKunai>(), 5));
                npcLoot.Add(notExpertRule);
            }
			if (npc.type == NPCID.EyeofCthulhu)
			{
				CrimsonRule.OnSuccess(ItemDropRule.Common(ItemType<HealingArrow>(), 1, 20, 50));
				npcLoot.Add(CrimsonRule);
			}
            if (npc.type == NPCID.QueenBee)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<Beemerang>(), 4));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.WallofFlesh)
			{
				notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ThrowerEmblem>(), 7));
				npcLoot.Add(notExpertRule);
			}
            if (npc.type == NPCID.Plantera)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<ThornyGlove>(), 4));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.Golem)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<GolemGlove>(), 4));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.DD2Betsy)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<EtherianChakram>(), 4));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.DukeFishron)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<PoseironTrident>(), 5));
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<RoyalFin>(), 1, 7, 10));
                npcLoot.Add(notExpertRule);
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<CosmosCrasher>(), 10));
                notExpertRule.OnSuccess(ItemDropRule.Common(ItemType<SatelliteSpear>(), 10));
                npcLoot.Add(notExpertRule);
            }
        }
	}
}
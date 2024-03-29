using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Consumables;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Social;

namespace NimblesThrowingStuff.NPCs.Town
{
    [AutoloadHead]
    public class LivingRelic : ModNPC
    {
        public override string Texture
		{
			get
			{
				return "NimblesThrowingStuff/NPCs/Town/LivingRelic";
			}
		}
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Living Relic");
            Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 20;
			NPCID.Sets.AttackAverageChance[NPC.type] = 20;
			NPCID.Sets.HatOffsetY[NPC.type] = -2000000;
            NPC.Happiness
                .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                ;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 24;
			NPC.height = 46;
			NPC.aiStyle = 7;
			NPC.damage = 20;
			NPC.defense = 50;
			NPC.lifeMax = 400;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.25f;
            AnimationType = NPCID.Merchant;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            return NPC.downedBoss1;
        }

        public override void PostAI()
        {
            int xl = (int)((NPC.position.X - 2) / 16f);
            int xr = (int)((NPC.position.X + NPC.width + 2) / 16f);
            int xc = (int)((NPC.Center.X) / 16f);
            int y = (int)((NPC.position.Y + NPC.height + 2) / 16f);
            if (NPC.velocity.X < -4)
            {
                NPC.direction = -1;
            }
            if (NPC.velocity.X > 4)
            {
                NPC.direction = 1;
            }
            if (NPC.velocity.Y == 0)
            {
                if (Main.tile[xr, y].TileType == TileID.ConveyorBeltRight)
                {
                    NPC.direction = -1;
                }
                if (Main.tile[xl, y].TileType == TileID.ConveyorBeltLeft)
                {
                    NPC.direction = 1;
                }
                int type = Main.tile[xc, y].TileType;
                if (NPC.oldVelocity.X < 0 && NPC.velocity.X > 0)
                {
                    NPC.direction = 1;
                }
                if (NPC.oldVelocity.X > 0 && NPC.velocity.X < 0)
                {
                    NPC.direction = -1;
                }
                if (Math.Abs(NPC.oldVelocity.X) > 4 && NPC.velocity.X == 0)
                {
                    NPC.velocity.Y = -6;
                    NPC.velocity.X = NPC.oldVelocity.X;
                }
            }
            else
            {
                if (NPC.velocity.X == 0)
                {
                    NPC.velocity.X = NPC.direction;
                }
                NPC.velocity.X += NPC.direction * 0.095f;
            }
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>() { 
                "Jimmy Bay", 
                "Ollie Raptor", 
                "Andy Wyliei",  
                "Albert Gorgo",
                "Jax Artor",
                "Jean Epanterias",
                "Bolong Shore",
                "Sam Juanasaurus",
                "Shelly Nomanisan"
            };
                
		}
        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            if (projectile.Name.Contains("Bone") || projectile.Name.Contains("Knife"))
            {
                return false;
            }
            return base.CanBeHitByProjectile(projectile);
        }
        public override string GetChat()
        {
            if (Main.eclipse)
            {
                switch (Main.rand.Next(3)) { case 0: return "Staying inside would probably help."; case 1: return "Are those 'Deaf Grapes' guys filming a video?"; case 2: return "Another eclipse? Really?"; }
            }
            if (Main.bloodMoon)
            {
                if (Main.raining && Main.rand.NextBool(4) && NPC.position.Y / 16 <= Main.worldSurface)
                {
                    return "So the moon IS guilty of something...";
                }
                else
                {
                    switch (Main.rand.Next(3)) {
                        case 0: return "Why is everybody so mad? Did you higher primates evolve to get angry at a lunar eclipse?";
                        case 1: return "I think the moon is guilty of something.";
                        case 2: return "I fear what the future might bring..."; }
                }
            }
            else if (Main.LocalPlayer.ZoneSnow)
            {
                if (Main.rand.NextBool(10))
                {
                    return "I mean, it's cool to be cool and all that, but I'm just not the biggest fan of this place.";
                }
            }
            else if (Main.LocalPlayer.ZoneJungle)
            {
                if (Main.rand.NextBool(20))
                {
                    if (!NPC.downedQueenBee)
                    {
                        return "Why are the bees here so big?";
                    }
                    else
                    {
                        return "It's nice out here. My only complaint is that the plants all go away every few days because some guy with a pickaxe goes on a bug-catching spree.";
                    }
                }
            }
            else if (Main.LocalPlayer.ZoneBeach)
            {
                if (Main.rand.NextBool(10))
                {
                    return "What's this shellstone stuff made of, anyway?";
                }
                else if (Main.hardMode && Main.rand.NextBool(8))
                {
                    return "It seems so strange that most of the seas are unexplored. What could be lying down there? Talking sharks?";
                }
            }
            else if (Main.raining && Main.rand.Next(5) == 0 && NPC.position.Y / 16 <= Main.worldSurface)
            {
                return "Were fishes always able to do that?";
            }
            if (Main.rand.NextBool(15))
            {
                if (NPC.homeless)
                {
                    return "I'm an ancient beast. I've lived without a house for many years, but it would still be appreciated.";
                }
                else
                {
                    return "I'm not exactly sure where I'm going to put all these weapons.";
                }
            }
            if (NimblesWorld.downedMorilus)
            {
                return "I heard that you defeated that \"Morilus\" guy. Someone with weird pants told me to sell this artifact to you. I think those two things are related?";
            }
            switch (Main.rand.Next(6))
            {
                case 1:
                    return "I have heard that your kind asks many questions with itself.";
                case 2:
                    return "You humans dress up as other furry creatures, correct? Oh, it's not just mammals?";
                case 3:
                    return "People think my kind is extinct. I guess they haven't looked far enough yet.";
                case 4:
                    return "What's a see 'em cozyman?";
                case 5:
                    return "Sometimes, I wish I had wings.";
                default:
                    return "This armor's really nice. I wonder what it's made out of.";
            }
        }


        public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			if (firstButton)
			{
				shop = RelicShopName;
			}
		}
        public const string RelicShopName = "The Relic's Relics";

		public override void AddShops()
		{
            var RelicsRelics = new NPCShop(NPC.type, RelicShopName);
            RelicsRelics.Add(ModContent.ItemType<DoradoFragment>(), Condition.DownedCultist);
            RelicsRelics.Add(ItemID.DesertFossil, Condition.DownedEowOrBoc);
            RelicsRelics.Add(ItemID.Bone, Condition.DownedSkeletron);
            RelicsRelics.Add(ModContent.ItemType<EmptyFlask>(), Condition.BloodMoonOrHardmode);
            RelicsRelics.Add(ItemID.ThrowingKnife);
            RelicsRelics.Add(ItemID.PoisonedKnife, Condition.DownedQueenBee);
            RelicsRelics.Add(ItemID.BoneDagger, Condition.DownedEowOrBoc);
            RelicsRelics.Add(ModContent.ItemType<SpikeKnife>(), Condition.DownedSkeletron);
            RelicsRelics.Add(ItemID.Shuriken);
            RelicsRelics.Add(ItemID.Javelin);
            RelicsRelics.Add(ItemID.BoneJavelin, Condition.DownedEowOrBoc);
            RelicsRelics.Add<ConvincingArtifact>(new Condition("Mods.NimblesThrowingStuff.Conditions.DownedMorilus", () => NimblesWorld.downedMorilus));
            RelicsRelics.Register();
            /* shop.item[nextSlot].SetDefaults(ItemID.ThrowingKnife);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Shuriken);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Javelin);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("HadalShellstone").Type);
            nextSlot++;
            if (NPC.downedBoss2)
            {
            shop.item[nextSlot].SetDefaults(ItemID.DesertFossil);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.BoneDagger);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.BoneJavelin);
			nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.DefenderMedal);
			nextSlot++;
            }
            if (NPC.downedBoss3)
            {
            shop.item[nextSlot].SetDefaults(ItemID.Bone);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("SpikeKnife").Type);
			nextSlot++;
            }
            if (Main.hardMode)
            {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("EmptyFlask").Type);
			nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("LihzahrdSpikeKnife").Type);
			nextSlot++;
            }
            if (NPC.downedAncientCultist)
            {
            shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("DoradoFragment").Type);
			nextSlot++;
            }
            if (NimblesWorld.downedMorilus)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ConvincingArtifact").Type);
                nextSlot++;
            } */
        }

		public override void OnKill()
		{
            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/LivingRelicHeadGore").Type, 1);
        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 2;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 10;
			randExtraCooldown = 10;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.BoneDagger;
			attackDelay = 5;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 10f;
            gravityCorrection = 10f;
        }
	}
}
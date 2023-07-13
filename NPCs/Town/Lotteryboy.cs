using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Social;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Placeables.Blocks;

namespace NimblesThrowingStuff.NPCs.Town
{
    [AutoloadHead]
    public class Lotteryboy : ModNPC
    {
        public override string Texture
		{
			get
			{
				return "NimblesThrowingStuff/NPCs/Town/Lotteryboy";
			}
		}
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Comploy");
            Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 10000;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 60;
			NPCID.Sets.AttackAverageChance[NPC.type] = 20;
			NPCID.Sets.HatOffsetY[NPC.type] = 0;
            NPC.Happiness
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Like)
                ;
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 24;
			NPC.height = 46;
			NPC.aiStyle = 7;
			NPC.damage = 50;
			NPC.defense = 250;
			NPC.lifeMax = 2500;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.25f;
            AnimationType = NPCID.Merchant;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            return NPC.downedMoonlord;
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
                "Lotteryboy", 
                "QuestBot 3000", 
                "xX_GILLAX3_Xx was here",  
                "Rowan Bog",
                "Hugh Mann",
                "Nottany Mor"
            };
                
		}
        public override string GetChat()
        {
            if (Main.LocalPlayer.ZoneSnow)
            {
                if (Main.rand.NextBool(10))
                {
                    return "A bit of natural cooling never hurt.";
                }
            }
            if (Main.LocalPlayer.ZoneDesert)
            {
                if (Main.rand.NextBool(6))
                {
                    return "Have you heard of liquid nitrogen cooling? I think it would grant me some relief from this heat.";
                }
            }
            if (Main.LocalPlayer.ZoneJungle)
            {
                if (Main.rand.NextBool(10))
                {
                    if (NPC.downedQueenBee)
                    {
                        return "That furry was right. Why are the bees here so big?";
                    }
                }
            }
            if (Main.LocalPlayer.ZoneBeach)
            {
                if (Main.rand.NextBool(10))
                {
                    return "I am waterproof. I'd show you proof, but it's all wet.";
                }
                else if (Main.hardMode && Main.rand.NextBool(8))
                {
                    return "Transcendental inversion! Transcendental inversion! \nSorry, I've just been picking up odd frequencies lately.";
                }
            }
            if (Main.raining && Main.rand.Next(5) == 0)
            {
                return "You're telling me a shrimp fried this rice?";
            }
            if (Main.rand.NextBool(20))
            {
                if (NPC.homeless)
                {
                    return "This is not valid housing.";
                }
                else
                {
                    return "A good name for this town would be \"Biodiversington.\" It emphasizes the biodiversity of the surrounding area.";
                }
            }
            if (NimblesWorld.downedMorilus && Main.rand.NextBool(10))
            {
                if (Main.rand.NextBool(5))
                {
                    return "All the people in the big city are profoundly disturbed.";
                }
                else
                {
                    return "All the people in the big city call me \"Weirdpants\".";
                }
            }
            //if (BirthdayParty.PartyIsUp && Main.rand.Next(4))
            //{
            //    return "I'm not really sure how to celebrate this kind of thing...";
            //}
            switch (Main.rand.Next(7))
            {
                case 1:
                    return "That Viro hero is quite popular on other planets.";
                case 2:
                    return "My lottery functions aren't working so great today. Just your luck.";
                case 3:
                    return "What're ya buying?";
                case 4:
                    return "I remember when two men dug up only a man. The news spread through our system like plasmastorms on the crust of Glyrrinum";
                case 5:
                    return "This planet seems to be filled with places built for wheels and not legs. I feel that this is inconvenient for you.";
                case 6:
                    return "I was designed to give adventures to people. Unfortunately, I don't believe I'm capable of giving you a good quest.";
                default:
                    return "Generic dialogue.";
            }
        }


        public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}
        public const string ShopName = "Wares";
		public override void OnChatButtonClicked(bool firstButton, ref string shop)
		{
			if (firstButton)
			{
				shop = ShopName;
			}
		}

		public override void AddShops()
		{
            var LotteryWares = new NPCShop(NPC.type, ShopName);
            LotteryWares.Add(ItemID.LunarOre);
            LotteryWares.Add(ItemID.FragmentSolar);
            LotteryWares.Add(ItemID.FragmentVortex);
            LotteryWares.Add(ItemID.FragmentNebula);
            LotteryWares.Add(ItemID.FragmentStardust);
            LotteryWares.Add<ProcellariteOre>(new Condition("Mods.NimblesThrowingStuff.Conditions.DownedMorilus", () => NimblesWorld.downedMorilus));
            LotteryWares.Register();
            /* shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FragmentSolar);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FragmentVortex);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FragmentNebula);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.FragmentStardust);
            nextSlot++;
            if (NimblesWorld.downedMorilus)
            {
                shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ProcellariteOre").Type);
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
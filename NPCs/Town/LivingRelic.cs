using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

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

		public override bool Autoload(ref string name)
		{
			name = "Living Relic";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Relic");
            Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 5;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 20;
			NPCID.Sets.AttackAverageChance[npc.type] = 20;
			NPCID.Sets.HatOffsetY[npc.type] = -2;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 24;
			npc.height = 46;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 50;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 1f;
            animationType = NPCID.Merchant;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return NPC.downedBoss1;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (target.type == NPCID.ChatteringTeethBomb)
            {
                return false;
            }
            return base.CanHitNPC(target);
        }
        public override void PostAI()
        {
            int xl = (int)((npc.position.X - 2) / 16f);
            int xr = (int)((npc.position.X + npc.width + 2) / 16f);
            int xc = (int)((npc.Center.X) / 16f);
            int y = (int)((npc.position.Y + npc.height + 2) / 16f);
            if (npc.velocity.X < -4)
            {
                npc.direction = -1;
            }
            if (npc.velocity.X > 4)
            {
                npc.direction = 1;
            }
            if (npc.velocity.Y == 0)
            {
                if (Main.tile[xr, y].type == TileID.ConveyorBeltRight)
                {
                    npc.direction = -1;
                }
                if (Main.tile[xl, y].type == TileID.ConveyorBeltLeft)
                {
                    npc.direction = 1;
                }
                int type = Main.tile[xc, y].type;
                if (npc.oldVelocity.X < 0 && npc.velocity.X > 0)
                {
                    npc.direction = 1;
                }
                if (npc.oldVelocity.X > 0 && npc.velocity.X < 0)
                {
                    npc.direction = -1;
                }
                if (Math.Abs(npc.oldVelocity.X) > 4 && npc.velocity.X == 0)
                {
                    npc.velocity.Y = -6;
                    npc.velocity.X = npc.oldVelocity.X;
                }
            }
            else
            {
                if (npc.velocity.X == 0)
                {
                    npc.velocity.X = npc.direction;
                }
                npc.velocity.X += npc.direction * 0.095f;
            }
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
		{
			int score = 900;
            
			return score > 800;
		}

		public override string TownNPCName()
        {
            string relic = "Toby Rex";
            switch (WorldGen.genRand.Next(3))
            {
                case 1:
                    relic = "Vincent Raptor";
                    break;
                case 2:
                    relic = "Spiny Sam";
                    break;
            }
            switch (WorldGen.genRand.Next(5))
			{
				case 1:
					return "Tyler Horridus";
				case 2:
					return "Charlie Tops";
				case 3:
					return "Oliver Raptor";
                default:
					return relic;
			}
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
                switch (Main.rand.Next(3))
                {
                    case 1:
                        return "Staying inside would probably help.";
                    case 2:
                        return "Are those 'Deaf Grapes' guys filming a video?";
                    default:
                        return "Another eclipse?";
                }
            }
            if (Main.bloodMoon)
            {
                if (Main.raining && Main.rand.Next(4) == 0 && npc.position.Y/16 <= Main.worldSurface)
                {
                    return "So the moon is guilty of something...";
                }
                switch (Main.rand.Next(3))
                {
                    case 1:
                        return "Why is everybody so mad? Did you higher primates evolve to get angry at a lunar eclipse?";
                    case 2:
                        return "I think the moon is guilty of something.";
                    default:
                        return "I fear what the future might bring...";
                }
            }
            else if (Main.LocalPlayer.ZoneSnow)
            {
                if (Main.rand.Next(5) == 0)
                {
                    return "As a cold-blooded beast, I hate this.";
                }
            }
            else if (Main.raining && Main.rand.Next(5) == 0 && npc.position.Y / 16 <= Main.worldSurface)
            {
                return "Were fishes always able to do that?";
            }
            if (Main.rand.Next(6) == 0)
            {
                if (npc.homeless)
                {
                    return "I'm an ancient beast. I've lived without a house for many years, but it would still be appreciated.";
                }
                else
                {
                    return "Thanks for the house.";
                }
            }
            switch (Main.rand.Next(5))
            {
                case 1:
                    return "Are you sure that what you're doing is right?";
                case 2:
                    return "I've heard that my weapons came back to the ranged class. Is this true?";
                case 3:
                    return "People think my kind is extinct. I guess they haven't looked far enough yet.";
                case 4:
                    return "If you're seeing me, then you've gone past the point of no return.";
                default:
                    return "I saw someone defeat the Moon Lord with my comparatively weak weapons. Anything is possible, apparently...";
            }
        }


        public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
            shop.item[nextSlot].SetDefaults(ItemID.ThrowingKnife);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Shuriken);
			nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Javelin);
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
            shop.item[nextSlot].SetDefaults(mod.ItemType("SpikeKnife"));
			nextSlot++;
            }
            if (Main.hardMode)
            {
            shop.item[nextSlot].SetDefaults(mod.ItemType("EmptyFlask"));
			nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
            shop.item[nextSlot].SetDefaults(mod.ItemType("LihzahrdSpikeKnife"));
			nextSlot++;
            }
            if (NPC.downedAncientCultist)
            {
            shop.item[nextSlot].SetDefaults(mod.ItemType("DoradoFragment"));
			nextSlot++;
            }
        }

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.FossilHelm, 1);
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
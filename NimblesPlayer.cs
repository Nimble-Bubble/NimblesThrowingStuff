using System.Linq;  
using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Dusts;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Consumables;
using Terraria.Utilities;
using Terraria.GameInput;

namespace NimblesThrowingStuff
{
    public class NimblesPlayer : ModPlayer
    {
        public bool canSanta;
        public float rangedSpeed = 1f;
        public float magicSpeed = 1f;
        public float thrownSpeed = 1f;
        public float universalSpeed = 1f;
        public bool sacredWrist;
        public bool thrownHeal;
        public bool greek;
        public bool chloroThrow;
        public bool miniPoison;
        public bool miniFire;
        public bool miniFrost;
        public bool miniVenom;
        public bool miniEvil;
        public bool miniMove;
        public bool miniGreek;
        public bool miniLocal;
        public bool rathalosOnFire;
        public bool rangeMisfire;
        public int whichShield;
        public int whichGuardSound;
        public bool guardState;
        public int guardBonus;
        public bool compromise;
        public bool drownDebuff;
        public int currentShells;
        public int bonusShells;
        
        public override void ResetEffects()
        {
        rangedSpeed = 1f;
        magicSpeed = 1f;
        thrownSpeed = 1f;
        universalSpeed = 1f;
        sacredWrist = false;
        thrownHeal = false;
        chloroThrow = false;
        greek = false;
        canSanta = false;
        miniPoison = false;
        miniFire = false;
        miniVenom = false;
        miniEvil = false;
        miniFrost = false;
        miniMove = false;
        miniGreek = false;
        miniLocal = false;
        rathalosOnFire = false;
        whichShield = 0;
        whichGuardSound = 0;
        rangeMisfire = false;
        guardState = false;
        guardBonus = 0;
        drownDebuff = false;
            //currentShells = 0;
            bonusShells = 0;
        }
        public override void UpdateDead()
        {
            greek = false;
            guardState = false;
            compromise = false;
            drownDebuff = false;
            currentShells = 0;
    }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (NimblesThrowingStuff.MIGuardKey.Current)
            {
                /* if (whichShield >= 1)
                {
                    Dust.NewDust(Player.position, Player.width, Player.height, 43, Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, 1);
                } */
                switch (whichShield)
                {
                    case 1:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                    break;
                    case 2:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardHorrorshow").Type, 2);
                        break;
                    case 3:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardCarpatus").Type, 2);
                        break;
                    case 4:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardStinguard").Type, 2);
                        break;
                    case 5:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardWyvernshell").Type, 2);
                        break;
                    case 6:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardSightbringer").Type, 2);
                        break;
                    case 7:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardWhirlpool").Type, 2);
                        break;
                    case 8:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 9:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 10:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 11:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 12:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 13:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                    case 14:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIron").Type, 2);
                        break;
                }
            }
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (Player.ZoneBeach && NPC.downedBoss2 && attempt.uncommon && Main.rand.NextBool(3))
            {
                itemDrop = Mod.Find<ModItem>("LagiacrusShell").Type;
                return;
            }
            if (Player.ZoneCorrupt || Player.ZoneCrimson)
            {
                if (attempt.common && Main.rand.NextBool(4))
                {
                    itemDrop = Mod.Find<ModItem>("BeastBone").Type;
                    return;
                }
                if (attempt.uncommon && Main.rand.NextBool(3) && NPC.downedMoonlord)
                {
                    itemDrop = Mod.Find<ModItem>("GrandBone").Type;
                    return;
                }
                // return;
            }
        }
        public override void OnHurt(Player.HurtInfo info)
        {
            if (NimblesThrowingStuff.MIGuardKey.Current && whichShield >= 1)
            {
                if (info.Damage <= Player.statDefense)
                {
                    info.SoundDisabled = true;
                }
                switch (whichGuardSound)
                {
                    case 0:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMetalMedium"));
                        break;
                    case 1:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMetalMedium"));
                        break;
                    case 2:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMetalLight"));
                        break;
                    case 3:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMetalHeavy"));
                        break;
                    case 4:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMagicMetalMedium"));
                        break;
                    case 5:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMagicMetalLight"));
                        break;
                    case 6:
                        SoundEngine.PlaySound(new SoundStyle("NimblesThrowingStuff/Sounds/Item/GuardMagicMetalHeavy"));
                        break;
                }
                
            }
        }
        public override void PostHurt(Player.HurtInfo info) 
        {
            if (compromise)
            {
                Player.velocity *= new Vector2(2, 2);
            }
            if (canSanta)
                {
                    int spikeball1 = Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center.X, Player.Center.Y, 0, -10, Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45));
                        Main.projectile[spikeball1].velocity.RotatedBy(MathHelper.ToRadians(330f));
                    int spikeball2 = Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center.X, Player.Center.Y, 0, -10, Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
                    int spikeball3 = Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center.X, Player.Center.Y, 0, -10, Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45));
                        Main.projectile[spikeball3].velocity.RotatedBy(MathHelper.ToRadians(30f));
                }
        }
        public override float UseTimeMultiplier(Item item)
        {
            float speed = base.UseTimeMultiplier(item);

            if (item.CountsAsClass(DamageClass.Throwing))
            {
                speed *= thrownSpeed;
            }
            if (item.CountsAsClass(DamageClass.Ranged))
            {
                speed *= rangedSpeed;
            }
            if (item.CountsAsClass(DamageClass.Magic) || item.CountsAsClass(DamageClass.Summon))
            {
                speed *= magicSpeed;
            }
            if (item.damage >= 1)
            {
                speed *= universalSpeed;
            }

            return speed;
        }
        public override float UseSpeedMultiplier(Item item)
        {
            float speed = base.UseSpeedMultiplier(item);

            if (item.CountsAsClass(DamageClass.Throwing))
            {
                speed *= thrownSpeed;
            }
            if (item.CountsAsClass(DamageClass.Ranged))
            {
                speed *= rangedSpeed;
            }
            if (item.CountsAsClass(DamageClass.Magic) || item.CountsAsClass(DamageClass.Summon))
            {
                speed *= magicSpeed;
            }
            if (item.damage >= 1)
            {
                speed *= universalSpeed;
            }
            return speed;
        }
        public override void UpdateBadLifeRegen()
		{
    if (guardState)
    {
          switch (whichShield)
                {
                    case 1:
                        Player.statDefense += 5 + guardBonus;
                        Player.moveSpeed /= 2;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 43, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color (255, 255, 255));
                        }
                        break;
                    case 2:
                        Player.immune = true;
                        Player.invis = true;
                        Player.statDefense += guardBonus;
                        Player.GetDamage(DamageClass.Generic) /= 4;
                        universalSpeed /= 4;
                        if (Main.rand.NextBool(6))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 43, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color(255, 255, 255));
                        }
                        break;
                    case 3:
                        Player.statDefense += 50 + (guardBonus * 2);
                        if (Main.rand.NextBool(6))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, ModContent.DustType<ProcellariteStarDust>(), Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), ModContent.DustType<ProcellariteStarDust>(), default(Color));
                        }
                        break;
                    case 4:
                        Player.statDefense += guardBonus;
                        Player.thorns = 1f;
                        Lighting.AddLight(Player.Center, Color.Lime.ToVector3() * 0.5f);
                        if (Main.rand.NextBool(6))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 44, Player.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).X * 0.5f, Player.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).Y * 0.5f, 0, default(Color), 0.5f);
                        }
                        break;
                    case 5:
                        Player.statDefense += 4 + (guardBonus * 2);
                        Player.buffImmune[BuffID.OnFire] = true;
                        Lighting.AddLight(Player.Center, Color.Red.ToVector3() * 0.5f);
                        if (Main.rand.NextBool(6))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 6, Player.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).X * 0.5f, Player.velocity.RotatedByRandom(MathHelper.ToDegrees(120)).Y * 0.5f, 0, default(Color), 0.5f);
                        }
                        break;
                    case 6:
                        Player.statDefense += guardBonus;
                        Lighting.AddLight(Player.Center, Color.White.ToVector3() * 0.8f);
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 43, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color(255, 255, 255));
                        }
                        break;
                    case 7:
                        Player.statDefense += 4 + guardBonus;
                        Player.buffImmune[BuffID.Electrified] = true;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Electric, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color(255, 255, 255));
                        }
                        break;
                    case 8:
                        Player.statDefense += 5 + (guardBonus * 2);
                        break;
                    case 9:
                        Player.statDefense += 4 + (guardBonus);
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Cobalt, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 10:
                        Player.statDefense += 8 + (guardBonus * 2);
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Obsidian, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        if (Main.rand.NextBool(10))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Smoke, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 11:
                        Player.statDefense += 16 + (guardBonus * 4);
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.RainbowTorch, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 12:
                        Player.statDefense += 10 + (guardBonus * 2);
                        Player.endurance += 0.15f;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Gold, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 13:
                        Player.statDefense += 10 + (guardBonus * 3);
                        Player.endurance += 0.2f;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Blood, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 14:
                        Player.statDefense += 10 + (guardBonus * 2);
                        Player.endurance += 0.25f;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.Ice, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, default(Color));
                        }
                        break;
                    case 15:
                        Player.statDefense += 10 + (guardBonus * 2);
                        Player.moveSpeed /= 2;
                        if (Main.rand.NextBool(3))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 43, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color(255, 255, 255));
                        }
                        break;
                }
    }
    if (greek)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (Player.lifeRegen > 0)
				{
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 25 life lost per second. Ouch.
				Player.lifeRegen -= 50;
			}
    if (compromise)
            {
                Player.noKnockback = false;
                guardBonus -= 10;
            }
    if (drownDebuff)
            {
                if (Player.lifeRegen > 0)
                {
                    Player.lifeRegen = 0;
                }
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 14;
            }
    if (Player.HasBuff(BuffID.BeetleEndurance1))
            {
                guardBonus += 15;
            }
            if (Player.HasBuff(BuffID.BeetleEndurance2))
            {
                guardBonus += 30;
            }
            if (Player.HasBuff(BuffID.BeetleEndurance3))
            {
                guardBonus += 45;
            }
        }
    }
}
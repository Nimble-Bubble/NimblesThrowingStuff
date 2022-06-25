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
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Buffs;
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
        public bool rangeMisfire;
        public int whichShield;
        public bool guardState;
        public int guardBonus;
        public bool compromise;
        
        public override void ResetEffects()
        {
        rangedSpeed = 1f;
        magicSpeed = 1f;
        thrownSpeed = 1f;
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
        whichShield = 0;
        rangeMisfire = false;
        guardState = false;
        guardBonus = 0;
        }
        public override void UpdateDead()
        {
            greek = false;
            guardState = false;
            compromise = false;
    }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (NimblesThrowingStuff.MIGuardKey.Current)
            {
                if (whichShield >= 1)
                {
                    Dust.NewDust(Player.position, Player.width, Player.height, 43, Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, 1);
                }
                switch (whichShield)
                {
                    case 1:
                        Player.AddBuff(Mod.Find<ModBuff>("GuardIronShield").Type, 2);
                    break;
                }
            }
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (NimblesThrowingStuff.MIGuardKey.Current && whichShield >= 1)
            {
                //if (damage <= player.statDefense)
                //{
                //    damage = 0;
                //}
                quiet = true;
                SoundEngine.PlaySound(new SoundStyle("Sounds/Item/GuardMetalMedium"));
            }
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
            
                if (canSanta)
         {
          Projectile.NewProjectile(Player.Center.X, Player.Center.Y, 0, -10,
                            Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
             Projectile.NewProjectile(Player.Center.X, Player.Center.Y, -5, -10,
                            Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
             Projectile.NewProjectile(Player.Center.X, Player.Center.Y, 5, -10,
                            Mod.Find<ModProjectile>("SantankSpikeProj").Type, 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
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

            return speed;
        }
        public override void UpdateBadLifeRegen()
		{
    if (guardState)
    {
          switch (whichShield)
                {
                    case 1:
                        Player.statDefense += 10;
                        Player.statDefense += guardBonus;
                        Player.moveSpeed -= 0.5f;
                        if (Main.rand.NextBool(6))
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, 43, Player.velocity.X + Main.rand.Next(-3, 4), Player.velocity.Y + Main.rand.Next(-3, 4), 0, new Color (255, 255, 255));
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
        }
    }
}
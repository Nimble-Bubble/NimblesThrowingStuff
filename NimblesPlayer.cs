using System.Linq;  
using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
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
        public bool guardIronShield;
        public int guardBonus;
        
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
        guardIronShield = false;
        guardBonus = 0;
        }
        public override void UpdateDead()
        {
            greek = false;
            guardIronShield = false;
    }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (NimblesThrowingStuff.MIGuardKey.Current)
            {
                if (whichShield >= 1)
                {
                    Dust.NewDust(player.position, player.width, player.height, 43, Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, 1);
                }
                switch (whichShield)
                {
                    case 1:
                        player.AddBuff(mod.BuffType("GuardIronShield"), 2);
                    break;
                }
            }
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit) {
         if (canSanta)
         {
          Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -10,
                            mod.ProjectileType("SantankSpikeProj"), 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
             Projectile.NewProjectile(player.Center.X, player.Center.Y, -5, -10,
                            mod.ProjectileType("SantankSpikeProj"), 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
             Projectile.NewProjectile(player.Center.X, player.Center.Y, 5, -10,
                            mod.ProjectileType("SantankSpikeProj"), 100, 5f, Main.myPlayer, 0.0f, (float) Main.rand.Next(0, 45)); 
         }
        }
        
        public override float UseTimeMultiplier(Item item)
        {
            float speed = base.UseTimeMultiplier(item);

            if (item.thrown)
            {
                speed *= thrownSpeed;
            }
            if (item.ranged)
            {
                speed *= rangedSpeed;
            }
            if (item.magic || item.summon)
            {
                speed *= magicSpeed;
            }

            return speed;
        }
        public override float MeleeSpeedMultiplier(Item item)
        {
            float speed = base.MeleeSpeedMultiplier(item);

            if (item.thrown)
            {
                speed *= thrownSpeed;
            }
            if (item.ranged)
            {
                speed *= rangedSpeed;
            }
            if (item.magic || item.summon)
            {
                speed *= magicSpeed;
            }

            return speed;
        }
        public override void UpdateBadLifeRegen()
		{
    if (guardIronShield)
    {
        player.statDefense += 10;
        player.statDefense += guardBonus;
        player.moveSpeed -= 0.5f;
    }
    if (greek)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 25 life lost per second. Ouch.
				player.lifeRegen -= 50;
			}
        }
    }
}
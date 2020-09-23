using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class ParazoniumProj: ModProjectile
    {
        private float targetrange = 0f;
        private float targetspeed = 1f;
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 28;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 5;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 2;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            targetrange += 5f;
        targetspeed += 0.025f;
            for(int i = 0; i < 200; i++)
        {
        NPC target = Main.npc[i];
       if(!target.friendly)
       {
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

           if(distance < targetrange && !target.friendly && target.active)
           {
               distance = 10f / distance;
   
               shootToX *= distance * 1;
               shootToY *= distance * 1;

               projectile.velocity.X = shootToX * targetspeed;
               projectile.velocity.Y = shootToY * targetspeed;
           }
       }
        }
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.damage > 20)
            {
         projectile.damage -= 20;
            }
        }
    }
}
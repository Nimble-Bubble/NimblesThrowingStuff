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
	public class PoseironBubble: ModProjectile
    {
        private float targetrange = 0f;
        private float targetspeed = 1f;
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.timeLeft = 60;
        }
        public override void AI()
        {
        targetrange += 15f;
        targetspeed += 0.05f;
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
            if (projectile.timeLeft <= 10)
            {
             projectile.alpha += 30;   
            }
        }
    }
}
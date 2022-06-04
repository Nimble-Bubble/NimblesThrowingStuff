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
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 60;
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
           float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
           float shootToY = target.position.Y - Projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

           if(distance < targetrange && !target.friendly && target.active)
           {
               distance = 10f / distance;
   
               shootToX *= distance * 1;
               shootToY *= distance * 1;

               Projectile.velocity.X = shootToX * targetspeed;
               Projectile.velocity.Y = shootToY * targetspeed;
           }
       }
        }
            if (Projectile.timeLeft <= 10)
            {
             Projectile.alpha += 30;   
            }
        }
    }
}
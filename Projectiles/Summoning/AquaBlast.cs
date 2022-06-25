using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class AquaBlast: ModProjectile
    {
    
        private float targetrange = 500f;
        private float targetspeed = 1f;
        public override void SetStaticDefaults() 
        {
        ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.aiStyle = 8;
            Projectile.timeLeft = 150;
            AIType = 27;
        }
        public override void AI()
        {
        targetrange += 5f;
        targetspeed += 0.025f;
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
        }
        public override void Kill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
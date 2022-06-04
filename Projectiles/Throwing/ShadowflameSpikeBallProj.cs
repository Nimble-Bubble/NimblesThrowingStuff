using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class ShadowflameSpikeBallProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 14;
            Projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 272);
			}
            
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.ShadowFlame, 150);
        }
    }
}
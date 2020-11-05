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
            projectile.width = 14;
            projectile.height = 14;
            projectile.tileCollide = true;
            projectile.maxPenetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 600;
            projectile.thrown = true;
            projectile.aiStyle = 14;
            projectile.penetrate = -1;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 272);
			}
            
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.ShadowFlame, 150);
        }
    }
}
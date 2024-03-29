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
	public class MeteorSpearExplosion: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Meteorsplosion");
        }
        public override void SetDefaults()
        {
            Projectile.width = 250;
            Projectile.height = 250;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.light = 0.5f;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(24, 300);
        }
    }
}
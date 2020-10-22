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
	public class NanoMissileExplosion: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 250;
            projectile.height = 250;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 1;
            projectile.thrown = true;
            projectile.light = 0.5f;
            projectile.aiStyle = 1;
            projectile.alpha = 255;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(44, 300);
            target.AddBuff(31, 750);
        }
    }
}
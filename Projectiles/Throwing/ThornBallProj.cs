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
	public class ThornBallProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Thorn Ball");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = 6;
            Projectile.friendly = true;
            Projectile.timeLeft = 3600;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 14;
            Projectile.penetrate = 6;
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Poisoned, 300);
        }
    }
}
using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class GlidingBlazeProj : ModProjectile
    {
        private float GlidingBlazeMultiplier;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gliding Blaze");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 29;
            Projectile.friendly = true;
            Projectile.maxPenetrate = 1;
            Projectile.light = 1f;
            Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Magic;
        }
        public override void AI()
        {
            ++GlidingBlazeMultiplier;
            Projectile.velocity *= new Vector2((GlidingBlazeMultiplier + 85) / 100, (GlidingBlazeMultiplier + 85) / 100);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 300);
            if (GlidingBlazeMultiplier > 15)
            {
                damage += (int)(GlidingBlazeMultiplier + 85) / 5;
            }
        }
    }
}

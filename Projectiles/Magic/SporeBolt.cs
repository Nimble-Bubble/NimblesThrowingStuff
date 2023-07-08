using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class SporeBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = 29;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.penetrate = 200;
            Projectile.maxPenetrate = 200;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.alpha = 0;
            Projectile.scale = 0.5f;
            Projectile.timeLeft = 255;
        }
        public override void AI()
        {
            Projectile.rotation += 0.05f * (float)Projectile.direction;
            Projectile.alpha++;
            Projectile.scale += 0.02f;
            Projectile.velocity.X *= 0.98f;
            Projectile.velocity.Y *= 0.98f;

        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.Poisoned, 300);
        }
    }
}

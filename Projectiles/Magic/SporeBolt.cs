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
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 29;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 200;
            projectile.maxPenetrate = 200;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.alpha = 0;
            projectile.scale = 0.5f;
            projectile.timeLeft = 255;
        }
        public override void AI()
        {
            projectile.rotation += 0.05f * (float)projectile.direction;
            projectile.alpha++;
            projectile.scale += 0.02f;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 150);
        }
    }
}

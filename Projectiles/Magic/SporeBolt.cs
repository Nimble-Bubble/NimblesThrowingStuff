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
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 29;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 3;
            projectile.maxPenetrate = 3;
            projectile.light = 0.5f;
            projectile.alpha = 128;
        }
        public override void AI()
        {
            projectile.rotation += 0.5f * (float)projectile.direction;
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, Main.rand.Next(2, 3), Main.rand.Next(2, 3), 0, default(Color), 0.75f);
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 150);
        }
    }
}

using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oceanus Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 0;
            projectile.hostile = true;
            projectile.magic = false;
            projectile.maxPenetrate = 10;
            projectile.light = 1f;
            projectile.alpha = 255;
            projectile.timeLeft = 200;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.995f;
            projectile.velocity.Y += 0.2f;
            if (projectile.velocity.Y > 10)
            {
                projectile.velocity.Y = 10;
            }
            projectile.rotation += 10;
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ProcellariteWaterDust>(), Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}

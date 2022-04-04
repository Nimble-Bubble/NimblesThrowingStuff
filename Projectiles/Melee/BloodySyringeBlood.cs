using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Melee
{
    public class BloodySyringeBlood : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stream of Blood");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = 0;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.light = 0.5f;
            projectile.alpha = 255;
            projectile.timeLeft = 150;
            projectile.extraUpdates = 0;
        }
        public override void AI()
        {
            projectile.velocity.X *= 0.9925f;
            projectile.velocity.Y += 0.75f;
            if (projectile.velocity.Y > 10)
            {
                projectile.velocity.Y = 10;
            }
            projectile.rotation += 10;
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 5, Main.rand.Next(-1, 2), Main.rand.Next(-1, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}

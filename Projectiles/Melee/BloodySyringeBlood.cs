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
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.penetrate = 5;
            Projectile.light = 0.5f;
            Projectile.alpha = 255;
            Projectile.timeLeft = 150;
            Projectile.extraUpdates = 0;
        }
        public override void AI()
        {
            Projectile.velocity.X *= 0.9925f;
            Projectile.velocity.Y += 0.75f;
            if (Projectile.velocity.Y > 10)
            {
                Projectile.velocity.Y = 10;
            }
            Projectile.rotation += 10;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 5, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 5, Main.rand.Next(-1, 2), Main.rand.Next(-1, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}

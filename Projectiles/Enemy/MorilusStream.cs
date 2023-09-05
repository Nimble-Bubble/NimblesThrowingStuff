using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusStream : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Oceanus Stream");
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.hostile = true;
            Projectile.maxPenetrate = 10;
            Projectile.light = 1f;
            Projectile.alpha = 255;
            Projectile.timeLeft = 300;
            //Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Projectile.velocity.X *= 1.015f;
            Projectile.velocity.Y *= 1.015f;
            if (Projectile.velocity.Y > 10)
            {
                Projectile.velocity.Y = 10;
            }
            Projectile.rotation += 10;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteWaterDust>(), Projectile.velocity.X * 0.05f, Projectile.velocity.Y * 0.05f, 0, default, Main.rand.NextFloat(1f, 3f));
        }
    }
}

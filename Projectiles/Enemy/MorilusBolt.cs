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
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.hostile = true;
            Projectile.magic = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Projectile.maxPenetrate = 10;
            Projectile.light = 1f;
            Projectile.alpha = 255;
            Projectile.timeLeft = 200;
            Projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            Projectile.velocity.X *= 0.995f;
            Projectile.velocity.Y += 0.2f;
            if (Projectile.velocity.Y > 10)
            {
                Projectile.velocity.Y = 10;
            }
            Projectile.rotation += 10;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteWaterDust>(), Main.rand.Next(-3, 2), Main.rand.Next(-3, 2), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}

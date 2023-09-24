using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class MagicVerticalWall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Morilus Barrier");
        }

        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 10;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.penetrate = 9999;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.light = 1f;
            Projectile.alpha = 0;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Projectile.velocity.X *= 1.025f;
            Projectile.velocity.Y *= 1.025f;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
        public override void OnKill(int timeLeft)
        {
            for (int io = 0; io < 10; io++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}


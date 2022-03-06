using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusHorizontalWall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morilus Barrier");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 250;
            projectile.aiStyle = 0;
            projectile.hostile = true;
            projectile.magic = false;
            projectile.maxPenetrate = 1;
            projectile.tileCollide = false;
            projectile.light = 1f;
            projectile.alpha = 0;
            projectile.timeLeft = 600;
        }
        public override void AI()
        {
            projectile.velocity.X *= 1.025f;
            projectile.velocity.Y *= 1.025f;
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
        public override void Kill(int timeLeft)
        {
            for (int io = 0; io < 10; io++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}


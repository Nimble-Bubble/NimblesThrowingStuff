using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorileShot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morile Shot");
        }

        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = 1;
            projectile.hostile = true;
            projectile.magic = false;
            projectile.maxPenetrate = 1;
            projectile.tileCollide = false;
            projectile.light = 1f;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
        public override void Kill(int timeLeft)
        {
            for (int io = 0; io < 10; io++)
                Dust.NewDust(projectile.position, projectile.width, projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}


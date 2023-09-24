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
            // DisplayName.SetDefault("Morile Shot");
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 1;
            Projectile.hostile = true;
            Projectile.maxPenetrate = 1;
            Projectile.tileCollide = false;
            Projectile.light = 1f;
            Projectile.timeLeft = 300;
        }
        public override void AI()
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
        public override void OnKill(int timeLeft)
        {
            for (int io = 0; io < 10; io++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Main.rand.Next(-2, 1), Main.rand.Next(-2, 1), 0, default, Main.rand.NextFloat(0.5f, 1.5f));
        }
    }
}


using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorilusBigStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Bomb");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 150;
            projectile.light = 0f;
            projectile.alpha = 255;
        }
        public override void AI()
        {
            projectile.scale += 0.01f;
            projectile.light += 0.01f;
            projectile.alpha -= 5;
            projectile.rotation += 0.1f;
            projectile.velocity.X *= 0.95f;
            projectile.velocity.Y *= 0.95f;
        }
        public override void Kill(int timeLeft)
        {
            for (int starSpawn = 0; starSpawn < 8; starSpawn++)
            {
                int bigMakeLittle = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, 11), ProjectileID.FallingStar, projectile.damage, projectile.knockBack, projectile.owner);
                Main.projectile[bigMakeLittle].friendly = false;
                Main.projectile[bigMakeLittle].hostile = true;
                Main.projectile[bigMakeLittle].timeLeft = 600;
                Main.projectile[bigMakeLittle].tileCollide = false;
            }
        }
    }
}

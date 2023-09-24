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
            // DisplayName.SetDefault("Star Bomb");
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 150;
            Projectile.light = 0f;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.scale += 0.01f;
            Projectile.light += 0.01f;
            Projectile.alpha -= 5;
            Projectile.rotation += 0.1f;
            Projectile.velocity.X *= 0.95f;
            Projectile.velocity.Y *= 0.95f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int starSpawn = 0; starSpawn < 8; starSpawn++)
            {
                int bigMakeLittle = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, 11), ProjectileID.FallingStar, Projectile.damage, Projectile.knockBack, Projectile.owner);
                Main.projectile[bigMakeLittle].friendly = false;
                Main.projectile[bigMakeLittle].hostile = true;
                Main.projectile[bigMakeLittle].timeLeft = 600;
                Main.projectile[bigMakeLittle].tileCollide = false;
            }
        }
    }
}

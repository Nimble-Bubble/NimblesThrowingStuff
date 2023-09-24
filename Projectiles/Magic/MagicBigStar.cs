using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class MagicBigStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Star Bomb");
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
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
            Projectile.velocity.X *= 0.975f;
            Projectile.velocity.Y *= 0.975f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int starSpawn = 0; starSpawn < 8; starSpawn++)
            {
                int bigMakeLittle = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, Main.rand.Next(-10, 11), Main.rand.Next(-10, 11), ProjectileID.FallingStar, Projectile.damage / 4, Projectile.knockBack, Projectile.owner);
                Main.projectile[bigMakeLittle].friendly = true;
                Main.projectile[bigMakeLittle].DamageType = DamageClass.Magic;
                Main.projectile[bigMakeLittle].usesLocalNPCImmunity = true;
                Main.projectile[bigMakeLittle].localNPCHitCooldown = 10;
                Main.projectile[bigMakeLittle].timeLeft = 600;
                Main.projectile[bigMakeLittle].tileCollide = false;
            }
        }
    }
}

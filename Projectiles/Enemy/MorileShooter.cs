using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Enemy
{
    public class MorileShooter : ModProjectile
    {
        private Player player;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morile Shooter");
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.light = 0f;
        }
        public override void AI()
        {
            projectile.rotation += 0.1f;
            projectile.velocity.X *= 0.9f;
            projectile.velocity.Y *= 0.9f;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 vector8 = new Vector2(projectile.position.X + (projectile.width / 2), projectile.position.Y + (projectile.height / 2));
            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
            Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * 8f) * -1), (float)((Math.Sin(rotation) * 8f) * -1), mod.ProjectileType("MorileShot"), projectile.damage, projectile.knockBack, projectile.owner);
        }
    }
}

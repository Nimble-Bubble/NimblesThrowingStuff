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
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.light = 0f;
        }
        public override void AI()
        {
            Projectile.rotation += 0.1f;
            Projectile.velocity.X *= 0.9f;
            Projectile.velocity.Y *= 0.9f;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 vector8 = new Vector2(Projectile.position.X + (Projectile.width / 2), Projectile.position.Y + (Projectile.height / 2));
            float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
            Projectile.NewProjectile(vector8, new Vector2((float)((Math.Cos(rotation) * 8f) * -1), (float)((Math.Sin(rotation) * 8f) * -1)), Mod.Find<ModProjectile>("MorileShot").Type, Projectile.damage, Projectile.knockBack, Projectile.owner);
        }
    }
}

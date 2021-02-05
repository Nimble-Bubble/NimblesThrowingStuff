using Microsoft.Xna.Framework;
using System.IO;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Projectiles.Magic
{
    public class PalladiumBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 0;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.penetrate = 1;
            projectile.maxPenetrate = 1;
            projectile.light = 0.5f;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
        }
        public override void AI()
        {
            projectile.velocity.X *= 1.02f;
            projectile.velocity.Y *= 1.02f;
            projectile.rotation = projectile.velocity.ToRotation() +MathHelper.ToRadians(90f);
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 144, (float)projectile.velocity.X / 5, (float)projectile.velocity.Y  / 5, 0, default(Color), 0.75f);
            }
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 144,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}

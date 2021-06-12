using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Ranged;

namespace NimblesThrowingStuff.Projectiles.Ranged
{
	public class MisfireProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 200;
            projectile.height = 200;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = -1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.alpha = 255;
            projectile.aiStyle = 1;
            projectile.timeLeft = 1;
        }
        public override void Kill(int timeLeft) 
        {
            for (int s = 0; s < 10; s++)
            {
                int smokeIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                Main.dust[smokeIndex].velocity *= 1.4f;
            }
            for (int f = 0; f < 20; f++)
            {
                int fireIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 127, 0f, 0f, 100, default(Color), 3f);
                Main.dust[fireIndex].velocity *= 4f;
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14, 1f, 0.0f);
            Main.player[projectile.owner].velocity.X -= projectile.velocity.X * 1;
            Main.player[projectile.owner].velocity.Y -= projectile.velocity.Y * 1;

        }
    }
}
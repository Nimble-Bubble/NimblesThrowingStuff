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
	public class ProcellariteShotgunProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.aiStyle = 0;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90);
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(SoundID.Shatter, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
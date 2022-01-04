using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Ranged
{
	public class BlazeBulletProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.usesLocalNPCImmunity = false;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.arrow = false;
            projectile.aiStyle = 0;
            projectile.extraUpdates = 2;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 60);
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(2, (int) projectile.position.X, (int) projectile.position.Y, 14, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
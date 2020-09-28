using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class StingerDaggerProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 24;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.maxPenetrate = 3;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 2;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 39, Main.rand.Next(2, 3), Main.rand.Next(2, 3), 0, default(Color), 0.75f);
            }
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(5))
            {
			target.AddBuff(BuffID.Poisoned, 100);
                }
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 39,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
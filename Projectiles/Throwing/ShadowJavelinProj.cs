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
	public class ShadowJavelinProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 272, Main.rand.Next(2, 3), Main.rand.Next(2, 3), 0, default(Color), 0.75f);
            }
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
			target.AddBuff(153, 150);
                }
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 272,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (Main.rand.NextBool(4))
            {
            Item.NewItem(projectile.getRect(), mod.ItemType("ShadowJavelin"), 1);
            }
        }
    }
}
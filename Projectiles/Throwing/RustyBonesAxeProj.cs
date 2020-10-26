using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class RustyBonesAxeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 2;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			projectile.extraUpdates += 1;
            target.AddBuff(70, 450);
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 26,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 8, new Color(), 0.75f);
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(projectile.getRect(), ModContent.ItemType<RustyBonesAxe>());
            }
        }
    }
}
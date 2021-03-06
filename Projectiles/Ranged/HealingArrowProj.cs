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
	public class HealingArrowProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.usesLocalNPCImmunity = false;
            projectile.tileCollide = true;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.aiStyle = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			Main.player[projectile.owner].HealEffect(damage / 50);
            Main.player[projectile.owner].statLife += damage / 50;
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 5,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void Kill(int timeLeft) 
        {
            Main.PlaySound(0, (int) projectile.position.X, (int) projectile.position.Y, 1, 1f, 0.0f);
                    for (int index = 0; index < 10; index++)
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 5,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(projectile.getRect(), ModContent.ItemType<HealingArrow>());
            }
        }
    }
}
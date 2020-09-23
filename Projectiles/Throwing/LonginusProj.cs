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
	public class LonginusProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 5;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 57,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
                int star = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 1000, 0, 20,
                            12, projectile.damage / 2, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                Main.projectile[star].thrown = true;
                Main.projectile[star].ranged = false;
            Main.projectile[star].usesLocalNPCImmunity = true;
                Main.projectile[star].localNPCHitCooldown = 10;
            Main.projectile[star].penetrate = 1;
        }
    }
}
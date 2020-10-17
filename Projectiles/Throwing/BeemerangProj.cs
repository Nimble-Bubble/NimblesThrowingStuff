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
	public class BeemerangProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 36;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.maxPenetrate = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 3;
            projectile.penetrate = -1;
            projectile.extraUpdates = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			if (Main.player[projectile.owner].strongBees == true && Main.rand.NextBool(3))
                {
                    int stronkbees = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X, projectile.velocity.Y,
                            566, projectile.damage / 2, 4f, projectile.owner, 0.0f, 0.0f); 
                    Main.projectile[stronkbees].thrown = true;
                Main.projectile[stronkbees].usesLocalNPCImmunity = true;
            Main.projectile[stronkbees].localNPCHitCooldown = 10;
                }
             int weakbees = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X / 2, projectile.velocity.Y / 2,
                            181, projectile.damage / 3, 2f, projectile.owner, 0.0f, 0.0f);   
                Main.projectile[weakbees].thrown = true;
                Main.projectile[weakbees].usesLocalNPCImmunity = true;
            Main.projectile[weakbees].localNPCHitCooldown = 10;
        }
    }
}
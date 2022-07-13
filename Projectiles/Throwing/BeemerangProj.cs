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
            Projectile.width = 16;
            Projectile.height = 36;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			if (Main.player[Projectile.owner].strongBees == true && Main.rand.NextBool(3))
                {
                    int strongspacebees = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, Projectile.velocity.X, Projectile.velocity.Y,
                            566, Projectile.damage / 2, 4f, Projectile.owner, 0.0f, 0.0f); 
                    Main.projectile[strongspacebees].DamageType = DamageClass.Throwing;
                Main.projectile[strongspacebees].usesLocalNPCImmunity = true;
            Main.projectile[strongspacebees].localNPCHitCooldown = 10;
                }
             int weakbees = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, Projectile.velocity.X / 2, Projectile.velocity.Y / 2,
                            181, Projectile.damage / 3, 2f, Projectile.owner, 0.0f, 0.0f);   
                Main.projectile[weakbees].DamageType = DamageClass.Throwing;
                Main.projectile[weakbees].usesLocalNPCImmunity = true;
            Main.projectile[weakbees].localNPCHitCooldown = 10;
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class FlameBlessedBeamProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.light = 0.5f;
            projectile.aiStyle = 27;
            aiType = 173;
            projectile.timeLeft = 600;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(24, 300);
        }
    }
}
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
	public class CursedCloud1: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(511);
            projectile.magic = false;
            projectile.thrown = true;
            aiType = 511;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.CursedInferno, 120);
        }
    }
}
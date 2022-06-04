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
	public class IchorCloud3: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(513);
            AIType = 513;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 60;
        }
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Ichor, 120);
        }
    }
}
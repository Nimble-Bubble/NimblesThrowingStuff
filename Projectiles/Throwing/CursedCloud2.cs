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
	public class CursedCloud2: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(512);
            AIType = 512;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 60;
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
			target.AddBuff(BuffID.CursedInferno, 120);
        }
    }
}
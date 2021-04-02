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
	public class MeteoriteDrillProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 20;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.light = 0.25f;
            projectile.aiStyle = 20;
            projectile.timeLeft = 18000;
            projectile.extraUpdates = 1;
        }
    }
}
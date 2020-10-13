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
	public class FestiveSnowflake : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 60;
            projectile.tileCollide = false;
            projectile.maxPenetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 60;
            projectile.thrown = true;
            projectile.aiStyle = 30;
            projectile.penetrate = -1;
        }
    }
}
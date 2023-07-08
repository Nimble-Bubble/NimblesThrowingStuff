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
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Festive Snowflake");
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 60;
            Projectile.tileCollide = false;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 60;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 30;
            Projectile.penetrate = -1;
        }
    }
}
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
	public class CumulusCrasherProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cumulus Crasher");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 26;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
        }
    }
}
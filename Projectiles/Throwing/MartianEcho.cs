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
	public class MartianEcho: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 34;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 150;
        }
    }
}
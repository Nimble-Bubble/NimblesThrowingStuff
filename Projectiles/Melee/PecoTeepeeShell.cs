using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Buffs;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class PecoTeepeeShell: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 0.75f;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
        }
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (crit)
            {
                target.AddBuff(BuffID.OnFire, 360);
            }
            else
            {
                target.AddBuff(BuffID.OnFire, 120);
            }
        }
    }
}
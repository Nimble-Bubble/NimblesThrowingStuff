using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class EmptyFlaskProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Empty Throwing Flask");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 2;
            Projectile.extraUpdates = 0;
        }
        public override void OnKill(int timeLeft) 
        {
            SoundEngine.PlaySound(SoundID.Item107, Projectile.position);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, -Projectile.oldVelocity * 0.2f, 704, 1f);
            Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, -Projectile.oldVelocity * 0.2f, 705, 1f);
        }
    }
}
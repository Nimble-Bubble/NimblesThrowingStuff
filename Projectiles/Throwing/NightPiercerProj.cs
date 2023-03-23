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
	public class NightPiercerProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Night's Piercer");
        }
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 32;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 100;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 9;
            Projectile.timeLeft = 300;
            Projectile.alpha = 0;
            AIType = 491;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
        public override void AI()
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 272, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
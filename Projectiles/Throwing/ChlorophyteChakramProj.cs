using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class ChlorophyteChakramProj: ModProjectile
    {
        private int index = 0; 
        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 2;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
                    }
			return false;
		}
        public override void AI() 
        {
            ++index;
                    if (index > 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int spore = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            228, Projectile.damage / 2, 1f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                        Main.projectile[spore].thrown = true;
                Main.projectile[spore].melee = false;
                    }
        }
    }
}
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
	public class TrueNightPiercerProj: ModProjectile
    {
        public int index = 0;
        public override void SetDefaults()
        {
            projectile.width = 28;
            projectile.height = 32;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 12;
            projectile.tileCollide = true;
            projectile.penetrate = 100;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 9;
            projectile.timeLeft = 300;
            projectile.light = 1;
            aiType = 491;
            projectile.extraUpdates = 1;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			projectile.penetrate--;
			if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
        public override void AI()
        {
            ++index;
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 272,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (index >= 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.05f;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            mod.ProjectileType("PiercerEcho"), projectile.damage, 0.75f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                index = 0;
                    }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Throwing/TrueNightPiercerProj_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Green,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}
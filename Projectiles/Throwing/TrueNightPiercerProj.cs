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
	public class TrueNightPiercerProj: ModProjectile
    {
        public int index = 0;
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 32;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.tileCollide = true;
            Projectile.penetrate = 100;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 9;
            Projectile.timeLeft = 300;
            Projectile.light = 1;
            AIType = 491;
            Projectile.extraUpdates = 1;
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
            ++index;
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 272,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            if (index >= 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-100, 101),
                            (float) Main.rand.Next(-100, 101));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 201) * 0.05f;
                        Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            Mod.Find<ModProjectile>("PiercerEcho").Type, Projectile.damage, 0.75f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                index = 0;
                    }
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.GetTexture("Projectiles/Throwing/TrueNightPiercerProj_Glow");
			spriteBatch.Draw
			(
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Green,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}
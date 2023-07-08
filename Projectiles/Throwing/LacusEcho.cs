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
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class LacusEcho: ModProjectile
    {
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lacus Echo");
		}
		public override void SetDefaults()
        {
            Projectile.width = 46;
            Projectile.height = 46;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 100;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 0;
			Projectile.timeLeft = 600;
            Projectile.light = 1;
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
			Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).X * 0.1f, Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).Y * 0.1f, 0, new Color(), 0.75f);
			Projectile.rotation += 0.5f;
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Throwing/LacusEcho").Value;
			Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Yellow, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
    }
}
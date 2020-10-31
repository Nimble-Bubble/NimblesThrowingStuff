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
	public class LumiKnifeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 22;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 1;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 600;
        }
        public override void Kill(int timeLeft) 
        {
            for (int f = 0; f < 10; f++) {
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 229,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
			}
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Throwing/LumiKnifeProj_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.SeaGreen,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}
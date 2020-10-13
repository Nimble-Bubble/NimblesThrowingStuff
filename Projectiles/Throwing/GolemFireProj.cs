using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class GolemFireProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.maxPenetrate = 1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 8;
            projectile.penetrate = 1;
            projectile.extraUpdates = 1;
            aiType = 15;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Throwing/GolemFireProj_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Yellow,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}
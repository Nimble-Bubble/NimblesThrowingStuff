using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class CosmosCrasherProj: ModProjectile
    {
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cosmos Crasher");     
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;    
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        
		}
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 38;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 5;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 1;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 150;
        }
        public override bool PreDraw(ref Color lightColor) {
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.GetTexture("Projectiles/Throwing/CosmosCrasherProj_Glow");
			spriteBatch.Draw
			(
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Cyan,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
    }
}
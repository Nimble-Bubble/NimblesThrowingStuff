using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ProcellariteBroadswordProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 38;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.light = 0.5f;
            projectile.alpha = 0;
            projectile.aiStyle = 1;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
        }
        public override void AI() 
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Melee/ProcellariteBroadswordProj_Glow");
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
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            for (int furbroaddust = 0; furbroaddust < 10; furbroaddust++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            }
        }
    }
}
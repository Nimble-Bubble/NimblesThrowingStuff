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
	public class DraconicHarvestProj: ModProjectile
    {
        private int index = 0; 
        public override void SetStaticDefaults() {
			DisplayName.SetDefault("Draconic Harvest");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        
		}
        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.maxPenetrate = -1;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.aiStyle = 3;
            projectile.penetrate = -1;
            projectile.extraUpdates = 3;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Throwing/DraconicHarvestProj_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Orange,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
        public override void AI() 
        {
            ++index;
            if (Main.rand.NextBool(5)) 
            {
				int fireIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width * 2, projectile.height * 2, 127, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
                    if (index > 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-10, 11),
                            (float) Main.rand.Next(-10, 11));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int spore = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector2.X, vector2.Y,
                            mod.ProjectileType("DraconicPortal"), projectile.damage, 1f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                        Main.projectile[spore].thrown = true;
                Main.projectile[spore].melee = false;
                    }
        }
    }
}
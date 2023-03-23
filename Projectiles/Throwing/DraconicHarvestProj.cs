using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;    
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        
		}
        public override void SetDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 60;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.maxPenetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 3;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 3;
        }
        public override bool PreDraw(ref Color lightColor) {
			Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++) {
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}
			return true;
		}
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Throwing/DraconicHarvestProj_Glow").Value;
			Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Orange, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
        public override void AI() 
        {
            ++index;
            if (Main.rand.NextBool(5)) 
            {
				int fireIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width * 2, Projectile.height * 2, 127, 0f, 0f, 100, default(Color), 3f);
				Main.dust[fireIndex].velocity *= 4f;
			}
                    if (index > 30)
                    {
                        var vector2 = new Vector2((float) Main.rand.Next(-10, 11),
                            (float) Main.rand.Next(-10, 11));
                        vector2.Normalize();
                        vector2 *= (float) Main.rand.Next(10, 11) * 1f;
                        int portal = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector2.X, vector2.Y,
                            Mod.Find<ModProjectile>("DraconicPortal").Type, Projectile.damage, 1f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
                        index = 0;
                    }
        }
    }
}
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
	public class FuriousBeam: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.light = 0.5f;
            projectile.alpha = 100;
            projectile.aiStyle = 27;
            projectile.extraUpdates = 1;
        }
        public override void AI() 
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 174,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Melee/FuriousBeam_Glow");
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
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(189, 750);
            int splode = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0,
            612, projectile.damage, 6f, projectile.owner, 0, (float) Main.rand.Next(-1, 1));
            Main.projectile[splode].usesLocalNPCImmunity = true;
            Main.projectile[splode].localNPCHitCooldown = 10;
        }
    }
}
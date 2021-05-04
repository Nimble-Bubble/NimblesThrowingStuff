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
	public class SkyseaSpinnerProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 750f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 40f;
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.alpha = 0;
            projectile.aiStyle = 99;
            projectile.extraUpdates = 1;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Melee/SkyseaSpinnerProj_Glow");
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
            Projectile.NewProjectile(projectile.position.X + Main.rand.Next(-1, 2), projectile.position.Y - 1000, Main.rand.Next(-1, 2), Main.rand.Next(5, 9), ModContent.ProjectileType<ProcellariteSpikeProj>(), projectile.damage / 3, projectile.knockBack, projectile.owner);
        }
    }
}
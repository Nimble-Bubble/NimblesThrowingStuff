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
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 750f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 40f;
            DisplayName.SetDefault("Sky-Sea Spinner");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.alpha = 0;
            Projectile.aiStyle = 99;
            Projectile.extraUpdates = 1;
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = ModContent.Request<Texture2D>("Projectiles/Melee/SkyseaSpinnerProj_Glow").Value;
            Main.EntitySpriteDraw
            (
				texture,
				Projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.Yellow,
				Projectile.rotation,
				texture.Size() * 0.5f,
				Projectile.scale,
				SpriteEffects.None,
				0
			);
		}
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X + Main.rand.Next(-1, 2), Projectile.position.Y - 1000, Main.rand.Next(-1, 2), Main.rand.Next(5, 9), ModContent.ProjectileType<ProcellariteSpikeProj>(), Projectile.damage / 3, Projectile.knockBack, Projectile.owner);
        }
    }
}
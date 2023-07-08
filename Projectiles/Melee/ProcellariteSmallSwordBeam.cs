using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ProcellariteSmallSwordBeam: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Miniature Procellarite Broadsword Beam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 0.5f;
            Projectile.alpha = 0;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 1;
        }
        public override void AI() 
        {
            if (Main.rand.NextBool(10))
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).X * 0.1f, Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).Y * 0.1f, 0, new Color(), 0.75f);
            }
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Melee/ProcellariteSmallSwordBeam_Glow").Value;
			Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Yellow, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
        public override void OnHitNPC (NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int furbroaddust = 0; furbroaddust < 10; furbroaddust++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).X * 0.1f, Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).Y * 0.1f, 0, new Color(), 0.75f);
            }
        }
    }
}
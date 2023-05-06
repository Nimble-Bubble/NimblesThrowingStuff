using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using Terraria.Audio;
using NimblesThrowingStuff.Dusts;

namespace NimblesThrowingStuff.Projectiles.Melee
{
	public class ProcellariteBroadswordProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Procellarite Broadsword Beam");
        }
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 38;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.light = 0.5f;
            Projectile.alpha = 0;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 60;
            Projectile.extraUpdates = 1;
        }
        public override void AI() 
        {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).X * 0.1f, Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(10)).Y * 0.1f, 0, new Color(), 1f); 
        }
        public override void PostDraw(Color lightColor)
		{
			Texture2D texture = Mod.Assets.Request<Texture2D>("Projectiles/Melee/ProcellariteBroadswordProj_Glow").Value;
            Main.EntitySpriteDraw(texture, Projectile.position, new Rectangle(0, 0, texture.Width, texture.Height), Color.Yellow, Projectile.rotation, texture.Size() * 0.5f, Projectile.scale, SpriteEffects.None, 0);
		}
        public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
        {
            for (int furbroaddust = 0; furbroaddust < 10; furbroaddust++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item74);
            for (int furbroaddust = 0; furbroaddust < 25; furbroaddust++)
            {
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<ProcellariteStarDust>(), Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(30)).X * 0.1f, Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(30)).Y * 0.1f, 0, new Color(), 1.5f);
            }
            int smallprobeam1 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<ProcellariteSmallSwordBeam>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            int smallprobeam2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(10)), ModContent.ProjectileType<ProcellariteSmallSwordBeam>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
            int smallprobeam3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity.RotatedBy(MathHelper.ToRadians(350)), ModContent.ProjectileType<ProcellariteSmallSwordBeam>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
        }
    }
}
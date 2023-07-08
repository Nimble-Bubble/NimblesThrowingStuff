using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class MartianMiracleProj: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Martian Miracle");
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 36;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = false;
            Projectile.penetrate = 33895;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.aiStyle = 9;
            Projectile.timeLeft = 3600;
            Projectile.light = 1;
            AIType = 491;
            Projectile.extraUpdates = 1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3))
            {
                int marechofire = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + Main.rand.Next(-250, 250), Projectile.Center.Y - Main.rand.Next(500, 750), Main.rand.NextFloat(-1.5f, 1.5f), 2.5f, ModContent.ProjectileType<MartianEcho>(), Projectile.damage, 2f, Projectile.owner, 0.0f, (float)Main.rand.Next(-45, 1));
                target.AddBuff(144, 240);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
			if (Projectile.penetrate <= 0) { Projectile.Kill(); }
			else {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X) { Projectile.velocity.X = -oldVelocity.X; }
				if (Projectile.velocity.Y != oldVelocity.Y) { Projectile.velocity.Y = -oldVelocity.Y; }
			}
			return false;
		}
        public override void AI()
        {
            if (Main.mouseRight)
            {
                Projectile.tileCollide = false;
            }
            else
            {
                Projectile.tileCollide = true;
            }
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 226, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Enums;
using NimblesThrowingStuff.Items.Weapons.Throwing;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class SkelespearProj: ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 34;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.tileCollide = true;
            Projectile.penetrate = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
        }
		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			width = height = 10; 
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}
        public bool IsStickingToTarget
		{
			get => Projectile.ai[0] == 1f;
			set => Projectile.ai[0] = value ? 1f : 0f;
		}
		public int TargetWhoAmI
		{
			get => (int)Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		private const int MAX_STICKY_JAVELINS = 8; 
		private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; 

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
        if (Projectile.damage > 1)
        {
        
            int stream = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, 22, Projectile.damage, 3.5f, Projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Main.projectile[stream].DamageType = DamageClass.Throwing;
            Main.projectile[stream].usesLocalNPCImmunity = true;
            Main.projectile[stream].localNPCHitCooldown = 10;
            Main.projectile[stream].penetrate = 5;      
            Projectile.damage = 0;
        }
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI; 
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; 
			Projectile.netUpdate = true; 
			UpdateStickyJavelins(target);
		}
		private void UpdateStickyJavelins(NPC target)
		{
			int currentJavelinIndex = 0; 

			for (int i = 0; i < Main.maxProjectiles; i++) 
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != Projectile.whoAmI 
					&& currentProjectile.active 
					&& currentProjectile.owner == Main.myPlayer 
					&& currentProjectile.type == Projectile.type 
					&& currentProjectile.ModProjectile is SkelespearProj daggerProjectile 
					&& daggerProjectile.IsStickingToTarget 
					&& daggerProjectile.TargetWhoAmI == target.whoAmI)
				{

					_stickingJavelins[currentJavelinIndex++] = new Point(i, currentProjectile.timeLeft); 
					if (currentJavelinIndex >= _stickingJavelins.Length)  
						break;
				}
			}
			if (currentJavelinIndex >= MAX_STICKY_JAVELINS)
			{
				int oldJavelinIndex = 0;
				for (int i = 1; i < MAX_STICKY_JAVELINS; i++)
				{
					if (_stickingJavelins[i].Y < _stickingJavelins[oldJavelinIndex].Y)
					{
						oldJavelinIndex = i; 
					}
				}
				Main.projectile[_stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}
		private const int MAX_TICKS = 60;
		int deathCount = 0;
		public override void AI()
		{
			if (IsStickingToTarget) StickyAI();
			else NormalAI();
		}

		private void NormalAI()
		{
			TargetWhoAmI++;
			if (TargetWhoAmI >= MAX_TICKS)
			{
				const float velXmult = 0.98f; 
				const float velYmult = 0.14f; 
				TargetWhoAmI = MAX_TICKS; 
				Projectile.velocity.X *= velXmult;
				Projectile.velocity.Y += velYmult;
			}
			Projectile.rotation =
				Projectile.velocity.ToRotation() +
				MathHelper.ToRadians(90f);
		}

		private void StickyAI()
		{
			Projectile.ignoreWater = true; 
            Projectile.alpha += 10;
			Projectile.tileCollide = false; 
			const int aiFactor = 3; 
			Projectile.localAI[0] += 1f;
			bool hitEffect = Projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (Projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
			{ 
				Projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
			{ 
				Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
				Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect)
				{ 
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else
			{ 
				Projectile.Kill();
			}
		}
        public override void Kill(int timeLeft)
        {
        for (int wd = 0; wd < 10; wd++)
        {
            Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 33,
                            Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                            }
        }
    }
}
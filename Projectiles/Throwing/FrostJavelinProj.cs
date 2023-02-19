using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Projectiles.Throwing
{
	public class FrostJavelinProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Javelin");
		}
		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 60;
			Projectile.DamageType = DamageClass.Throwing;
			Projectile.penetrate = 6;
			Projectile.hide = true;
            Projectile.timeLeft = 180;
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

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position); 
			Vector2 usePos = Projectile.position; 
			Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
			usePos += rotVector * 16f;
			const int NUM_DUSTS = 5;
			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 16);
				dust.position = (dust.position + Projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
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

		private const int MAX_STICKY_JAVELINS = 10; 
		private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; 

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
        if (Projectile.penetrate < 2 && Projectile.timeLeft > 60)
        {
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI; 
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; 
			Projectile.netUpdate = true; 
			UpdateStickyJavelins(target);
            Projectile.timeLeft = 60;
            }
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
					&& currentProjectile.ModProjectile is FestiveJavelinProj daggerProjectile 
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
		private const int MAX_TICKS = 4;
		private const int ALPHA_REDUCTION = 25;
		int deathCount = 0;
		public override void AI()
		{
			if (IsStickingToTarget) StickyAI();
			else NormalAI();
		}
		private void NormalAI()
		{
			TargetWhoAmI++;
			deathCount++;
            if (deathCount >= 600)
            {
				Projectile.Kill();
			}
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
	}
}
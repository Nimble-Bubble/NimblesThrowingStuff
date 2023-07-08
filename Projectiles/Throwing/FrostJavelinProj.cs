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
			// DisplayName.SetDefault("Frost Javelin");
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
            Projectile.timeLeft = 180;
			Projectile.alpha = 0;
			Projectile.aiStyle = 1;
		}
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position); 
			Vector2 usePos = Projectile.position; 
			Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); 
			usePos += rotVector * 16f;
			for (int i = 0; i < 10; i++)
			{
				Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 16);
				dust.position = (dust.position + Projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.Frostburn2, 240);
		}
	}
}
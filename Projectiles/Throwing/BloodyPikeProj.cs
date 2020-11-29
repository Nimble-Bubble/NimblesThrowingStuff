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
	public class BloodyPikeProj: ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 10;
            projectile.tileCollide = true;
            projectile.penetrate = 10;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 150;
        }
        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			if (projectile.ai[0] == 1f) 
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
				{
					if (Main.npc[npcIndex].behindTiles)
					{
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else
					{
						drawCacheProjsBehindNPCs.Add(index);
					}

					return;
				}
			}
			drawCacheProjsBehindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
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
			get => projectile.ai[0] == 1f;
			set => projectile.ai[0] = value ? 1f : 0f;
		}
		public int TargetWhoAmI
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		private const int MAX_STICKY_JAVELINS = 8; 
		private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; 

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
        if (projectile.damage > 1)
        {
            Main.player[projectile.owner].HealEffect(damage / 40);   
            Main.player[projectile.owner].statLife += damage / 40;
            int stream = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y,
            280, projectile.damage, 3.5f, projectile.owner, 0.0f, (float) Main.rand.Next(-45, 1));
            Main.projectile[stream].thrown = true;
            Main.projectile[stream].magic = false;
            Main.projectile[stream].usesLocalNPCImmunity = true;
            Main.projectile[stream].localNPCHitCooldown = 10;
            Main.projectile[stream].penetrate = 5;      
            projectile.damage = 0;
        }
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI; 
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f; 
			projectile.netUpdate = true; 
			UpdateStickyJavelins(target);
		}
		private void UpdateStickyJavelins(NPC target)
		{
			int currentJavelinIndex = 0; 

			for (int i = 0; i < Main.maxProjectiles; i++) 
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI 
					&& currentProjectile.active 
					&& currentProjectile.owner == Main.myPlayer 
					&& currentProjectile.type == projectile.type 
					&& currentProjectile.modProjectile is BloodyPikeProj daggerProjectile 
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
				projectile.velocity.X *= velXmult;
				projectile.velocity.Y += velYmult;
			}
			projectile.rotation =
				projectile.velocity.ToRotation() +
				MathHelper.ToRadians(90f);
		}

		private void StickyAI()
		{
			projectile.ignoreWater = true; 
            projectile.alpha += 10;
			projectile.tileCollide = false; 
			const int aiFactor = 3; 
			projectile.localAI[0] += 1f;
			bool hitEffect = projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200)
			{ 
				projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
			{ 
				projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
				projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect)
				{ 
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else
			{ 
				projectile.Kill();
			}
		}
        public override void Kill(int timeLeft)
        {
        for (int wd = 0; wd < 10; wd++)
        {
            Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 5,
                            projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, new Color(), 0.75f);
                            }
        }
    }
}
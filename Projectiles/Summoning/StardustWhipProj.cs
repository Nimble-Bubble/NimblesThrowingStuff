using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.Audio;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace NimblesThrowingStuff.Projectiles.Summoning
{
	public class StardustWhipProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Milkyway Cleaver");
			ProjectileID.Sets.IsAWhip[Type] = true;
		}

		public sealed override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
            Projectile.aiStyle = 165;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Summon;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 1;
			Projectile.WhipSettings.Segments = 12;
			Projectile.WhipSettings.RangeMultiplier = 1.2f;
		}

		public override void AI() 
        {
			Player player = Main.player[Projectile.owner];

			if (Main.rand.NextBool(20))
            {
				int launchFlowInvader = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * new Vector2(1.25f, 1.25f), ProjectileID.StardustJellyfishSmall, Projectile.damage / 2, Projectile.knockBack / 2, Main.myPlayer, 0.0f, (float)Main.rand.Next(0, 45));
				Main.projectile[launchFlowInvader].hostile = false;
				Main.projectile[launchFlowInvader].friendly = true;
				Main.projectile[launchFlowInvader].DamageType = DamageClass.Summon;
			} 
			// StardustJellyfishSmall flies towards the player regardless of firing velocity
			// May have to replace that vanilla projectile with a custom one
			/* #region Active check
                int num1 = Projectile.type == ModContent.ProjectileType<MiniMossHornetProj>() ? 1 : 0;
			if (!player.active) {
				player.ClearBuff(Mod.Find<ModBuff>("MossHornetBuff").Type);
			}
			if (player.HasBuff(Mod.Find<ModBuff>("MossHornetBuff").Type)) {
				Projectile.timeLeft = 2;
			}
             if (num1 == 0)
             {
        return;
             }
            player.AddBuff(ModContent.BuffType<MossHornetBuff>(), 18000, true);
			#endregion
                
			#region Animation and visuals
			Lighting.AddLight(Projectile.Center, Color.Green.ToVector3() * 0.75f);
			#endregion */
		}
		private void DrawLine(List<Vector2> list)
		{
			Texture2D texture = TextureAssets.FishingLine.Value;
			Rectangle frame = texture.Frame();
			Vector2 origin = new Vector2(frame.Width / 2, 2);

			Vector2 pos = list[0];
			for (int i = 0; i < list.Count - 1; i++)
			{
				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2;
				Color color = Lighting.GetColor(element.ToTileCoordinates(), Color.White);
				Vector2 scale = new Vector2(1, (diff.Length() + 2) / frame.Height);

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, SpriteEffects.None, 0);

				pos += diff;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			List<Vector2> list = new List<Vector2>();
			Projectile.FillWhipControlPoints(Projectile, list);

			DrawLine(list);

			Main.DrawWhip_WhipBland(Projectile, list);
			/* The code below is for custom drawing.
			// If you don't want that, you can remove it all and instead call one of vanilla's DrawWhip methods, like above.
			// However, you must adhere to how they draw if you do.

			SpriteEffects flip = Projectile.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			Main.instance.LoadProjectile(Type);
			Texture2D texture = TextureAssets.Projectile[Type].Value;

			Vector2 pos = list[0];

			for (int i = 0; i < list.Count - 1; i++)
			{
				// These two values are set to suit this projectile's sprite, but won't necessarily work for your own.
				// You can change them if they don't!
				Rectangle frame = new Rectangle(0, 0, 10, 26);
				Vector2 origin = new Vector2(5, 8);
				float scale = 1;

				// These statements determine what part of the spritesheet to draw for the current segment.
				// They can also be changed to suit your sprite.
				if (i == list.Count - 2)
				{
					frame.Y = 74;
					frame.Height = 18;

					// For a more impactful look, this scales the tip of the whip up when fully extended, and down when curled up.
					Projectile.GetWhipSettings(Projectile, out float timeToFlyOut, out int _, out float _);
					float t = Timer / timeToFlyOut;
					scale = MathHelper.Lerp(0.5f, 1.5f, Utils.GetLerpValue(0.1f, 0.7f, t, true) * Utils.GetLerpValue(0.9f, 0.7f, t, true));
				}
				else if (i > 10)
				{
					frame.Y = 58;
					frame.Height = 16;
				}
				else if (i > 5)
				{
					frame.Y = 42;
					frame.Height = 16;
				}
				else if (i > 0)
				{
					frame.Y = 26;
					frame.Height = 16;
				}

				Vector2 element = list[i];
				Vector2 diff = list[i + 1] - element;

				float rotation = diff.ToRotation() - MathHelper.PiOver2; // This projectile's sprite faces down, so PiOver2 is used to correct rotation.
				Color color = Lighting.GetColor(element.ToTileCoordinates());

				Main.EntitySpriteDraw(texture, pos - Main.screenPosition, frame, color, rotation, origin, scale, flip, 0);

				pos += diff;
			} */
			return false; 
		}
	}
}
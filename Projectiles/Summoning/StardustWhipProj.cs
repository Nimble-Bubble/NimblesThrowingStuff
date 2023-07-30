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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.player[Projectile.owner].MinionAttackTargetNPC = target.whoAmI;
        }
        public override void AI() 
        {
			Player player = Main.player[Projectile.owner];

			if (Main.rand.NextBool(20))
            {
				int launchCellShot = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.velocity * new Vector2(1.25f, 1.25f), ProjectileID.StardustCellMinionShot, Projectile.damage / 2, Projectile.knockBack / 2, Main.myPlayer, 0.0f, (float)Main.rand.Next(0, 45));
			} 
			//This used to be the Flow Invader projectile, but that didn't work out too well
			//It launched towards the player instead of in the direction of the whip
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

			return false; 
		}
	}
}
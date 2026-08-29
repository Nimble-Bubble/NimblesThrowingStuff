using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class Rumbalarum : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 75;
			Item.useStyle = 1;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.knockBack = 5f;
			Item.width = 72;
			Item.height = 80;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 23, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item22;
			Item.autoReuse = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(5))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226);
			}
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			for (int f = 0; f < 3; f++)
			{
				int zapIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1f);
				Main.dust[zapIndex].velocity *= 3f;
			}
			if (!target.buffImmune[BuffID.Electrified])
			{
				for (int f = 0; f < 12; f++)
				{
					int zapIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 226, 0f, 0f, 100, default(Color), 1.25f);
					Main.dust[zapIndex2].velocity *= 6f;
				}
				SoundEngine.PlaySound(SoundID.Item94);
				target.AddBuff(BuffID.Electrified, 150);
			}
		}
		/* public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Katana);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(ItemID.Glowstick, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Keybrand);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(ItemID.Glowstick, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ItemID.Diamond, 2);
			recipe.AddIngredient(ItemID.Glowstick, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		} */
	}
}
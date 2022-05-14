using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class Seastring : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires a high-velocity watery arrow");
		}

		public override void SetDefaults()
		{
			item.damage = 25;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.buyPrice(0, 13, 50, 0);
			item.rare = ItemRarityID.Orange;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shoot = ProjectileID.WoodenArrowFriendly;
            item.knockBack = 8f;
			item.shootSpeed = 15f;
			item.ranged = true;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<SeastringArrowProj>(), damage, knockBack, player.whoAmI);
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
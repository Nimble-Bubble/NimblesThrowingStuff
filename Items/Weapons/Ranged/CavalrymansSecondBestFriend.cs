using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class CavalrymansSecondBestFriend : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.width = 56;
			Item.height = 20;
			Item.useTime = 10;
			Item.useAnimation = 60;
			Item.reuseDelay = 90;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Green;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item5;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 6f;
			Item.shootSpeed = 12f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(154, 20);
			recipe.AddIngredient(150, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(154, 20);
			recipe.AddIngredient(150, 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
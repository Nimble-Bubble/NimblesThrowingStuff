using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ProcellariteRepeater : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 68;
			Item.width = 60;
			Item.height = 30;
			Item.useTime = 5;
			Item.useAnimation = 6;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 5f;
			Item.shootSpeed = 38f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 10);
			recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
			recipe.Register();
		}
	}
}
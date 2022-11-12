using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ProcellariteTrident : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.damage = 240;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 36;
			Item.useTime = 36;
			Item.knockBack = 5f;
			Item.width = 90;
			Item.height = 90;
			Item.scale = 1.2f;
			Item.rare = ItemRarityID.Purple;
			Item.value = Item.buyPrice(1, 0, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ProcellariteTridentProj>();
            Item.shootSpeed = 9f;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
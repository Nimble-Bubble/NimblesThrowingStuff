using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class Estoc : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Its point is small, and it may be weak, but it leaves an impact on its unfortunate targets.");
		}
		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.knockBack = 8f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 3, 75, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<EstocProj>();
			Item.shootSpeed = 8f;
			Item.UseSound = SoundID.Item1;
			Item.crit = 20;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<IronLance>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 12);
			recipe.AddIngredient(ItemID.Diamond, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
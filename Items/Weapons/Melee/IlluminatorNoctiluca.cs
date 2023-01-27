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
	public class IlluminatorNoctiluca : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("\"Noctiluca\" the Illuminator");
			Tooltip.SetDefault("In the darkness of the night, \"Noctiluca\" gave them light."
				+"\nCritical strikes and reloads build up energy"
				+"\nRight click to fire an illuminous blast if accumulated energy is high enough");
		}
		public override void SetDefaults()
		{
			Item.damage = 150;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 7f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.DamageType = DamageClass.Melee;
			//Item.channel = true;
			Item.shoot = ModContent.ProjectileType<IlluminatorNoctilucaProj>();
			Item.shootSpeed = 14f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
			Item.crit = 10;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SpectrePiercer>(), 1);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
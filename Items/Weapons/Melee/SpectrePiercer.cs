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
	public class SpectrePiercer : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("This spectral lance is mysterious, yet strong all the same."
				+"\nCritical strikes make you invincible and invisible for a short period of time");
		}
		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 21;
			Item.useTime = 21;
			Item.knockBack = 7f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 35, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<SpectrePiercerProj>();
			Item.shootSpeed = 14f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.14f;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Ascalon>(), 1);
			recipe.AddIngredient(ItemID.SpectreBar, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
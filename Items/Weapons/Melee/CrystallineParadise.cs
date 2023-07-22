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
	public class CrystallineParadise : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A mystical spear first forged by the Elder of the Forest."
							 + "\nCauses enemies to bleed upon impact."); */
		}
		public override void SetDefaults()
		{
			Item.damage = 82;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 13;
			Item.useTime = 13;
			Item.knockBack = 10f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(0, 37, 50, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<CrystallineParadiseProj>();
			Item.shootSpeed = 15f;
			Item.UseSound = SoundID.Item1;
			Item.crit = 20;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Valhalla>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.CrystalShard, 24);
			recipe.AddIngredient(ModContent.ItemType<EssenceOfBalance>(), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
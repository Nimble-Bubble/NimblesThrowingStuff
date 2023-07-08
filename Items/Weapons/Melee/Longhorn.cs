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
	public class Longhorn : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Rough-hewn, but sturdy.");
        }
        public override void SetDefaults() {
			Item.damage = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.knockBack = 4f;
			Item.width = 40;
			Item.height = 40;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.buyPrice(0, 0, 37, 50);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<LonghornProj>();
            Item.shootSpeed = 8f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ModContent.ItemType<BeastBone>(), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
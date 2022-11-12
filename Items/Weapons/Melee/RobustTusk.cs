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
	public class RobustTusk : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("The added leather allows for higher agility"
				+"\nRight click to launch yourself in the direction of the lance");
        }
        public override void SetDefaults() {
			Item.damage = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.knockBack = 6f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 75, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<RobustTuskProj>();
            Item.shootSpeed = 8f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RottenChunk, 10);
			recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Vertebrae, 10);
			recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient(ItemID.Leather, 5);
			recipe.AddIngredient(ModContent.ItemType<BeastBone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TissueSample, 10);
			recipe.AddIngredient(ItemID.Leather, 5);
			recipe.AddIngredient(ModContent.ItemType<BeastBone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
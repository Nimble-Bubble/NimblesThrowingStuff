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
	public class FortressBreaker : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("This lance can break through defenses."
				+"\nCritical hits completely ignore defense."); */
        }
        public override void SetDefaults() {
			Item.damage = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.knockBack = 8f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 8, 75, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<FortressBreakerProj>();
            Item.shootSpeed = 7f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.BlueBrick, 25);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.GreenBrick, 25);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.PinkBrick, 25);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
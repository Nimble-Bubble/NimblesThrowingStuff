using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class IronLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Iron Lance");
			Tooltip.SetDefault("A heavy lance for sure, but its power makes up for it.");
        }
        public override void SetDefaults() {
			Item.damage = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 6f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 12, 50);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<IronLanceProj>();
            Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}
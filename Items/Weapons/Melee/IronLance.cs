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
			item.damage = 12;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.knockBack = 6f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(0, 0, 2, 70);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<IronLanceProj>();
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
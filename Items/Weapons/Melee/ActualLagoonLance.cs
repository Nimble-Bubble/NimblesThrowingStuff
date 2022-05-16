using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ActualLagoonLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Laguna Lance");
			Tooltip.SetDefault("This water gun-like lance pulls moisture from the air into its chamber."
				+"\nRight click while holding the lance out to fire a high-pressure stream of water.");
        }
        public override void SetDefaults() {
			item.damage = 33;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 30;
			item.useTime = 30;
			item.knockBack = 4f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 1, 35, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<ActualLagoonLanceProj>();
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddIngredient(ItemID.GoldenKey, 2);
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
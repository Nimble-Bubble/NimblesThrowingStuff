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
	public class RedTail : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Made to resemble a Rathalos' tail. It's a bit small, but it spits flames."
				+"\nRight click to spew flames from the tip of the lance.");
        }
        public override void SetDefaults() {
			item.damage = 26;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 32;
			item.useTime = 32;
			item.knockBack = 7f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 15, 0, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<RedTailProj>();
            item.shootSpeed = 10f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 8);
			recipe.AddIngredient(ItemID.BeeWax, 12);
			recipe.AddIngredient(ItemID.Fireblossom, 10);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
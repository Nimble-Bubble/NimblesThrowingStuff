using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class DemonLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Demonite Lance");
			Tooltip.SetDefault("Cthulhu's hardened flesh brings out the best in shortswords.");
        }
        public override void SetDefaults() {
			Item.damage = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 5.5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 1, 35, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<DemonLanceProj>();
            Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<IronLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
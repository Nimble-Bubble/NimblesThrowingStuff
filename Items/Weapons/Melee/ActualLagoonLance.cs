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
			Item.damage = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.knockBack = 3.5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 1, 35, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ActualLagoonLanceProj>();
            Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddIngredient(ItemID.GoldenKey, 2);
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
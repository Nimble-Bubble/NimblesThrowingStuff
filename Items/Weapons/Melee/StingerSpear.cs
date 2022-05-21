using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class StingerSpear : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Has a chance to poison enemies");
        }

        public override void SetDefaults() {
			item.damage = 24;
			item.useStyle = 5;
			item.useAnimation = 38;
			item.useTime = 38;
			item.knockBack = 5.5f;
			item.width = 36;
			item.height = 36;
			item.shoot = ModContent.ProjectileType<StingerSpearProj>();
            item.shootSpeed = 3.25f;
			item.rare = ItemRarityID.Green;
            item.noUseGraphic = true;
            item.noMelee = true;
			item.value = Item.sellPrice(silver: 54);
            item.melee = true;
			item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
            recipe.AddIngredient(ItemID.Stinger, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
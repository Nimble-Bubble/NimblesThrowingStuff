using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class MahoganyStinger : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Sting like a bee. Fly...like a bee."
				+"\nRight click to launch yourself in the direction of the lance."
				+"\nHits may poison enemies.");
        }
        public override void SetDefaults() {
			item.damage = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 35;
			item.useTime = 35;
			item.knockBack = 4.5f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.buyPrice(0, 4, 5, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<MahoganyStingerProj>();
            item.shootSpeed = 9f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.Stinger, 3);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
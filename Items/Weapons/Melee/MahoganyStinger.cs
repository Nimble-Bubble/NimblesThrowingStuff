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
			Item.damage = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.knockBack = 4.5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 4, 5, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<MahoganyStingerProj>();
            Item.shootSpeed = 9f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RichMahogany, 12);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.Stinger, 3);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}
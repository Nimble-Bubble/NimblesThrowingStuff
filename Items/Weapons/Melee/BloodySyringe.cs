using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class BloodySyringe : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("AB is a universal recipient. O is a universal donor. This is a universal source of pain."
				+"\nRight click while holding the lance out to fire a stream of blood.");
        }
        public override void SetDefaults() {
			item.damage = 18;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 24;
			item.useTime = 24;
			item.knockBack = 6f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 1, 35, 0);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<BloodySyringeProj>();
            item.shootSpeed = 11f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddIngredient(ModContent.ItemType<IronLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
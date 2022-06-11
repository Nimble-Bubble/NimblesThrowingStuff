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
			Item.damage = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 6f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 1, 35, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<BloodySyringeProj>();
            Item.shootSpeed = 11f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe.AddIngredient(ModContent.ItemType<IronLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
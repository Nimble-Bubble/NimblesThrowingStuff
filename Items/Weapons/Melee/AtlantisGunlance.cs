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
	public class AtlantisGunlance : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("From the depths of the abyss comes this feared beast..."
				+"\nRight click while holding the gunlance out to fire a shell. Shells do 5/4 of the weapon's base damage.");
        }
        public override void SetDefaults() {
			Item.damage = 80;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 4f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<AtlantisGunlanceProj>();
            Item.shootSpeed = 14f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalFin>(), 5);
			recipe.AddIngredient(ModContent.ItemType<KnightLance>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
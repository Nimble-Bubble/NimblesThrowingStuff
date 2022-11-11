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
	public class PanthalassicGunlance : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("From an abyss so old that most would call it a niwelnysse, this beast awakens"
				+"\nRight click while holding the gunlance out to fire a shell. Shells do 5/4 of the weapon's base damage."
				+"\nThe maximum amount of shells for this weapon is 6. Each reload gives you 2 shells.");
        }
        public override void SetDefaults() {
			Item.damage = 160;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.knockBack = 6f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Red;
			Item.value = Item.buyPrice(1, 25, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<PanthalassicGunlanceProj>();
            Item.shootSpeed = 16f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddIngredient(ModContent.ItemType<AtlantisGunlance>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
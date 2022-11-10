using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class SeaDiver : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Part-gun, part-lance, part-shark. It's completely safe, we swear."
				+"\nRight click while using to shoot. Guard and right click while using to reload."
				+"\nAfter reloading, you can shoot up to six times before needing to reload again.");
        }
        public override void SetDefaults() {
			Item.damage = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 8;
			Item.useTime = 8;
			Item.knockBack = 4f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 4, 50, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<SeaDiverProj>();
            Item.shootSpeed = 9f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ModContent.ItemType<PaladinLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkFin, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkFin, 8);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
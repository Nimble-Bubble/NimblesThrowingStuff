using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class AtlantisGunlance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("From the depths of the abyss comes this feared beast..."
				+"\nRight click while holding the gunlance out to fire a shell. Shells do 125% of the weapon's base damage."
				+"\nThis gunlance holds up to 3 shells. Each reload gives you 1 shell."); */
        }
        public override void SetDefaults() {
			Item.damage = 90;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 5.5f;
			Item.width = 70;
			Item.height = 70;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<AtlantisGunlanceProj>();
            Item.shootSpeed = 14f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalFin>(), 8);
			recipe.AddIngredient(ModContent.ItemType<DeepBuster>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RoyalFin>(), 12);
			recipe.AddIngredient(ItemID.SharkFin, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
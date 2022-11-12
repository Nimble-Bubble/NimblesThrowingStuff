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
	public class Feathersting : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Fly with wings of feathers and sting with talons of bone"
				+"\nWhile attacking, you are immune to fall damage");
        }
        public override void SetDefaults() {
			Item.damage = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 18;
			Item.useTime = 18;
			Item.knockBack = 4f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 2, 50, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<FeatherstingProj>();
            Item.shootSpeed = 10.5f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Feather, 10);
			recipe.AddIngredient(ItemID.Cloud, 25);
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
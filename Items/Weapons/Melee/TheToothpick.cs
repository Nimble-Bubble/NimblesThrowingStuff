using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class TheToothpick : ModItem
	{

		public override void SetDefaults() {
			Item.damage = 12;
			Item.useStyle = 5;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 4f;
			Item.width = 36;
			Item.height = 36;
			Item.shoot = ModContent.ProjectileType<TheToothpickProj>();
            Item.shootSpeed = 4.5f;
			Item.rare = ItemRarityID.Blue;
            Item.noUseGraphic = true;
            Item.noMelee = true;
			Item.value = Item.sellPrice(silver: 54);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}
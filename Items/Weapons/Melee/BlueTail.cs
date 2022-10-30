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
	public class BlueTail : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("A jeweled Lance at the forefront of fire weapon manufacturing technology."
				+"\nRight click to spew flames from the tip of the lance.");
        }
        public override void SetDefaults() {
			Item.damage = 72;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.knockBack = 7f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.buyPrice(0, 70, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<BlueTailProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedTail>());
			recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddIngredient(ItemID.ShroomiteBar, 8);
			recipe.AddIngredient(ItemID.LargeRuby);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
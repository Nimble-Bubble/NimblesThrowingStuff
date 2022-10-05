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
	public class Ascalon : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Made with valuable ores, this lance can slice and thrust."
				+"\nRight click to fire a holy laser beam. Guard and right click to charge the laser beams.");
		}
		public override void SetDefaults()
		{
			Item.damage = 57;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.knockBack = 7f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 23, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<AscalonProj>();
			Item.shootSpeed = 14f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.15f;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<KnightLance>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
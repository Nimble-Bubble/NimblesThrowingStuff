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
	public class KnightLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Made with valuable ores, this lance can slice and thrust."
				+"\nRight click to swing like a sword.");
		}
		public override void SetDefaults()
		{
			item.damage = 47;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 26;
			item.useTime = 26;
			item.knockBack = 6.5f;
			item.width = 76;
			item.height = 76;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.LightRed;
			item.value = Item.buyPrice(0, 15, 0, 0);
			item.melee = true;
			item.channel = true;
			item.shoot = ModContent.ProjectileType<KnightLanceProj>();
			item.shootSpeed = 13f;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.15f;
		}
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.shoot = ProjectileID.None;
				item.noUseGraphic = false;
				item.noMelee = false;
            }
			else
            {
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.shoot = ModContent.ProjectileType<KnightLanceProj>();
				item.noUseGraphic = true;
				item.noMelee = true;
			}
			return base.CanUseItem(player);
        }
        public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>(), 1);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>(), 1);
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddIngredient(ItemID.CobaltBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddIngredient(ItemID.PalladiumBar, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
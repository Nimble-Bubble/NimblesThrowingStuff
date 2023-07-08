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
	public class SpikedJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("This lance is lightweight and easy to craft, which makes it popular among hunters."
				+"\nRight click to throw the lance like a javelin"); */
		}
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 5f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 15, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<SpikedJavelinProj>();
			Item.shootSpeed = 13f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.15f;
		}
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shoot = ModContent.ProjectileType<SpikedJavelinThrown>();
            }
			else
            {
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.shoot = ModContent.ProjectileType<SpikedJavelinProj>();
			}
			return base.CanUseItem(player);
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<FortressBreaker>(), 1);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddRecipeGroup(nameof(ItemID.CursedFlames), 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddRecipeGroup(nameof(ItemID.CursedFlames), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
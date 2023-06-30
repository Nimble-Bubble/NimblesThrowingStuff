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
	public class ActualLagoonLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Laguna Lance");
			Tooltip.SetDefault("This lance resembles a water gun in its function, but its origins are shrouded in mystery."
				+"\nRight click while holding the lance out to fire a high-pressure stream of water.");
        }
        public override void SetDefaults() {
			Item.damage = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 16;
			Item.useTime = 16;
			Item.knockBack = 3.5f;
			Item.width = 64;
			Item.height = 64;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 1, 35, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ActualLagoonLanceProj>();
            Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddIngredient(ItemID.GoldenKey, 2);
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
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
	public class TerrificBloodySyringe : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("AB is a universal recipient. O is a universal donor. This is a universal source of pain."
				+"\nRight click while holding the lance out to fire a stream of ichor."); */
        }
        public override void SetDefaults() {
			Item.damage = 138;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 8f;
			Item.width = 96;
			Item.height = 96;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Cyan;
			Item.value = Item.buyPrice(0, 27, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<TerrificBloodySyringeProj>();
            Item.shootSpeed = 13f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<EssenceOfBalance>(), 8);
			recipe.AddIngredient(ModContent.ItemType<DecayedBloodySyringe>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class PecoTeepee : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A gunlance covered in vivid Qurupeco feathers. The lighter inside allows for blazing strikes."
				+"\nRight click while using to blast. Guard and right click while using to reload."
				+"\nAfter reloading, you can blast up to five times before needing to reload again."
				+"\nSorry about the placeholder. I haven't made a Qurupeco palette yet."); */
        }
        public override void SetDefaults() {
			Item.damage = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.knockBack = 5f;
			Item.width = 64;
			Item.height = 64;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 3, 97, 50);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<PecoTeepeeProj>();
            Item.shootSpeed = 8f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 15;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GreenQurupecoFeather>(), 6);
			recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 12);
			recipe.AddIngredient(ModContent.ItemType<Feathersting>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 12);
			recipe.AddIngredient(ModContent.ItemType<GreenQurupecoFeather>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
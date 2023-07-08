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
	public class Deinolonchi : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("The fang-based design of this lance gives it some nostalgic charm");
        }
        public override void SetDefaults() {
			Item.damage = 29;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.knockBack = 5.5f;
			Item.width = 56;
			Item.height = 56;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 14, 50, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<DeinolonchiProj>();
            Item.shootSpeed = 13f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.FossilOre, 20);
			recipe.AddIngredient(ModContent.ItemType<Feathersting>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
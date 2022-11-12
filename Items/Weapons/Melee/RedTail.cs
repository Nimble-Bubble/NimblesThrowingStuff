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
	public class RedTail : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Made to resemble a Rathalos' tail. It's a bit small, but it spits flames."
				+"\nRight click to spew flames from the tip of the lance.");
        }
        public override void SetDefaults() {
			Item.damage = 26;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.knockBack = 7f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<RedTailProj>();
            Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 8);
			recipe.AddIngredient(ItemID.BeeWax, 12);
			recipe.AddIngredient(ItemID.Fireblossom, 10);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
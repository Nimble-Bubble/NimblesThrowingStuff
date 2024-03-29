using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class CursedDemonLance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Cursed Demonite Lance");
			// Tooltip.SetDefault("Cthulhu's hardened flesh brings out the best in shortswords.");
        }
        public override void SetDefaults() {
			Item.damage = 48;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 19;
			Item.useTime = 19;
			Item.knockBack = 6.5f;
			Item.width = 64;
			Item.height = 64;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 13, 50, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<CursedDemonLanceProj>();
            Item.shootSpeed = 11f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CursedFlames, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ModContent.ItemType<DemonLance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
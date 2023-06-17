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
	public class SpaceSpinner : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("The Meteormaker");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Rains meteors from the sky on critical strikes");
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 50;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 6;
			Item.useTime = 6;
			Item.knockBack = 3f;
			Item.width = 24;
			Item.height = 24;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 0, 3, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<SpaceSpinnerProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
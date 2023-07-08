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
	public class DeepBuster : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("Part-gunlance, part-landshark. It's completely safe and totally original, we swear."
				+"\nRight click while using to shoot. Guard and right click while using to reload."
				+"\nAfter reloading, you can shoot up to eight times before needing to reload again."); */
        }
        public override void SetDefaults() {
			Item.damage = 33;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 7;
			Item.useTime = 7;
			Item.knockBack = 5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 35, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<DeepBusterProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkFin, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 20);
			recipe.AddIngredient(ModContent.ItemType<SeaDiver>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
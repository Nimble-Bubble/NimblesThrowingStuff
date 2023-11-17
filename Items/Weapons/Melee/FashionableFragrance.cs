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
	public class FashionableFragrance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A lance modeled after a mythical plant. It matches its fashionable exterior with a pleasant odor."
				+"\n...Pleasant enough to you, at least. Right click while attacking to fire a poisonous spore cloud."); */
        }
        public override void SetDefaults() {
			Item.damage = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 5f;
			Item.width = 80;
			Item.height = 80;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 17, 50, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<FashionableFragranceProj>();
            Item.shootSpeed = 14f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TurtleShell, 1);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ModContent.ItemType<Fragrance>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
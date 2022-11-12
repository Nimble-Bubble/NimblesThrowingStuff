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
	public class DecayedBloodySyringe : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("AB is a universal recipient. O is a universal donor. This is a universal source of pain."
				+"\nRight click while holding the lance out to fire a stream of ichor.");
        }
        public override void SetDefaults() {
			Item.damage = 54;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 7f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 13, 50, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<DecayedBloodySyringeProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Ichor, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ModContent.ItemType<BloodySyringe>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
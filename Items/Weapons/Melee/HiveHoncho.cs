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
	public class HiveHoncho : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("With a stinger like this, the bugs will know you're their boss."
				+"\nUnfortunately for you, they're planning some changes in the command of order, so to speak."
				+"\nRight click to release bees (that each deal one third of base damage) gained from critical strike. \nEach critical strike adds 1 bee, and you can have up to 6 bees."); */
        }
        public override void SetDefaults() {
			Item.damage = 27;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.knockBack = 5.5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 11, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.channel = true;
            Item.shoot = ModContent.ProjectileType<HiveHonchoProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 9;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BeeWax, 12);
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddIngredient(ModContent.ItemType<RobustTusk>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
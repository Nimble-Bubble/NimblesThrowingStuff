using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using Terraria.DataStructures;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class HermitaurHuntingbow : ModItem
	{
		private bool penAdd;
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.width = 34;
			Item.height = 54;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 5, 75, 0);
			Item.rare = ItemRarityID.Blue;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 4f;
			Item.shootSpeed = 9f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
			penAdd = false;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int penetrateArrow = Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, type, damage, knockback, Main.myPlayer);
			if (!penAdd && Main.projectile[penetrateArrow].penetrate >= 1)
			{
			Main.projectile[penetrateArrow].penetrate += 2;
			}
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<HermitaurShell>(), 12);
			recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -4);
		}
	}
}
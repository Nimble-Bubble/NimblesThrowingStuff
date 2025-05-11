using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class OtisChoice : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.width = 44;
			Item.height = 30;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Pink;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 7f;
			Item.shootSpeed = 14f;
			Item.DamageType = DamageClass.Ranged;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddIngredient(ItemID.CopperCoin, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddIngredient(ItemID.CopperCoin, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 2);
			recipe.AddIngredient(ItemID.AdamantiteBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 2);
			recipe.AddIngredient(ItemID.TitaniumBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 4);
		}
	}
}
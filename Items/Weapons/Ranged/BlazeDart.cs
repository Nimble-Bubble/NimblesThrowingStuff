using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class BlazeDart : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Tooltip.SetDefault("Sets enemies on fire");
        }
        public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 9999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 3f;
			Item.value = 12;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ModContent.ProjectileType<BlazeDartProj>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 3f;                  //The speed of the projectile
			Item.ammo = AmmoID.Dart;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(100);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class BlazeDart : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 3f;
			Item.value = 12;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ModContent.ProjectileType<BlazeDartProj>();  
			Item.shootSpeed = 3f;                  
			Item.ammo = AmmoID.Dart;              
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(100);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 1);
			recipe.Register();
		}
	}
}
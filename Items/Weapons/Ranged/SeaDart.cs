using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class SeaDart : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults() {
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 28;
			Item.maxStack = 9999;
			Item.consumable = true;            
			Item.knockBack = 4.5f;
			Item.value = 20;
			Item.rare = ItemRarityID.Orange;
			Item.shoot = ModContent.ProjectileType<SeaDartProj>();  
			Item.shootSpeed = 5f;                  
			Item.ammo = AmmoID.Dart;              
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(100);
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 1);
			recipe.Register();
		}
	}
}
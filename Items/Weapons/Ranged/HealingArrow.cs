using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class HealingArrow : ModItem
	{
		public override void SetStaticDefaults() 
		{ 
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			Tooltip.SetDefault("Heals you by a small amount depending on the damage dealt"
				+"\nYou can't heal more than 5 HP with one arrow");
		}
		public override void SetDefaults() {
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 3.5f;
			Item.value = 45;
			Item.rare = 1;
			Item.shoot = ModContent.ProjectileType<HealingArrowProj>();   
			Item.shootSpeed = 4f;                  
			Item.ammo = AmmoID.Arrow;              
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(40, 5);
            recipe.AddIngredient(1330);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
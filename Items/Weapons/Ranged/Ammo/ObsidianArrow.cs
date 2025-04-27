using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class ObsidianArrow : ModItem
	{
		public override void SetStaticDefaults() 
		{ 
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			/* Tooltip.SetDefault("More than just a head"
				+"\nInflicts Bleeding on enemies"); */
		}
		public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 1f;
			Item.value = 65;
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<HealingArrowProj>();   
			Item.shootSpeed = 7f;                  
			Item.ammo = AmmoID.Arrow;              
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(10);
			recipe.AddIngredient(40, 10);
            recipe.AddIngredient(ItemID.Obsidian);
			recipe.Register();
		}
	}
}
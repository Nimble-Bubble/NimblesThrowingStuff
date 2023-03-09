using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class VoltArrow : ModItem
	{
		public override void SetStaticDefaults() 
		{ 
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			Tooltip.SetDefault("Has a chance to electrify a target");
		}
		public override void SetDefaults() {
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 2f;
			Item.value = 45;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<VoltArrowProj>();   
			Item.shootSpeed = 8f;                  
			Item.ammo = AmmoID.Arrow;              
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(40, 50);
            recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
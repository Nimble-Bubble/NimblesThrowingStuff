using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class ShroomiteBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 4f;
			Item.value = 120;
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<ShroomiteBulletProj>();   
			Item.shootSpeed = 8f;                  
			Item.ammo = AmmoID.Bullet;              
		}
        public override void AddRecipes() 
		{
			//Can be crafted using Chlorophyte Bullets or just Shroomite
			Recipe recipe = CreateRecipe(125);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 125);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe(125);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 125);
			recipe.AddIngredient(ItemID.ShroomiteBar, 1);
			recipe.AddTile(247);
			recipe.Register();
			recipe = CreateRecipe(200);
			recipe.AddIngredient(ItemID.ShroomiteBar, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe(200);
			recipe.AddIngredient(ItemID.ShroomiteBar, 2);
			recipe.AddTile(247);
			recipe.Register();
		}
	}
}
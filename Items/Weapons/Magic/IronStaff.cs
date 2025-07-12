using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class IronStaff : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
		}
		public override void SetDefaults() 
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Magic;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.knockBack = 1f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 0, 25, 0);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item30;
			Item.autoReuse = true;
			Item.shoot = 459;
			Item.shootSpeed = 10f;
            Item.mana = 5;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
        {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(14, 12);
			recipe.AddIngredient(ItemID.Lens, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
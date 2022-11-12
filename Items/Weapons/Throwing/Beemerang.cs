using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Beemerang : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 26;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = 1;
			Item.knockBack = 6.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BeemerangProj>();
			Item.shootSpeed = 13.5f;
            Item.mana = 12;
		}
	}
}
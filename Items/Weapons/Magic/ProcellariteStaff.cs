using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class ProcellariteStaff : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
		}
		public override void SetDefaults() 
		{
			Item.damage = 155;
			Item.DamageType = DamageClass.Magic;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 5;
			Item.knockBack = 4f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<MagicBigStar>();
			Item.shootSpeed = 14f;
            Item.mana = 17;
		}
	}
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class ProcellariteStaff : ModItem
	{
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Creates a big star that explodes into other stars");
            Item.staff[item.type] = true;
		}
		public override void SetDefaults() 
		{
			item.damage = 170;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 4f;
            item.noMelee = true;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<MagicBigStar>();
			item.shootSpeed = 14f;
            item.mana = 17;
		}
	}
}
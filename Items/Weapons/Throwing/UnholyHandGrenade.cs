using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class UnholyHandGrenade : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Explodes into Greek fireballs");   
        }

		public override void SetDefaults() 
		{
			item.damage = 73;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 52;
			item.useAnimation = 52;
			item.useStyle = 1;
			item.knockBack = 7f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 37, 50, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("UnholyHandGrenadeProj");
			item.shootSpeed = 9f;
            item.mana = 15;
		}
	}
}
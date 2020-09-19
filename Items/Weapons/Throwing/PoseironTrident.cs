using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class PoseironTrident : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Poseiron's Trident");
         Tooltip.SetDefault("A sea god's three-pronged spear that oils and frostburns foes");   
        }

		public override void SetDefaults() 
		{
			item.damage = 78;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 7f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PoseironTridentProj");
			item.shootSpeed = 10f;
            item.mana = 20;
		}
	}
}
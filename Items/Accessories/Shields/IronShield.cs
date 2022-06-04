using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class IronShield : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Slow when guarding, but provides a nice defense");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 26;
            Item.value = Item.value = Item.buyPrice(0, 1, 25, 0);
            Item.rare = 0;
            Item.defense = 2;
        }
        //public override bool CanEquipAccessory(Player player, int slot)
        //{
        //    var modPlayer = player.GetModPlayer<NimblesPlayer>();
        //    if (modPlayer.whichShield >= 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.whichShield = 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.Register();
        }
    }
}

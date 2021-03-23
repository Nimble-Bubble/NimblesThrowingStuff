using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class MathrusGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draconic Greaves");
                Tooltip.SetDefault("Increases movement speed and throwing damage by 40%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 525000;
            item.rare = 10;
            item.defense = 20; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.4f;
            player.thrownDamage += 0.4f;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<DoradoFragment>(), 16);
            r.AddIngredient(3467, 12);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
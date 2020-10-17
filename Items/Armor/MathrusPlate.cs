using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class MathrusPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Draconic Breastplate");
                Tooltip.SetDefault("Increases throwing speed by 20% and throwing critical strike chance by 25%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 700000;
            item.rare = 10;
            item.defense = 25; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.2f;
            player.thrownCrit += 25;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(mod.ItemType("DoradoFragment"), 20);
            r.AddIngredient(3467, 16);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
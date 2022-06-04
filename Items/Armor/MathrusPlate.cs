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
            Item.width = 30;
            Item.height = 32;
            Item.value = 700000;
            Item.rare = 10;
            Item.defense = 25; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.2f;
            player.thrownCrit += 25;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(ModContent.ItemType<DoradoFragment>(), 20);
            r.AddIngredient(3467, 16);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
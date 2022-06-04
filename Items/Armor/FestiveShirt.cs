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
    public class FestiveShirt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Coat");
                Tooltip.SetDefault("Increases throwing speed by 15% and throwing critical strike chance by 20%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 1000000;
            Item.rare = 8;
            Item.defense = 20; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.15f;
            player.thrownCrit += 20;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(ModContent.ItemType<FestiveCloth>(), 24);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
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
    [AutoloadEquip(EquipType.Head)]
    public class MathrusHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Draconic Helmet")
                Tooltip.SetDefault("Increases mana by 120 and throwing velocity by 60%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 350000;
            item.rare = 10;
            item.defense = 15; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MathrusPlate") && legs.type == mod.ItemType("MathrusGreaves");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your throwing damage is increased by 25%, and you emit red light";
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 1.5f, 0f, 0f);
            player.thrownDamage += 0.25f;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.6f;
            player.statManaMax2 += 120;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(mod.ItemType("DoradoFragment"), 12);
            r.AddIngredient(3467, 8);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
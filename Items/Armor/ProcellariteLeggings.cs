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
    public class ProcellariteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Procellarite Leggings");
                Tooltip.SetDefault("Increases movement speed by 25% and minion and sentry slots by 2");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 750000;
            item.rare = ItemRarityID.Purple;
            item.defense = 21; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            player.moveSpeed += 0.25f;
            player.maxMinions += 2;
            player.maxTurrets += 2;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 18);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
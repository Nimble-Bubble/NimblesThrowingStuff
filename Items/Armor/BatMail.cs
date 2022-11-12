using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class BatMail : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Increases throwing velocity by 15%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 25000;
            Item.rare = 1;
            Item.defense = 4; 
        }
        public override void UpdateEquip(Player player)
        {
            player.ThrownVelocity += 0.15f;
        }
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(19, 16);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 12);
            r.AddTile(16);
            r.Register();
            r = CreateRecipe();
            r.AddIngredient(706, 16);
            r.AddIngredient(ModContent.ItemType<BatFlesh>(), 12);
            r.AddTile(16);
            r.Register();
        }
    }
}
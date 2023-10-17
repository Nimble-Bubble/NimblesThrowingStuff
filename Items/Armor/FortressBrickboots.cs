using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Armor;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FortressBrickboots : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Tooltip.SetDefault("Increases movement speed by 10%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 50000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            player.moveSpeed += 0.1f;
            modPlayer.guardBonus += 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FortressPlate>() && head.type == ModContent.ItemType<FortressHelmet>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Endurance (perecentage-based damage reduction) increased by 10%"
                +"\nAdditionally, consumable throwing items have a 33% chance to not be consumed";
            player.endurance += 0.1f;
            player.ThrownCost33 = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 12);
            recipe.AddIngredient(ItemID.BlueBrick, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 12);
            recipe.AddIngredient(ItemID.GreenBrick, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 12);
            recipe.AddIngredient(ItemID.PinkBrick, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
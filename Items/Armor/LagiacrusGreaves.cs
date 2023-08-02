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
    [AutoloadEquip(EquipType.Legs)]
    public class LagiacrusGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases attack speed by 5%"
                +"\nIncreases critical strike chance by 3%"); */
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 30000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 7; 
        }
        public override void UpdateEquip(Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.universalSpeed += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 3;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == Mod.Find<ModItem>("LagiacrusHelm").Type && body.type == Mod.Find<ModItem>("LagiacrusMail").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "With everlasting breath and newfound strength, you can swim much more easily";
            player.accFlipper = true;
            player.gills = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BeeWax, 10);
            recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
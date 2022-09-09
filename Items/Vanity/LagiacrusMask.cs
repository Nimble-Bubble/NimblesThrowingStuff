using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class LagiacrusMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This strange mask resembles the sea's monarch."
                +"\nPerfect for cosplay!");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.vanity = true;
        }
    }
}
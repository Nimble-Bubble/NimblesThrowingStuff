using NimblesThrowingStuff.Items.Placeables.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class HadalShellstoneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            ItemDrop = ModContent.ItemType<HadalShellstone>();
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Deep Shellstone");
            AddMapEntry(new Color(8, 72, 107), name);
            mineResist = 2f;
            minPick = 50;
            DustType = 42;
            soundType = 21;
            soundStyle = 1;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f; 
            g = 0.1f;
            b = 0.3f;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return true; //
        }
    }
}

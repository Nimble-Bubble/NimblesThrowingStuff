using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
 
namespace NimblesThrowingStuff.Tiles.Banners
{
    public class SmallRathBanner : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;  
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);//
            TileObjectData.newTile.Height = 3;  
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };  
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            TileID.Sets.DisableSmartCursor[Type] = true;
            LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Kelbi Banner");
            AddMapEntry(new Color(232, 106, 48), name); 
        }
 
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, Mod.Find<ModItem>("SmallRathBannerItem").Type);
        }
 
        public override void NearbyEffects(int i, int j, bool closer)   
        {
            if (closer)          
            {
                Player player = Main.LocalPlayer;
                Main.SceneMetrics.NPCBannerBuff[Mod.Find<ModNPC>("SmallRathwyvern").Type] = true;	
                Main.SceneMetrics.hasBanner = true;
            }
        }
    }
}

using System;

namespace Advanced
{
    /// <summary>
    /// Container the information about geometric shape
    /// </summary>
    public class ShapeInfo
    {
        private readonly string InfoString;

        public ShapeInfo(string info)
        {
            InfoString = info;
        }

        public string GetInfoString() => InfoString;
    }

    /// <summary>
    /// Basic Rectangle structure
    /// </summary>
    public struct Rectangle
    {
        public ShapeInfo RectInfo;

        public int RectTop, RectRight, RectBottom, RectLeft;

        public Rectangle(string info, int top, int right, int bottom, int left)
        {
            RectInfo = new ShapeInfo(info);
            RectTop = top;
            RectRight = right;
            RectBottom = bottom;
            RectLeft = left;
        }

        public void Display()
        {
            Console.WriteLine($"String = {RectInfo.GetInfoString()}, Top = {RectTop}, Right = {RectRight}, Bottom = {RectBottom}, Left = {RectLeft}");
        }
    }
}
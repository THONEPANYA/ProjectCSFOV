using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
using ClickableTransparentOverlay;
using ImGuiNET;
using SharpGen.Runtime;

namespace ConsoleApp1
{
    public class Randerer : Overlay
    {

        public int fov = 60; // Default Fov
        public int glow;
        public int noflash;
        protected override void Render()
        {
            ImGui.Begin("PROJEAT CS2 | Github.com/THONEPANYA");

            // Checkbox for glow
           // ImGui.SliderInt("GLOW (NOTWORKING)", ref glow, 0, 1);

            // Checkbox for glow
            ImGui.SliderInt("Anti_Flash", ref noflash, 0, 1);

            // Slider for FOV with minimum and maximum values
            ImGui.SliderInt("FOV", ref fov, 60, 140);

            ImGui.End();
        }
    }


}

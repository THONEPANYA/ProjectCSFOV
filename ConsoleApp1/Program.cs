using Swed64;
using ConsoleApp1;
using System.Net.NetworkInformation;

// Init Overlay
Swed swed = new Swed("cs2");

// Get Client
IntPtr client = swed.GetModuleBase("client.dll");

// Init Menu Render
Randerer renderer = new Randerer();
renderer.Start().Wait();

// Get Offsets Games

// Offsets.cs
int dwLocalPlayerPawn = 0x173B568;
int dwEntityList = 0x18C7F98;

// Client.dll
int m_pCameraServices = 0x1138;
int m_iFOV = 0x210;
int m_bIsScoped = 0x2290;
int m_flFlashBangTime = 0x1350;

int m_hPlayerPawn = 0x7E4;

// Fov Change Loop
while (true)
{
    uint desiredFov = (uint)renderer.fov;

    // Get Pawn
    IntPtr localPlayerPawn = swed.ReadPointer(client, dwLocalPlayerPawn);

    // Get Camera Services
    IntPtr cameraServices = swed.ReadPointer(localPlayerPawn, m_pCameraServices);

    // Current FOV
    uint currentFOV = swed.ReadUInt(cameraServices + m_iFOV);

    // If Scoped, We don't wrire
    bool isScoped = swed.ReadBool(localPlayerPawn + m_bIsScoped);

    if (!isScoped && currentFOV != desiredFov) // If we don't have desired
    {
        swed.WriteUInt(cameraServices + m_iFOV, desiredFov); // Write New FOV
    }

    // Can Add Thread Sleep, But FOV Will Lag More \\ --> Thread.Sleep(1);
}

// Anit Flash Loop
while (true)
{

    IntPtr localPlayerPawn = swed.ReadPointer(client, dwLocalPlayerPawn);

    float flashDuration = swed.ReadFloat(localPlayerPawn, m_flFlashBangTime);

    if (flashDuration > 0)
    {
        swed.WriteFloat(localPlayerPawn, m_flFlashBangTime, 0);
        Console.WriteLine("Evaded flash!");
    }
    Thread.Sleep(2);
}